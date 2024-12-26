using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.Adapters.WriteAdapters;

/// <summary>
/// Provides functionality for writing to the RabbitMQ message queue.
/// </summary>
public class RabbitMqWriteAdapter : IWriteAdapter
{
    private IMessageFileQueue m_messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public RabbitMqWriteAdapter(WriteMessageFileQueue messageFileQueue)
    {
        m_messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Ensures that a message is written to the RabbitMQ message queue.
    /// </summary>
    public void WriteMessage(string method, string path, string content, MessageFileType direction, string? oldMessageFileName = null)
    {
        // 
    }
}