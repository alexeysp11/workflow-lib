namespace FileMqBroker.MqLibrary.Adapters.ReadAdapters;

/// <summary>
/// An adapter that is used on the client application side to read the message queue from the broker.
/// </summary>
public interface IReadAdapter
{
    /// <summary>
    /// Method for reading messages from a queue.
    /// </summary>
    void ReadMessageQueue();
}