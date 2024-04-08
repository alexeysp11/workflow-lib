using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.ObjectPooling;
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

        var selectedEndpoint = m_endpointPool.ActiveEndpointParameters
            .OrderBy(p => p.ResponseTime)
            .FirstOrDefault();
        return selectedEndpoint.Endpoint.Name;
    }
}
