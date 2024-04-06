using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the warehouse service side.
/// </summary>
public class WarehousePipe : BaseBLServicePipe
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public WarehousePipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
}