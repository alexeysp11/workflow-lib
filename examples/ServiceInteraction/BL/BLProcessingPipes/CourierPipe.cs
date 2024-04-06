using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the courier service side.
/// </summary>
public class CourierPipe : BaseBLServicePipe
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public CourierPipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
}