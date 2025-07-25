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
    private readonly DuplicateRequestCollapseType _collapseType;
    private IRequestCollapser _requestCollapser;
    private IFileNameGeneration _fileNameGeneration;
    private IMessageFileQueue _messageFileQueue;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileMqWriteAdapter(
        AppInitConfigs appInitConfigs,
        IRequestCollapser requestCollapser,
        IFileNameGeneration fileNameGeneration,
        WriteMessageFileQueue messageFileQueue)
    {
        _collapseType = appInitConfigs.DuplicateRequestCollapseType;
        _requestCollapser = requestCollapser;
        _fileNameGeneration = fileNameGeneration;
        _messageFileQueue = messageFileQueue;
    }
    
    /// <summary>
    /// Ensures that a message is written to the file broker message queue.
    /// </summary>
    public void WriteMessage(string method, string path, string content, MessageFileType direction, string? oldMessageFileName = null)
    {
        var collapseHash = _requestCollapser.CalculateRequestHashCode(method, path, content);

        if (_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            if (_messageFileQueue.IsMessageInQueue(collapseHash))
            {
                return;
            }
        }

        var name = string.IsNullOrEmpty(oldMessageFileName) ? _fileNameGeneration.GetFileName(method, path, direction) : oldMessageFileName.Replace(".req", ".resp");
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

        _messageFileQueue.EnqueueMessage(messageFile);
    }
}