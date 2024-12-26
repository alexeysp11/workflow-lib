using System.Text;
using FileMqBroker.MqLibrary.KeyCalculations;

namespace FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;

/// <summary>
/// Provides SHA256 hash calculation functionality for collapsing requests.
/// </summary>
public class RequestCollapserSHA256 : IRequestCollapser
{
    private IKeyCalculation m_keyCalculation;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public RequestCollapserSHA256(KeyCalculationSHA256 keyCalculation)
    {
        m_keyCalculation = keyCalculation;
    }

    /// <summary>
    /// Calculates the SHA256 hash for collapsing requests, based on the method, path and content.
    /// </summary>
    public string CalculateRequestHashCode(string method, string path, string content)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("<method>").Append(method).Append("</method>");
        stringBuilder.Append("<path>").Append(path).Append("</path>");
        stringBuilder.Append("<content>").Append(content).Append("</content>");
        return m_keyCalculation.CalculateHash(stringBuilder.ToString());
    }
}