using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;

/// <summary>
/// Builds the sequence of request processing.
/// </summary>
public class ProcessingPipeBuilder
{
    private System.Action<IProcessingPipeDelegateParams> m_mainFunction;
    private List<System.Type> m_pipeTypes;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ProcessingPipeBuilder(System.Action<IProcessingPipeDelegateParams> mainFunction)
    {
        m_mainFunction = mainFunction;
        m_pipeTypes = new List<System.Type>();
    }

    /// <summary>
    /// Adds an element to the request processing sequence.
    /// </summary>
    public ProcessingPipeBuilder AddPipe(System.Type pipeType)
    {
        // if (!pipeType.IsInstanceOfType(typeof(AbstractProcessingPipe))) 
        //     throw new System.Exception("Incorrect pipe type");
        m_pipeTypes.Add(pipeType);
        return this;
    }

    /// <summary>
    /// Completes the process of constructing the request processing sequence.
    /// </summary>
    public System.Action<IProcessingPipeDelegateParams> Build()
    {
        return CreatePipe(0);
    }

    private System.Action<IProcessingPipeDelegateParams> CreatePipe(int index)
    {
        if (index < m_pipeTypes.Count - 1)
        {
            var childPipeHandle = CreatePipe(index + 1);
            var pipe = (AbstractProcessingPipe) System.Activator.CreateInstance(m_pipeTypes[index], childPipeHandle);
            return pipe.Handle;
        }
        else
        {
            var finalPipe = (AbstractProcessingPipe) System.Activator.CreateInstance(m_pipeTypes[index], m_mainFunction);
            return finalPipe.Handle;
        }
    }
}