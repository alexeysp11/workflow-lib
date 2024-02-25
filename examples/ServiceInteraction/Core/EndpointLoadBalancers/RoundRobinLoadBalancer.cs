using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    private int m_currentIndex;

    /// <summary>
    /// Initializes a new instance of the RoundRobinLoadBalancer class with the specified list of endpoints.
    /// </summary>
    public RoundRobinLoadBalancer(
        EndpointPool endpointPool)
    {
        m_currentIndex = 0;
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the next endpoint in a round-robin manner.
    /// </summary>
    public string GetNextEndpoint()
    {
        CheckNullReferences();

        var endpointParameters = m_endpointPool.EndpointParameters.Values.ToList();
        if (m_currentIndex >= endpointParameters.Count)
        {
            // Reset to 0 if currentIndex is out of bounds.
            m_currentIndex = 0;
        }
        var endpointParameter = endpointParameters[m_currentIndex];
        m_currentIndex = (m_currentIndex + 1) % endpointParameters.Count;
        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }

    /// <summary>
    /// Update a specific endpoint in the list of endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint)
    {
        CheckNullReferences();

        var endpointParameters = m_endpointPool.EndpointParameters;
        foreach (var endpointParameter in endpointParameters)
        {
            if (endpointParameter.Value.Endpoint.Name == endpoint)
            {
                // You can add endpoint update logic if needed.
            }
        }
    }
}