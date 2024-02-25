using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// Load balancer that uses weighted round-robin to select endpoints based on their weights.
/// </summary>
public class WeightedRoundRobinLoadBalancer : BaseEndpointLoadBalancer, IEndpointLoadBalancer
{
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

        var endpointParameters = m_endpointPool.EndpointParameters.Values.ToList();
        if (endpointParameters == null || !endpointParameters.Any())
            throw new System.Exception("Collection of endpoint parameters is null or empty");
        
        var totalWeight = endpointParameters.Sum(p => p.EndpointWeight);
        var endpointParameter = SelectWeightedEndpoint(endpointParameters, totalWeight);
        return endpointParameter == null || endpointParameter.Endpoint == null ? string.Empty : endpointParameter.Endpoint.Name;
    }

    /// <summary>
    /// Update the weight of an existing endpoint or add a new endpoint with its weight to the list of weighted endpoints.
    /// </summary>
    public void UpdateEndpoints(string endpoint, int weight)
    {
        CheckNullReferences();

        var existingEndpoint = m_endpointPool.EndpointParameters.FirstOrDefault(p => p.Value.Endpoint.Name == endpoint).Value;
        if (existingEndpoint != null)
        {
            existingEndpoint.EndpointWeight = weight;
        }
        else
        {
            // Add a new endpoint with its weight.
            var newEndpoint = new EndpointCollectionParameter
            {
                Endpoint = new Endpoint
                {
                    Name = endpoint
                },
                EndpointWeight = weight
            };
            m_endpointPool.AddEndpointToPool(newEndpoint);
        }
    }

    /// <summary>
    /// Selects an endpoint according to its weight.
    /// </summary>
    private EndpointCollectionParameter SelectWeightedEndpoint(
        List<EndpointCollectionParameter> endpointParameters, 
        int totalWeight)
    {
        if (endpointParameters.Any(x => x == null))
            throw new System.Exception("Collection of endpoint parameters could not contain null objects");
        
        var randomNumber = m_random.Next(1, totalWeight + 1);
        foreach (var parameter in endpointParameters)
        {
            randomNumber -= parameter.EndpointWeight;
            if (randomNumber <= 0)
            {
                return parameter;
            }
        }
        return endpointParameters.Last();
    }
}
