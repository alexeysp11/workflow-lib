namespace WorkflowLib.Shared.ServiceDiscoveryBpm.ProcPipes;

/// <summary>
/// Parameters for the request processing delegate.
/// </summary>
public interface IPipeDelegateParams
{
    /// <summary>
    /// Workflow instance ID.
    /// </summary>
    long WorkflowInstanceId { get; set; }

    /// <summary>
    /// Business process state transition ID.
    /// </summary>
    long BPStateTransitionId { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    long UserId { get; set; }
}