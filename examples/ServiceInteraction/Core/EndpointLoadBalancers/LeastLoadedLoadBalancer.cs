using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the least loaded endpoint based on the current load.
/// </summary>
public class LeastLoadedLoadBalancer : IEndpointLoadBalancer
{
    private Dictionary<string, int> _loadMap;
    private EndpointPool _endpointPool;

    /// <summary>
    /// Initializes a new instance of the LeastLoadedLoadBalancer class with the specified initial load map.
    /// </summary>
    public LeastLoadedLoadBalancer(
        EndpointPool endpointPool)
    {
        _loadMap = new Dictionary<string, int>();
        _endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the least loaded endpoint based on the current load.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_loadMap.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        return _loadMap.OrderBy(x => x.Value).First().Key;
    }

    /// <summary>
    /// Update the load of a specific endpoint in the load balancer.
    /// </summary>
    public void UpdateEndpoints(string endpoint, int load)
    {
        if (_loadMap.ContainsKey(endpoint))
            _loadMap[endpoint] = load;
        else
            _loadMap.Add(endpoint, load);
    }

    /// <summary>
    /// Remove an endpoint from the load balancer.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        if (_loadMap.ContainsKey(endpoint))
            _loadMap.Remove(endpoint);
        else
            throw new KeyNotFoundException($"Endpoint {endpoint} not found");
    }
}