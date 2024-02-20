using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : IEndpointLoadBalancer
{
    private List<string> _endpoints;
    private int _currentIndex;

    /// <summary>
    /// Initializes a new instance of the RoundRobinLoadBalancer class with the specified list of endpoints.
    /// </summary>
    public RoundRobinLoadBalancer(List<string> endpoints)
    {
        _endpoints = endpoints;
        _currentIndex = 0;
    }

    /// <summary>
    /// Get the next endpoint in a round-robin manner.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_endpoints.Count == 0)
            throw new System.InvalidOperationException("No endpoints available");

        string endpoint = _endpoints[_currentIndex];
        _currentIndex = (_currentIndex + 1) % _endpoints.Count;
        return endpoint;
    }

    /// <summary>
    /// Remove the specified endpoint from the list of endpoints.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        if (_endpoints.Contains(endpoint))
            _endpoints.Remove(endpoint);
        else
            throw new ArgumentException($"Endpoint {endpoint} not found in the list");
    }
}