using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Represents a load balancer that randomly selects endpoints from a collection.
/// </summary>
public class RandomLoadBalancer : IEndpointLoadBalancer
{
    private readonly System.Random m_random;
    private EndpointPool m_endpointPool;

    /// <summary>
    /// Initializes a new instance of the RandomLoadBalancer class with the specified endpoints.
    /// </summary>
    public RandomLoadBalancer(
        EndpointPool endpointPool)
    {
        m_random = new System.Random();
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Gets the next available endpoint randomly from the collection.
    /// </summary>
    public string GetNextEndpoint()
    {
        var endpointParameters = m_endpointPool.EndpointParameters;

        if (endpointParameters.Count == 0)
        {
            throw new System.InvalidOperationException("No endpoints available.");
        }

        int index = m_random.Next(endpointParameters.Count);
        return endpointParameters.ElementAt(index).Value.Endpoint.Name;
    }

    /// <summary>
    /// Removes a specific endpoint from the load balancer.
    /// </summary>
    public void RemoveEndpoint(string endpoint)
    {
        var endpointParameters = m_endpointPool.EndpointParameters;
        foreach (var endpointParameter in endpointParameters)
        {
            if (endpointParameter.Value.Endpoint.Name == endpoint)
            {
                m_endpointPool.RemoveEndpointFromPool(endpointParameter.Key);
                break;
            }
        }
    }
}
