using System.Threading;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.Adapters.ReadAdapters;

/// <summary>
/// An adapter that is used on the client application side to read the message queue from the file broker.
/// </summary>
public class FileMqReadAdapter : IReadAdapter
{
    private int m_oneTimeProcQueueElements;
    private AppInitConfigs m_appInitConfigs;
    private IMessageFileQueue m_messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileMqReadAdapter(
        AppInitConfigs appInitConfigs,
        ReadMessageFileQueue messageFileQueue)
    {
        m_oneTimeProcQueueElements = appInitConfigs.OneTimeProcQueueElements;
        m_appInitConfigs = appInitConfigs;
        m_messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Method for reading messages from a queue.
    /// </summary>
    public void ReadMessageQueue()
    {
        var continuationDelegate = m_appInitConfigs.BackendContinuationDelegate;
        if (continuationDelegate == null)
            throw new System.Exception("Continuation delegate could not be null. You have to specify the continuation delegate in order to handle elements from the message queue");
        
        var messages = m_messageFileQueue.DequeueMessages(m_oneTimeProcQueueElements);
        foreach (var message in messages)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                continuationDelegate(message);
            });
        }
    }
}