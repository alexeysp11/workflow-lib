using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the kitchen service side.
/// </summary>
public class KitchenPipe : BaseBLServicePipe
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public KitchenPipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
}