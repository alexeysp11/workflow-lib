using System.Threading;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.Adapters.ReadAdapters;

/// <summary>
/// An adapter that is used on the client application side to read the message queue from the file broker.
/// </summary>
public class FileMqReadAdapter : IReadAdapter
{
    private int _oneTimeProcQueueElements;
    private AppInitConfigs _appInitConfigs;
    private IMessageFileQueue _messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileMqReadAdapter(
        AppInitConfigs appInitConfigs,
        ReadMessageFileQueue messageFileQueue)
    {
        _oneTimeProcQueueElements = appInitConfigs.OneTimeProcQueueElements;
        _appInitConfigs = appInitConfigs;
        _messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Method for reading messages from a queue.
    /// </summary>
    public void ReadMessageQueue()
    {
        var continuationDelegate = _appInitConfigs.BackendContinuationDelegate;
        if (continuationDelegate == null)
            throw new System.Exception("Continuation delegate could not be null. You have to specify the continuation delegate in order to handle elements from the message queue");
        
        var messages = _messageFileQueue.DequeueMessages(_oneTimeProcQueueElements);
        foreach (var message in messages)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                continuationDelegate(message);
            });
        }
    }
}