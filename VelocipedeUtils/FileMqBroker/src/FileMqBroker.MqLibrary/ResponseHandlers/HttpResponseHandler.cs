using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.ResponseHandlers;

/// <summary>
/// Provides functionality to send messages back over HTTP.
/// </summary>
public class HttpResponseHandler : IResponseHandler
{
    /// <summary>
    /// Method that is used to process a message received from a message broker.
    /// </summary>
    public void ContinuationMethod(MessageFile messageFile)
    {
        if (messageFile == null)
            throw new System.ArgumentNullException(nameof(messageFile));

        System.Console.WriteLine("Message file name: {messageFileName}, {content}", messageFile.Name, messageFile.Content);

        // Send the message via HTTP.
    }
}