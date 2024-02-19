using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// 
/// </summary>
public class RoundRobinLoadBalancer
{
    private List<string> _endpoints;
    private int _currentIndex;

    /// <summary>
    /// 
    /// </summary>
    public RoundRobinLoadBalancer(List<string> endpoints)
    {
        _endpoints = endpoints;
        _currentIndex = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public string GetNextEndpoint()
    {
        if (_endpoints.Count == 0)
            throw new System.InvalidOperationException("No endpoints available");

        string endpoint = _endpoints[_currentIndex];
        _currentIndex = (_currentIndex + 1) % _endpoints.Count;
        return endpoint;
    }
}