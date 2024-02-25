using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least number of active connections.
/// </summary>
public class LeastConnectionsLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    /// <summary>
    /// Initializes a new instance of the LeastConnectionsLoadBalancer class with the specified initial connection map.
    /// </summary>
    public LeastConnectionsLoadBalancer(
        EndpointPool endpointPool)
    {
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the endpoint with the least number of active connections.
    /// </summary>
    public string GetNextEndpoint()
    {
        CheckNullReferences();

        var selectedEndpoint = m_endpointPool.EndpointParameters
            .Where(p => p.Value != null && p.Value.Endpoint != null)
            .OrderBy(p => p.Value.ActiveConnectionCount)
            .FirstOrDefault();
        return selectedEndpoint.Value.Endpoint.Name;
    }

    /// <summary>
    /// Update the number of active connections for a specific endpoint.
    /// </summary>
    public void UpdateEndpoints(string endpoint, int connections)
    {
        CheckNullReferences();

        var existingEndpoint = m_endpointPool.EndpointParameters.FirstOrDefault(p => p.Value.Endpoint.Name == endpoint).Value;
        if (existingEndpoint != null)
        {
            existingEndpoint.ActiveConnectionCount = connections;
        }
        else
        {
            // Add a new endpoint with its connections.
            var newEndpoint = new EndpointCollectionParameter
            {
                Endpoint = new Endpoint
                {
                    Name = endpoint
                },
                ActiveConnectionCount = connections
            };
            m_endpointPool.AddEndpointToPool(newEndpoint);
        }
    }
}