using System.Collections.Generic;
using WorkflowLib.ServiceDiscoveryBpm.ObjectPooling;
using WorkflowLib.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.ServiceDiscoveryBpm.LoadBalancers;

/// <summary>
/// Load balancer that selects endpoints in a round-robin manner.
/// </summary>
public class RoundRobinLoadBalancer : BaseEsbLoadBalancer, IEsbLoadBalancer
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

        var endpointParameters = m_endpointPool.ActiveEndpointParameters;
        if (endpointParameters == null || endpointParameters.Count == 0)
            throw new System.Exception("Collection of endpoint parameters is null or empty");

        EndpointCollectionParameter endpointParameter;
        lock (m_lock)
        {
            if (m_currentIndex >= endpointParameters.Count)
            {
                // Reset to 0 if currentIndex is out of bounds.
                m_currentIndex = 0;
            }
            endpointParameter = endpointParameters[m_currentIndex];
            m_currentIndex = (m_currentIndex + 1) % endpointParameters.Count;
        }
        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }
}