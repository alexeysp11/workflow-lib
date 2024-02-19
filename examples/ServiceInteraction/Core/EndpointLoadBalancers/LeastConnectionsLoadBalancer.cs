using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least number of active connections.
/// </summary>
public class LeastConnectionsLoadBalancer : IEndpointLoadBalancer
{
    private Dictionary<string, int> _connectionsMap;

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

        string leastConnectionsEndpoint = _connectionsMap.OrderBy(x => x.Value).First().Key;
        return leastConnectionsEndpoint;
    }

    /// <summary>
    /// Update the number of active connections for a specific endpoint.
    /// </summary>
    public void UpdateConnections(string endpoint, int connections)
    {
        if (_connectionsMap.ContainsKey(endpoint))
            _connectionsMap[endpoint] = connections;
        else
            _connectionsMap.Add(endpoint, connections);
    }
}