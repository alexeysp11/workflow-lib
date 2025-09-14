using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.ProcPipes;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the courier service side.
/// </summary>
public class CourierPipe : AbstractProcPipe
{
    private static IImplicitService s_service;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CourierPipe(System.Action<IPipeDelegateParams> function) : base(function) {}
    
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
    public override void Handle(IPipeDelegateParams parameters)
    {
        PipeDelegateParams extendedParameters = (PipeDelegateParams)parameters;
        s_service.MoveWorkflowInstanceNext(extendedParameters);
        m_function(extendedParameters);
    }
}