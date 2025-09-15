namespace FileMqBroker.MqLibrary.FileContentGenerators;

/// <summary>
/// Provides functionality for generating a response to a received request as part of working with a message broker.
/// </summary>
public interface IFileContentGenerator
{
    /// <summary>
    /// 
    /// </summary>
    string GenerateContent(string messageFileName);
}