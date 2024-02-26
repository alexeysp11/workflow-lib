using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that uses weighted round-robin to select endpoints based on their weights.
/// </summary>
public class WeightedRoundRobinLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
    private readonly object m_lock = new object();
    private readonly System.Random m_random;
    private int m_currentIndex;

    /// <summary>
    /// Initializes a new instance of the WeightedRoundRobinLoadBalancer class with the specified list of endpoints and weights.
    /// </summary>
    public WeightedRoundRobinLoadBalancer(
        EndpointPool endpointPool)
    {
        m_random = new System.Random();
        m_currentIndex = 0;
        m_endpointPool = endpointPool;
    }

    /// <summary>
    /// Get the next endpoint based on weighted round-robin selection.
    /// </summary>
    public string GetNextEndpoint()
    {
        CheckNullReferences();

        var endpointParameters = m_endpointPool.EndpointParameters.Values
            .Where(p => p != null && p.Endpoint != null && p.Endpoint.Status == EndpointStatus.Active)
            .ToArray();
        if (endpointParameters == null || endpointParameters.Length == 0)
            throw new System.Exception("Collection of endpoint parameters is null or empty");
        
        var totalWeight = endpointParameters.Sum(p => p.EndpointWeight);
        var randomWeight = m_random.Next(totalWeight);

        var endpointParameter = endpointParameters.Last();
        lock (m_lock)
        {
            if (m_currentIndex >= endpointParameters.Length)
            {
                // Reset to 0 if currentIndex is out of bounds.
                m_currentIndex = 0;
            }

            int currentIndex = m_currentIndex;
            while (randomWeight >= 0)
            {
                randomWeight -= endpointParameters[currentIndex].EndpointWeight;
                if (randomWeight < 0)
                {
                    m_currentIndex = (currentIndex + 1) % endpointParameters.Length;
                    endpointParameter = endpointParameters[currentIndex];
                    break;
                }
                currentIndex = (currentIndex + 1) % endpointParameters.Length;
            }
        }

        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }
}
