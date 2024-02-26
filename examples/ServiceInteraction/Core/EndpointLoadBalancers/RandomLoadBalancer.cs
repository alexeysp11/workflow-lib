using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

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

        var endpointParameters = m_endpointPool.EndpointParameters.Values
            .Where(p => p != null && p.Endpoint != null && p.Endpoint.Status == EndpointStatus.Active)
            .ToArray();
        if (endpointParameters == null || endpointParameters.Length == 0)
            throw new System.Exception("Collection of endpoint parameters is null or empty");
        
        int index = m_random.Next(endpointParameters.Length);
        var value = endpointParameters[index];
        return value == null || value.Endpoint == null ? string.Empty : value.Endpoint.Name;
    }

    /// <summary>
    /// Update a specific endpoint in the list of endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint)
    {
        CheckNullReferences();

        var existingEndpoint = m_endpointPool.EndpointParameters.FirstOrDefault(p => p.Value.Endpoint.Name == endpoint).Value;
        if (existingEndpoint == null)
        {
            // Add a new endpoint.
            var newEndpoint = new EndpointCollectionParameter
            {
                Endpoint = new Endpoint
                {
                    Name = endpoint
                }
            };
            m_endpointPool.AddEndpointToPool(newEndpoint);
        }
    }
}
