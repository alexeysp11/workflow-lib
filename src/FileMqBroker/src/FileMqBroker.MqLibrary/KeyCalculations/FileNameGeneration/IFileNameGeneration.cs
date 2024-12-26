using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;

/// <summary>
/// Interface for a filename generating.
/// </summary>
public interface IFileNameGeneration
{
    /// <summary>
    /// Generates a filename.
    /// </summary>
    string GetFileName(string method, string path, MessageFileType direction);

    /// <summary>
    /// Calculates a hash based on the method and path.
    /// </summary>
    string CalculateHash(string method, string path);
}