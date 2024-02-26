using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    private readonly object m_lock = new object();
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

        var endpointParameters = m_endpointPool.EndpointParameters.Values
            .Where(p => p != null && p.Endpoint != null && p.Endpoint.Status == EndpointStatus.Active)
            .ToArray();
        if (endpointParameters == null || endpointParameters.Length == 0)
            throw new System.Exception("Collection of endpoint parameters is null or empty");

        EndpointCollectionParameter endpointParameter;
        lock (m_lock)
        {
            if (m_currentIndex >= endpointParameters.Length)
            {
                // Reset to 0 if currentIndex is out of bounds.
                m_currentIndex = 0;
            }
            endpointParameter = endpointParameters[m_currentIndex];
            m_currentIndex = (m_currentIndex + 1) % endpointParameters.Length;
        }
        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }
}