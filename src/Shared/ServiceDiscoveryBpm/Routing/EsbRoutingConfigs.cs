using System.Collections.Generic;
using WorkflowLib.Shared.ServiceDiscoveryBpm.ProcPipes;

namespace WorkflowLib.Shared.ServiceDiscoveryBpm.Routing;

/// <summary>
/// Class for EBS routing configuration settings.
/// </summary>
public class EsbRoutingConfigs
{
    /// <summary>
    /// A dictionary where the key is the transition ID, and the value is the delegate to handle the call.
    /// </summary>
    public Dictionary<long, System.Action<IPipeDelegateParams>> Transition2Delegate { get; set; }
}