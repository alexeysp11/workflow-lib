using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.FileContentGenerators;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.ResponseHandlers;

/// <summary>
/// Provides functionality to write messages back to the queue that were processed on the backend.
/// </summary>
public class WriteBackResponseHandler : IResponseHandler
{
    private IWriteAdapter _writeAdapter;
    private IFileContentGenerator _fileContentGenerator;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WriteBackResponseHandler(
        IWriteAdapter writeAdapter,
        IFileContentGenerator fileContentGenerator)
    {
        _writeAdapter = writeAdapter;
        _fileContentGenerator = fileContentGenerator;
    }

    /// <summary>
    /// Method that is used to process a message received from a message broker.
    /// </summary>
    public void ContinuationMethod(MessageFile messageFile)
    {
        if (messageFile == null)
            throw new System.ArgumentNullException(nameof(messageFile));

        var responseContent = _fileContentGenerator.GenerateContent(messageFile.Name);
        _writeAdapter.WriteMessage(messageFile.HttpMethod, messageFile.HttpPath, responseContent, MessageFileType.Response, messageFile.Name);
    }
}