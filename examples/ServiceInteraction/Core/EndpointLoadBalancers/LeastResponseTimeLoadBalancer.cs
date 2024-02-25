using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least response time.
/// </summary>
public class LeastResponseTimeLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    /// <summary>
    /// Initializes a new instance of the LeastResponseTimeLoadBalancer class with the specified initial endpoint map.
    /// </summary>
    public LeastResponseTimeLoadBalancer(
        EndpointPool endpointPool)
    {
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the endpoint with the least response time.
    /// </summary>
    public string GetNextEndpoint()
    {
        CheckNullReferences();

        var selectedEndpoint = m_endpointPool.EndpointParameters
            .Where(p => p.Value != null && p.Value.Endpoint != null)
            .OrderBy(p => p.Value.ResponseTime)
            .FirstOrDefault();
        return selectedEndpoint.Value.Endpoint.Name;
    }

    /// <summary>
    /// Update the response time for a specific endpoint.
    /// </summary>
    public void UpdateEndpoints(string endpoint, TimeSpan responseTime)
    {
        CheckNullReferences();

        var existingEndpoint = m_endpointPool.EndpointParameters.FirstOrDefault(p => p.Value.Endpoint.Name == endpoint).Value;
        if (existingEndpoint != null)
        {
            existingEndpoint.ResponseTime = responseTime;
        }
        else
        {
            // Add a new endpoint with its response time.
            var newEndpoint = new EndpointCollectionParameter
            {
                Endpoint = new Endpoint
                {
                    Name = endpoint
                },
                ResponseTime = responseTime
            };
            m_endpointPool.AddEndpointToPool(newEndpoint);
        }
    }
}
