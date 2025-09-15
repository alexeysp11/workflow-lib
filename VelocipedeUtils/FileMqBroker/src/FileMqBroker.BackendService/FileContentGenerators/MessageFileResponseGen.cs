using System.Text;
using FileMqBroker.MqLibrary.FileContentGenerators;

namespace FileMqBroker.BackendService.FileContentGenerators;

/// <summary>
/// Provides functionality for generating a response to a received request as part of working with a message broker.
/// </summary>
public class MessageFileResponseGen : IFileContentGenerator
{
    /// <summary>
    /// Generates a response to a message by file name.
    /// </summary>
    public string GenerateContent(string messageFileName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Reponse code: ").Append(200).Append("\n").Append("Response for the file: ").Append(messageFileName);
        return stringBuilder.ToString();
    }
}