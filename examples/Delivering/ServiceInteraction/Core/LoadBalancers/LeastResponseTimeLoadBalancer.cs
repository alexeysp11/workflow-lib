using System.Collections.Generic;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ObjectPooling;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Core.LoadBalancers;

/// <summary>
/// Load balancer that selects the endpoint with the least response time.
/// </summary>
public class LeastResponseTimeLoadBalancer : BaseEsbLoadBalancer, IEsbLoadBalancer
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
