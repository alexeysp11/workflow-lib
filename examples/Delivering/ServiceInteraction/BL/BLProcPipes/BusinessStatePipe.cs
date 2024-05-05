using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ProcPipes;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.Routing;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;

/// <summary>
/// The pipe responsible for getting the state of the process.
/// </summary>
public class BusinessStatePipe : AbstractProcPipe
{
    private static EsbControlPlane s_controlPlane;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public BusinessStatePipe(System.Action<IPipeDelegateParams> function) : base(function) {}
    
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
    public override void Handle(IPipeDelegateParams parameters)
    {
        parameters.BPStateTransitionId = s_controlPlane.GetNextStateTransitionId(parameters.BPStateTransitionId);
        m_function(parameters);
    }
}