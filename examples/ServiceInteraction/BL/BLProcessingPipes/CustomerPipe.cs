using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the customer service side.
/// </summary>
public class CustomerPipe : BaseBLServicePipe
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerPipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
}