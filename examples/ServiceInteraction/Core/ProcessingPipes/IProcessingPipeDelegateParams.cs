namespace WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

/// <summary>
/// Parameters for the request processing delegate.
/// </summary>
public interface IProcessingPipeDelegateParams
{
    /// <summary>
    /// Workflow instance ID.
    /// </summary>
    long WorkflowInstanceId { get; set; }

    /// <summary>
    /// Business process state transition ID.
    /// </summary>
    long BusinessProcessStateTransitionId { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    long UserId { get; set; }
}