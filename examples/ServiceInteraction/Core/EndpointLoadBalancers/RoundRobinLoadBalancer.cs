using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : IEndpointLoadBalancer
{
    private List<string> _endpoints;
    private int _currentIndex;
    private EndpointPool _endpointPool;

    /// <summary>
    /// Initializes a new instance of the RoundRobinLoadBalancer class with the specified list of endpoints.
    /// </summary>
    public RoundRobinLoadBalancer(
        EndpointPool endpointPool)
    {
        _endpoints = new List<string>();
        _currentIndex = 0;
        _endpointPool = endpointPool;
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
    /// Update a specific endpoint in the list of endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint)
    {
        if (!_endpoints.Contains(endpoint))
            _endpoints.Add(endpoint);
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