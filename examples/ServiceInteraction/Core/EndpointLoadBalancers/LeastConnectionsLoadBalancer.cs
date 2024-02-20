using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least number of active connections.
/// </summary>
public class LeastConnectionsLoadBalancer : IEndpointLoadBalancer
{
    private Dictionary<string, int> _connectionsMap;

    /// <summary>
    /// Initializes a new instance of the LeastConnectionsLoadBalancer class with the specified initial connection map.
    /// </summary>
    public LeastConnectionsLoadBalancer(Dictionary<string, int> initialConnectionsMap)
    {
        _connectionsMap = initialConnectionsMap;
    }

    /// <summary>
    /// Get the endpoint with the least number of active connections.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_connectionsMap.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        return _connectionsMap.OrderBy(x => x.Value).First().Key;
    }

    /// <summary>
    /// Update the number of active connections for a specific endpoint.
    /// </summary>
    public void UpdateEndpoints(string endpoint, int connections)
    {
        if (_connectionsMap.ContainsKey(endpoint))
            _connectionsMap[endpoint] = connections;
        else
            _connectionsMap.Add(endpoint, connections);
    }
    
    /// <summary>
    /// Remove an endpoint from the load balancer.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        if (_connectionsMap.ContainsKey(endpoint))
            _connectionsMap.Remove(endpoint);
        else
            throw new KeyNotFoundException($"Endpoint {endpoint} not found");
    }
}