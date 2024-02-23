using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Represents a load balancer that randomly selects endpoints from a collection.
/// </summary>
public class RandomLoadBalancer : IEndpointLoadBalancer
{
    private readonly System.Random _random;
    private readonly List<string> _endpoints;
    private EndpointPool _endpointPool;

    /// <summary>
    /// Initializes a new instance of the RandomLoadBalancer class with the specified endpoints.
    /// </summary>
    public RandomLoadBalancer(
        EndpointPool endpointPool)
    {
        _random = new System.Random();
        _endpoints = new List<string>();
    }

    /// <summary>
    /// Gets the next available endpoint randomly from the collection.
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_endpoints.Count == 0)
        {
            throw new System.InvalidOperationException("No endpoints available.");
        }

        int index = _random.Next(_endpoints.Count);
        return _endpoints[index];
    }

    /// <summary>
    /// Removes a specific endpoint from the load balancer.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        _endpoints.Remove(endpoint);
    }
}
