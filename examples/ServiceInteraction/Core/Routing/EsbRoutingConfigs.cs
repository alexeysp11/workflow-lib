using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Routing;

/// <summary>
/// Class for EBS routing configuration settings.
/// </summary>
public class EsbRoutingConfigs
{
    /// <summary>
    /// A dictionary where the key is the endpoint call ID, and the value is the delegate to handle the call.
    /// </summary>
    public Dictionary<long, System.Action<IProcessingPipeDelegateParams>> EsbRoutingEntry { get; set; }
}