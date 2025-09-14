using FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;
using FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.Adapters.WriteAdapters;

/// <summary>
/// Provides functionality for writing to a file broker message queue.
/// </summary>
public class FileMqWriteAdapter : IWriteAdapter
{
    private readonly DuplicateRequestCollapseType m_collapseType;
    private IRequestCollapser m_requestCollapser;
    private IFileNameGeneration m_fileNameGeneration;
    private IMessageFileQueue m_messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileMqWriteAdapter(
        AppInitConfigs appInitConfigs,
        IRequestCollapser requestCollapser,
        IFileNameGeneration fileNameGeneration,
        WriteMessageFileQueue messageFileQueue)
    {
        m_collapseType = appInitConfigs.DuplicateRequestCollapseType;
        m_requestCollapser = requestCollapser;
        m_fileNameGeneration = fileNameGeneration;
        m_messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Ensures that a message is written to the file broker message queue.
    /// </summary>
    public void WriteMessage(string method, string path, string content, MessageFileType direction, string? oldMessageFileName = null)
    {
        var collapseHash = m_requestCollapser.CalculateRequestHashCode(method, path, content);

        if (m_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            if (m_messageFileQueue.IsMessageInQueue(collapseHash))
            {
                return;
            }
        }

        var name = string.IsNullOrEmpty(oldMessageFileName) ? m_fileNameGeneration.GetFileName(method, path, direction) : oldMessageFileName.Replace(".req", ".resp");
        var messageFile = new MessageFile
        {
            Name = name,
            Content = content,
            HttpMethod = method,
            HttpPath = path,
            CollapseHashCode = collapseHash,
            MessageFileType = direction,
            MessageFileState = MessageFileState.Undefined
        };

        m_messageFileQueue.EnqueueMessage(messageFile);
    }
}