using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Routing;

/// <summary>
/// Class for EBS routing configuration settings.
/// </summary>
public class EbsRoutingConfigs
{
    /// <summary>
    /// A dictionary where the key is the endpoint call ID, and the value is the delegate to handle the call.
    /// </summary>
    public Dictionary<long, System.Action<long, long, long>> EbsRoutingEntry { get; set; }
}