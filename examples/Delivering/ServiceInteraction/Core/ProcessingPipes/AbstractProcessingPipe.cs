namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ProcessingPipes;

/// <summary>
/// Unit of work as part of a request processing sequence.
/// </summary>
public abstract class AbstractProcessingPipe
{
    protected System.Action<IProcessingPipeDelegateParams> m_function;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbstractProcessingPipe(System.Action<IProcessingPipeDelegateParams> function)
    {
        m_function = function;
    }

    /// <summary>
    /// An abstract method for performing a unit of work as part of a request processing sequence.
    /// </summary>
    public abstract void Handle(IProcessingPipeDelegateParams parameters);
}