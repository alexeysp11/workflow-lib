using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Represents a load balancer that randomly selects endpoints from a collection.
/// </summary>
public class RandomLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    private readonly System.Random m_random;

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
        CheckNullReferences();

        var endpointParameters = m_endpointPool.EndpointParameters;
        int index = m_random.Next(endpointParameters.Count);
        var value = endpointParameters.ElementAt(index).Value;
        return value == null || value.Endpoint == null ? string.Empty : value.Endpoint.Name;
    }
}
