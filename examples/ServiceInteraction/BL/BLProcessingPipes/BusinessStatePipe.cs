using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.Routing;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// The pipe responsible for getting the state of the process.
/// </summary>
public class BusinessStatePipe : AbstractProcessingPipe
{
    private static EsbControlPlane s_controlPlane;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public BusinessStatePipe(System.Action<IProcessingPipeDelegateParams> function) : base(function) {}
    
    /// <summary>
    /// Sets ESB service registry.
    /// </summary>
    public static void SetEsbServiceRegistry(EsbControlPlane controlPlane)
    {
        s_controlPlane = controlPlane;
    }

    /// <summary>
    /// Method for performing a unit of work as part of a request processing sequence.
    /// </summary>
    public override void Handle(IProcessingPipeDelegateParams parameters)
    {
        parameters.BusinessProcessStateTransitionId = s_controlPlane.GetNextStateTransitionId(parameters.BusinessProcessStateTransitionId);
        m_function(parameters);
    }
}