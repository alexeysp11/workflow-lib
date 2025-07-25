using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.DirectoryOperations;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.QueueDispatchers;

/// <summary>
/// Class for processing the message queue as a writer.
/// </summary>
public class WriteMqDispatcher : IMqDispatcher
{
    private readonly string _requestDirectoryName;
    private readonly string _responseDirectoryName;
    private readonly int _oneTimeProcQueueElements;
    private readonly IMessageFileDAL _messageFileDAL;
    private readonly IExceptionDAL _exceptionDAL;
    private readonly FileHandler _fileHandler;
    private readonly MessageFileQueue _messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WriteMqDispatcher(
        AppInitConfigs appInitConfigs, 
        IMessageFileDAL messageFileDAL,
        IExceptionDAL exceptionDAL,
        FileHandler fileHandler, 
        WriteMessageFileQueue messageFileQueue)
    {
        _oneTimeProcQueueElements = appInitConfigs.OneTimeProcQueueElements;
        _requestDirectoryName = appInitConfigs.RequestDirectoryName;
        _responseDirectoryName = appInitConfigs.ResponseDirectoryName;
        _messageFileDAL = messageFileDAL;
        _exceptionDAL = exceptionDAL;
        _fileHandler = fileHandler;
        _messageFileQueue = messageFileQueue;
    }

    /// <summary>
    /// Method for processing the message queue from the producer side.
    /// </summary>
    public void ProcessMessageQueue()
    {
        var fileMessages = _messageFileQueue.DequeueMessages(_oneTimeProcQueueElements);
        if (fileMessages == null)
            throw new System.Exception("Collection of the file messages could not be null");
        if (fileMessages.Count == 0)
            return;
        
        // Add info about the file into DB.
        ThreadPool.QueueUserWorkItem(state =>
        {
            foreach (var fileMessage in fileMessages)
            {
                fileMessage.MessageFileState = MessageFileState.Writing;
            }
            _messageFileDAL.InsertMessageFileState(fileMessages);
        });
        
        // Create a file.
        var processingTasks = new Task[fileMessages.Count];
        for (int i = 0; i < fileMessages.Count; i++)
        {
            var fm = fileMessages[i];
            Task task = Task.Run(() =>
            {
                ProcessFileCreateRequest(fm);
            });
            processingTasks[i] = task;
        }
        Task.WaitAll(processingTasks);

        // Logging messages as processed elements.
        var loggingMessages = _messageFileQueue.DequeueMessagesLogging(_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            _messageFileDAL.UpdateMessageFileState(loggingMessages);
        });

        // Exceptions.
        var exceptions = _messageFileQueue.DequeueExceptionLogging(_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            _exceptionDAL.InsertExceptions(exceptions);
        });
    }

    /// <summary>
    /// Performs processing of the specified file (create the file in the directory).
    /// </summary>
    private void ProcessFileCreateRequest(MessageFile fileMessage)
    {
        var fileName = Path.Combine((fileMessage.MessageFileType == MessageFileType.Request ? _requestDirectoryName : _responseDirectoryName), fileMessage.Name);
        var fileContent = fileMessage.Content;
        try
        {
            _fileHandler.CreateFile(fileName);
            _fileHandler.WriteToFile(fileName, fileContent);
            fileMessage.MessageFileState = MessageFileState.ReadyToRead;
        }
        catch (Exception ex)
        {
            fileMessage.MessageFileState = MessageFileState.FailedToWrite;
            _messageFileQueue.EnqueueExceptionLogging($"Error processing file {fileName}: {ex.Message}");
        }
        finally
        {
            _messageFileQueue.EnqueueMessageLogging(fileMessage);
        }
    }
}