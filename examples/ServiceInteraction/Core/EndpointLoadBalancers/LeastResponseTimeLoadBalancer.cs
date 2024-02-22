using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least response time.
/// </summary>
public class LeastResponseTimeLoadBalancer : IEndpointLoadBalancer
{
    private Dictionary<string, TimeSpan> _responseTimesMap;
    private EndpointPool _endpointPool;

    /// <summary>
    /// Initializes a new instance of the LeastResponseTimeLoadBalancer class with the specified initial endpoint map.
    /// </summary>
    public LeastResponseTimeLoadBalancer(
        Dictionary<string, TimeSpan> initialResponseTimesMap,
        EndpointPool endpointPool)
    {
        _responseTimesMap = initialResponseTimesMap;
        _endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the endpoint with the least response time.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_responseTimesMap.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        return _responseTimesMap.OrderBy(x => x.Value).First().Key;
    }

    /// <summary>
    /// Update the response time for a specific endpoint.
    /// </summary>
    public void UpdateEndpoints(string endpoint, TimeSpan responseTime)
    {
        if (_responseTimesMap.ContainsKey(endpoint))
            _responseTimesMap[endpoint] = responseTime;
        else
            _responseTimesMap.Add(endpoint, responseTime);
    }

    /// <summary>
    /// Remove an endpoint from the load balancer.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        if (_responseTimesMap.ContainsKey(endpoint))
            _responseTimesMap.Remove(endpoint);
        else
            throw new KeyNotFoundException($"Endpoint {endpoint} not found");
    }
}
