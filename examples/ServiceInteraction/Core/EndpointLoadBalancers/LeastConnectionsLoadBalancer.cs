using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.ObjectPooling;
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

        var selectedEndpoint = m_endpointPool.ActiveEndpointParameters
            .OrderBy(p => p.ActiveConnectionCount)
            .FirstOrDefault();
        return selectedEndpoint.Endpoint.Name;
    }
}