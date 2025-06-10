using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.FileContentGenerators;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.ResponseHandlers;

/// <summary>
/// Provides functionality to write messages back to the queue that were processed on the backend.
/// </summary>
public class WriteBackResponseHandler : IResponseHandler
{
    private IWriteAdapter m_writeAdapter;
    private IFileContentGenerator m_fileContentGenerator;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WriteBackResponseHandler(
        IWriteAdapter writeAdapter,
        IFileContentGenerator fileContentGenerator)
    {
        m_writeAdapter = writeAdapter;
        m_fileContentGenerator = fileContentGenerator;
    }

    /// <summary>
    /// Method that is used to process a message received from a message broker.
    /// </summary>
    public void ContinuationMethod(MessageFile messageFile)
    {
        if (messageFile == null)
            throw new System.ArgumentNullException(nameof(messageFile));

        var responseContent = m_fileContentGenerator.GenerateContent(messageFile.Name);
        m_writeAdapter.WriteMessage(messageFile.HttpMethod, messageFile.HttpPath, responseContent, MessageFileType.Response, messageFile.Name);
    }
}