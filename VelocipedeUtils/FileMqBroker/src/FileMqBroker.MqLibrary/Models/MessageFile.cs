namespace FileMqBroker.MqLibrary.Models;

/// <summary>
/// Represents a message file.
/// </summary>
public class MessageFile
{
    /// <summary>
    /// The name of the message file.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The content of the message file.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// The advanced hash code of the message file.
    /// </summary>
    public string? CollapseHashCode { get; set; }
    
    /// <summary>
    /// The type of the message file.
    /// </summary>
    public MessageFileType MessageFileType { get; set; }
    
    /// <summary>
    /// The state of the message file.
    /// </summary>
    public MessageFileState MessageFileState { get; set; }
    
    /// <summary>
    /// The name of the HTTP method.
    /// </summary>
    public string? HttpMethod { get; set; }

    /// <summary>
    /// The name of the HTTP path.
    /// </summary>
    public string? HttpPath { get; set; }
}