using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ProcPipes;
using WorkflowLib.Models.Business.BusinessDocuments;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;

/// <summary>
/// Parameters for the request processing delegate.
/// </summary>
public class PipeDelegateParams : IPipeDelegateParams
{
    /// <summary>
    /// Workflow instance ID.
    /// </summary>
    public long WorkflowInstanceId { get; set; }

    /// <summary>
    /// Business process state transition ID.
    /// </summary>
    public long BPStateTransitionId { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Initial order.
    /// </summary>
    public InitialOrder InitialOrder { get; set; }
}