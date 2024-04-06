using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;

/// <summary>
/// Parameters for the request processing delegate.
/// </summary>
public struct ValueProcessingPipeDelegateParams : IProcessingPipeDelegateParams
{
    /// <summary>
    /// Workflow instance ID.
    /// </summary>
    public long WorkflowInstanceId { get; set; }

    /// <summary>
    /// Business process state transition ID.
    /// </summary>
    public long BusinessProcessStateTransitionId { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    public long UserId { get; set; }
}