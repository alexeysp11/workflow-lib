using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.DirectoryOperations;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.QueueDispatchers;

/// <summary>
/// Class for processing the message queue as a reader.
/// </summary>
public class ReadMqDispatcher : IMqDispatcher
{
    private readonly string m_requestDirectoryName;
    private readonly string m_responseDirectoryName;
    private readonly int m_oneTimeProcQueueElements;
    private readonly MessageFileType m_messageFileType;
    private readonly IMessageFileDAL m_messageFileDAL;
    private readonly IExceptionDAL m_exceptionDAL;
    private readonly FileHandler m_fileHandler;
    private readonly MessageFileQueue m_messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ReadMqDispatcher(
        AppInitConfigs appInitConfigs, 
        IMessageFileDAL messageFileDAL,
        IExceptionDAL exceptionDAL,
        FileHandler fileHandler, 
        ReadMessageFileQueue messageFileQueue)
    {
        m_oneTimeProcQueueElements = appInitConfigs.OneTimeProcQueueElements;
        m_requestDirectoryName = appInitConfigs.RequestDirectoryName;
        m_responseDirectoryName = appInitConfigs.ResponseDirectoryName;
        m_messageFileType = appInitConfigs.ReadMqDispatcherMessageFileType;
        m_messageFileDAL = messageFileDAL;
        m_exceptionDAL = exceptionDAL;
        m_fileHandler = fileHandler;
        m_messageFileQueue = messageFileQueue;
    }

    /// <summary>
    /// Method for processing the message queue from the consumer side.
    /// </summary>
    public void ProcessMessageQueue()
    {
        // Update the status of old messages so they can be read and removed from the directory.
        // Get files from the database that can be processed.
        m_messageFileDAL.UpdateOldMessageFileState();
        var fileMessages = m_messageFileDAL.GetMessageFileInfo(20_000, 1, m_messageFileType);
        if (fileMessages == null)
            throw new System.Exception("File messages could not be null");
        if (fileMessages.Count == 0)
            return;
        
        // Enqueue the messages and update their status in DB.
        ThreadPool.QueueUserWorkItem(state =>
        {
            foreach (var fileMessage in fileMessages)
            {
                fileMessage.MessageFileState = MessageFileState.Reading;
                m_messageFileQueue.EnqueueMessage(fileMessage);
            }
            m_messageFileDAL.UpdateMessageFileState(fileMessages);
        });

        // Read files from the directory.
        var processingTasks = new Task[fileMessages.Count];
        for (int i = 0; i < fileMessages.Count; i++)
        {
            var fm = fileMessages[i];
            Task task = Task.Run(() =>
            {
                ProcessFileReadRequest(fm);
            });
            processingTasks[i] = task;
        }
        Task.WaitAll(processingTasks);
        
        // Logging messages as processed elements.
        var loggingMessages = m_messageFileQueue.DequeueMessagesLogging(m_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            m_messageFileDAL.UpdateMessageFileState(loggingMessages);
        });

        // Add exceptions into database.
        var exceptions = m_messageFileQueue.DequeueExceptionLogging(m_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            m_exceptionDAL.InsertExceptions(exceptions);
        });
    }

    /// <summary>
    /// Performs processing of the specified file (create the file in the directory).
    /// </summary>
    private void ProcessFileReadRequest(MessageFile fileMessage)
    {
        var fileName = Path.Combine((m_messageFileType == MessageFileType.Request ? m_requestDirectoryName : m_responseDirectoryName), fileMessage.Name);
        var fileContent = fileMessage.Content;
        try
        {
            fileMessage.Content = m_fileHandler.ReadFromFile(fileName);
            m_fileHandler.DeleteFile(fileName);
            fileMessage.MessageFileState = MessageFileState.Processed;
        }
        catch (Exception ex)
        {
            fileMessage.MessageFileState = MessageFileState.FailedToRead;
            m_messageFileQueue.EnqueueExceptionLogging($"Error processing file {fileName}: {ex.Message}");
        }
        finally
        {
            m_messageFileQueue.EnqueueMessageLogging(fileMessage);
        }
    }
}