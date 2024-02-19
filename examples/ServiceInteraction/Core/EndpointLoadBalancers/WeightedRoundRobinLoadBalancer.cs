namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that uses weighted round-robin to select endpoints based on their weights.
/// </summary>
public class WeightedRoundRobinLoadBalancer
{
    private List<(string endpoint, int weight)> _weightedEndpoints;
    private int _currentIndex;

    public WeightedRoundRobinLoadBalancer(List<(string, int)> endpointsWithWeights)
    {
        _weightedEndpoints = endpointsWithWeights;
        _currentIndex = 0;
    }

    /// <summary>
    /// Get the next endpoint based on weighted round-robin selection.
    /// </summary>
    public string GetWeightedRoundRobinEndpoint()
    {
        if (_weightedEndpoints.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        var selectedEndpoint = _weightedEndpoints[_currentIndex].endpoint;
        _currentIndex = (_currentIndex + 1) % _weightedEndpoints.Count;
        return selectedEndpoint;
    }
}
