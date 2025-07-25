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
    private readonly string _requestDirectoryName;
    private readonly string _responseDirectoryName;
    private readonly int _oneTimeProcQueueElements;
    private readonly MessageFileType _messageFileType;
    private readonly IMessageFileDAL _messageFileDAL;
    private readonly IExceptionDAL _exceptionDAL;
    private readonly FileHandler _fileHandler;
    private readonly MessageFileQueue _messageFileQueue;

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
        _oneTimeProcQueueElements = appInitConfigs.OneTimeProcQueueElements;
        _requestDirectoryName = appInitConfigs.RequestDirectoryName;
        _responseDirectoryName = appInitConfigs.ResponseDirectoryName;
        _messageFileType = appInitConfigs.ReadMqDispatcherMessageFileType;
        _messageFileDAL = messageFileDAL;
        _exceptionDAL = exceptionDAL;
        _fileHandler = fileHandler;
        _messageFileQueue = messageFileQueue;
    }

    /// <summary>
    /// Method for processing the message queue from the consumer side.
    /// </summary>
    public void ProcessMessageQueue()
    {
        // Update the status of old messages so they can be read and removed from the directory.
        // Get files from the database that can be processed.
        _messageFileDAL.UpdateOldMessageFileState();
        var fileMessages = _messageFileDAL.GetMessageFileInfo(20_000, 1, _messageFileType);
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
                _messageFileQueue.EnqueueMessage(fileMessage);
            }
            _messageFileDAL.UpdateMessageFileState(fileMessages);
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
        var loggingMessages = _messageFileQueue.DequeueMessagesLogging(_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            _messageFileDAL.UpdateMessageFileState(loggingMessages);
        });

        // Add exceptions into database.
        var exceptions = _messageFileQueue.DequeueExceptionLogging(_oneTimeProcQueueElements);
        ThreadPool.QueueUserWorkItem(state =>
        {
            _exceptionDAL.InsertExceptions(exceptions);
        });
    }

    /// <summary>
    /// Performs processing of the specified file (create the file in the directory).
    /// </summary>
    private void ProcessFileReadRequest(MessageFile fileMessage)
    {
        var fileName = Path.Combine((_messageFileType == MessageFileType.Request ? _requestDirectoryName : _responseDirectoryName), fileMessage.Name);
        var fileContent = fileMessage.Content;
        try
        {
            fileMessage.Content = _fileHandler.ReadFromFile(fileName);
            _fileHandler.DeleteFile(fileName);
            fileMessage.MessageFileState = MessageFileState.Processed;
        }
        catch (Exception ex)
        {
            fileMessage.MessageFileState = MessageFileState.FailedToRead;
            _messageFileQueue.EnqueueExceptionLogging($"Error processing file {fileName}: {ex.Message}");
        }
        finally
        {
            _messageFileQueue.EnqueueMessageLogging(fileMessage);
        }
    }
}