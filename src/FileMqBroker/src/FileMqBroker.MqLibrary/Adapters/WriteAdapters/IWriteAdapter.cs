using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.Adapters.WriteAdapters;

/// <summary>
/// Provides functionality for writing to a message queue.
/// </summary>
public interface IWriteAdapter
{
    /// <summary>
    /// Ensures that a message is written to the message queue.
    /// </summary>
    void WriteMessage(string method, string path, string content, MessageFileType direction, string? oldMessageFileName = null);
}