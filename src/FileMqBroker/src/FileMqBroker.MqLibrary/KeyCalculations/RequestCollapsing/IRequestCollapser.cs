namespace FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;

/// <summary>
/// Provides hash calculation functionality for collapsing requests.
/// </summary>
public interface IRequestCollapser
{
    /// <summary>
    /// Calculates the hash for collapsing requests, based on the method, path and content
    /// </summary>
    string CalculateRequestHashCode(string method, string path, string content);
}