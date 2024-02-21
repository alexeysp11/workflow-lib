namespace WorkflowLib.Examples.ServiceInteraction.Models;

/// <summary>
/// Endpoint collection parameter.
/// </summary>
public class EndpointCollectionParameter
{
    /// <summary>
    /// ID of endpoint collection parameter.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Endpoint.
    /// </summary>
    public Endpoint Endpoint { get; set; }

    /// <summary>
    /// Amount of active connection.
    /// </summary>
    public int ActiveConnectionCount { get; set; }

    /// <summary>
    /// Process time (CPU time).
    /// </summary>
    public int ProcessTime { get; set; }

    /// <summary>
    /// System load (CPU load).
    /// </summary>
    public int SystemLoad { get; set; }

    /// <summary>
    /// Memory usage.
    /// </summary>
    public int MemoryUsage { get; set; }

    /// <summary>
    /// Network speed.
    /// </summary>
    public int NetworkSpeed { get; set; }

    /// <summary>
    /// Processed requests.
    /// </summary>
    public int ProcessedRequests { get; set; }

    /// <summary>
    /// Response time.
    /// </summary>
    public System.TimeSpan ResponseTime { get; set; }

    /// <summary>
    /// Weight of the endpoint.
    /// </summary>
    public int EndpointWeight { get; set; }
}