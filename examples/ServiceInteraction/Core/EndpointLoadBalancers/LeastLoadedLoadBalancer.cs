using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// 
/// </summary>
public class LeastLoadedLoadBalancer
{
    private Dictionary<string, int> _loadMap;

    public LeastLoadedLoadBalancer(Dictionary<string, int> initialLoadMap)
    {
        _loadMap = initialLoadMap;
    }

    public string GetLeastLoadedEndpoint()
    {
        if (_loadMap.Count == 0)
            throw new InvalidOperationException("No endpoints available");

        string leastLoadedEndpoint = _loadMap.OrderBy(x => x.Value).First().Key;
        return leastLoadedEndpoint;
    }

    public void UpdateLoad(string endpoint, int load)
    {
        if (_loadMap.ContainsKey(endpoint))
            _loadMap[endpoint] = load;
        else
            _loadMap.Add(endpoint, load);
    }
}