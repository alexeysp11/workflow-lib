namespace WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

/// <summary>
/// Unit of work as part of a request processing sequence.
/// </summary>
public abstract class AbstractProcessingPipe
{
    protected System.Action<long, long, long> m_function;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbstractProcessingPipe(System.Action<long, long, long> function)
    {
        m_function = function;
    }

    /// <summary>
    /// An abstract method for performing a unit of work as part of a request processing sequence.
    /// </summary>
    public abstract void Handle(long workflowInstanceId, long businessStateId, long userId);
}