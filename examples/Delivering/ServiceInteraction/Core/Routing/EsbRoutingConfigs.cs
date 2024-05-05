using System.Collections.Generic;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ProcPipes;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Core.Routing;

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