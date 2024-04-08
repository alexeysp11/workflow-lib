using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the kitchen service side.
/// </summary>
public class KitchenPipe : AbstractProcessingPipe
{
    private static IImplicitService m_service;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public KitchenPipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
    
    /// <summary>
    /// Sets service instance.
    /// </summary>
    public static void SetService(IImplicitService service)
    {
        m_service = service;
    }

    /// <summary>
    /// Method for performing a unit of work as part of a request processing sequence.
    /// </summary>
    public override void Handle(IProcessingPipeDelegateParams parameters)
    {
        m_service.ProcessPreviousService(parameters.WorkflowInstanceId, parameters.BusinessProcessStateTransitionId);
        m_function(parameters);
    }
}