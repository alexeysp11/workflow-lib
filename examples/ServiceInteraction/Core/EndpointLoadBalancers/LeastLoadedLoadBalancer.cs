using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
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

        var selectedEndpoint = m_endpointPool.EndpointParameters
            .Where(p => p.Value != null && p.Value.Endpoint != null && p.Value.Endpoint.Status == EndpointStatus.Active)
            .OrderBy(p => p.Value.SystemLoad)
            .FirstOrDefault();
        return selectedEndpoint.Value.Endpoint.Name;
    }
}