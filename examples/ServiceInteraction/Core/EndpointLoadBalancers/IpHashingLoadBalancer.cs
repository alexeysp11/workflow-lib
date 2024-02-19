namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects an endpoint based on the hash of the client's IP address.
/// </summary>
public class IpHashingLoadBalancer
{
    private List<string> _endpoints;

    public IpHashingLoadBalancer(List<string> availableEndpoints)
    {
        _endpoints = availableEndpoints;
    }

    /// <summary>
    /// Get the endpoint based on the hash of the client's IP address.
    /// </summary>
    public string GetIpHashingEndpoint(string clientIpAddress)
    {
        int hash = clientIpAddress.GetHashCode();
        int index = Math.Abs(hash) % _endpoints.Count;
        return _endpoints[index];
    }
}
