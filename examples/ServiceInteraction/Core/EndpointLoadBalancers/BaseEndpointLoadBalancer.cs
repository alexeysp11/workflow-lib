using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// A base abstract class that implements a load balancer.
/// </summary>
public abstract class BaseEndpointLoadBalancer
{
    private protected EndpointPool m_endpointPool;

    /// <summary>
    /// Remove the specified endpoint from the collection.
    /// </summary>
    public virtual void RemoveEndpoint(string endpoint)
    {
        CheckNullReferences();

        var endpointToRemove = m_endpointPool.EndpointParameters.FirstOrDefault(p => p.Value.Endpoint.Name == endpoint);
        if (endpointToRemove.Value != null)
        {
            m_endpointPool.RemoveEndpointFromPool(endpointToRemove.Key);
        }
    }

    /// <summary>
    /// Checks that there are no null references.
    /// </summary>
    private protected void CheckNullReferences()
    {
        if (m_endpointPool == null)
            throw new System.ArgumentNullException(nameof(m_endpointPool));
        
        var endpointParameters = m_endpointPool.EndpointParameters;
        if (endpointParameters == null || endpointParameters.Count == 0)
            throw new InvalidOperationException("No endpoints available");
    }
}