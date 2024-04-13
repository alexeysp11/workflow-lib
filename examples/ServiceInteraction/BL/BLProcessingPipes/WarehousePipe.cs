using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the warehouse service side.
/// </summary>
public class WarehousePipe : AbstractProcessingPipe
{
    private static IImplicitService s_service;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WarehousePipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
    
    /// <summary>
    /// Sets service instance.
    /// </summary>
    public static void SetService(IImplicitService service)
    {
        s_service = service;
    }

    /// <summary>
    /// Method for performing a unit of work as part of a request processing sequence.
    /// </summary>
    public override void Handle(IProcessingPipeDelegateParams parameters)
    {
        var workflowInstanceId = parameters.WorkflowInstanceId;
        var bpstId = parameters.BusinessProcessStateTransitionId;
        s_service.ProcessPreviousService(ref workflowInstanceId, ref bpstId);
        m_function(parameters);
    }
}