using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;
using WorkflowLib.ServiceDiscoveryBpm.ProcPipes;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;

/// <summary>
/// Pipe which is responsible for processing the request on the customer service side.
/// </summary>
public class CustomerPipe : AbstractProcPipe
{
    private static IImplicitService s_service;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerPipe(System.Action<IPipeDelegateParams> function) : base(function) {}
    
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