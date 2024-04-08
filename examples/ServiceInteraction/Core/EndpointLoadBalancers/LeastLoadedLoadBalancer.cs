using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.ObjectPooling;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that selects the least loaded endpoint based on the current load.
/// </summary>
public class LeastLoadedLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    /// <summary>
    /// Initializes a new instance of the LeastLoadedLoadBalancer class with the specified initial load map.
    /// </summary>
    public LeastLoadedLoadBalancer(
        EndpointPool endpointPool)
    {
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the least loaded endpoint based on the current load.
    /// </summary>
    public string GetNextEndpoint()
    {
        CheckNullReferences();

        var selectedEndpoint = m_endpointPool.ActiveEndpointParameters
            .OrderBy(p => p.SystemLoad)
            .FirstOrDefault();
        return selectedEndpoint.Endpoint.Name;
    }
}