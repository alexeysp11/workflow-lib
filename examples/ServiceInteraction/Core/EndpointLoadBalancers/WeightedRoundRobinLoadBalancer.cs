namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that uses weighted round-robin to select endpoints based on their weights.
/// </summary>
public class WeightedRoundRobinLoadBalancer : IEndpointLoadBalancer
{
    private List<(string endpoint, int weight)> _weightedEndpoints;
    private int _currentIndex;

    /// <summary>
    /// Initializes a new instance of the WeightedRoundRobinLoadBalancer class with the specified list of endpoints and weights.
    /// </summary>
    public WeightedRoundRobinLoadBalancer(List<(string, int)> endpointsWithWeights)
    {
        _weightedEndpoints = endpointsWithWeights;
        _currentIndex = 0;
    }

    /// <summary>
    /// Get the next endpoint based on weighted round-robin selection.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_weightedEndpoints.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        var selectedEndpoint = _weightedEndpoints[_currentIndex].endpoint;
        _currentIndex = (_currentIndex + 1) % _weightedEndpoints.Count;
        return selectedEndpoint;
    }

    /// <summary>
    /// Update the weight of an existing endpoint or add a new endpoint with its weight to the list of weighted endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint, int weight)
    {
        var existingEndpoint = _weightedEndpoints.FirstOrDefault(e => e.endpoint == endpoint);
        
        if (existingEndpoint != default)
        {
            // Update the weight of an existing endpoint
            _weightedEndpoints.Remove(existingEndpoint);
            _weightedEndpoints.Add((endpoint, weight));
        }
        else
        {
            // Add a new endpoint with its weight
            _weightedEndpoints.Add((endpoint, weight));
        }
    }

    /// <summary>
    /// Remove the specified endpoint from the list of weighted endpoints.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        var endpointToRemove = _weightedEndpoints.FirstOrDefault(e => e.endpoint == endpoint);
        if (endpointToRemove != default)
            _weightedEndpoints.Remove(endpointToRemove);
        else
            throw new ArgumentException($"Endpoint {endpoint} not found in the list");
    }
}
