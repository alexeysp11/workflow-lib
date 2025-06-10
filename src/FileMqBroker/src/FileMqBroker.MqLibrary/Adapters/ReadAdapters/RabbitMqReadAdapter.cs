using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.Adapters.ReadAdapters;

/// <summary>
/// An adapter that is used on the client application side to read the message queue from RabbitMQ.
/// </summary>
public class RabbitMqReadAdapter<T> : IReadAdapter
{
    private IMessageFileQueue m_messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public RabbitMqReadAdapter(ReadMessageFileQueue messageFileQueue)
    {
        m_messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Method for reading messages from a queue.
    /// </summary>
    public void ReadMessageQueue()
    {
        // 
    }
}