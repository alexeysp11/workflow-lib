using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : IEndpointLoadBalancer
{
    private readonly object m_lock = new object();
    private int m_currentIndex;
    private EndpointPool m_endpointPool;

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
        if (m_endpointPool.EndpointParameters.Count == 0)
            throw new System.InvalidOperationException("No endpoints available");

        EndpointCollectionParameter endpointParameter;
        lock (m_lock)
        {
            var endpointParameters = m_endpointPool.EndpointParameters.Values.ToList();
            m_currentIndex = (m_currentIndex + 1) % endpointParameters.Count;
            endpointParameter = endpointParameters[m_currentIndex];
        }
        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }

    /// <summary>
    /// Update a specific endpoint in the list of endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint)
    {
        var endpointParameters = m_endpointPool.EndpointParameters;
        foreach (var endpointParameter in endpointParameters)
        {
            if (endpointParameter.Value.Endpoint.Name == endpoint)
            {
                // You can add endpoint update logic if needed.
            }
        }
    }

    /// <summary>
    /// Remove the specified endpoint from the list of endpoints.
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