using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ObjectPooling;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BPInitializers;

/// <summary>
/// Business process transition initializer.
/// </summary>
public class BPTransitionInitializer : IBPInitializer
{
    private IBusinessProcessDAL m_businessProcessDAL;
    private TransitionPool m_transitionPool;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public BPTransitionInitializer(
        IBusinessProcessDAL businessProcessDAL,
        TransitionPool transitionPool)
    {
        m_businessProcessDAL = businessProcessDAL;
        m_transitionPool = transitionPool;
    }

    /// <summary>
    /// Performs TransitionPool initialization.
    /// </summary>
    public void Initialize()
    {
        var transitions = m_businessProcessDAL.GetBusinessProcessStateTransitions();
        foreach (var transition in transitions)
        {
            m_transitionPool.AddTransitionToPool(transition);
        }
    }
}