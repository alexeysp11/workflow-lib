using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Routing;

/// <summary>
/// Provides functionality for the service mesh control plane (receives information where to redirect the process 
/// and causes a redirect using EsbProxies).
/// </summary>
public class EsbServiceMeshControlPlane
{
    private EsbRoutingConfigs m_esbRoutingConfigs;
    private IEsbServiceRegistry m_esbServiceRegistry;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public EsbServiceMeshControlPlane(
        EsbRoutingConfigs esbRoutingConfigs,
        IEsbServiceRegistry esbServiceRegistry)
    {
        m_esbRoutingConfigs = esbRoutingConfigs;
        m_esbServiceRegistry = esbServiceRegistry;
    }

    /// <summary>
    /// Load the process in its current state.
    /// </summary>
    public void LoadCurrentState(long workflowInstanceId, long userId)
    {
        var currentStateId = GetCurrentStateId(workflowInstanceId, userId);
    }

    /// <summary>
    /// Load a process in a specified state.
    /// </summary>
    public void LoadSpecifiedState(long workflowInstanceId, long businessStateId, long userId)
    {
        // 
    }

    /// <summary>
    /// Returns the current state ID of the specified process.
    /// </summary>
    public long GetCurrentStateId(long workflowInstanceId, long userId)
    {
        return 0;
    }

    /// <summary>
    /// Make changes related to the current state within the current process.
    /// </summary>
    public void PostCurrentState(long workflowInstanceId, long userId)
    {
        // 
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public void CallNextService(long workflowInstanceId, long transitionId)
    {
        // 
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void ProcessPreviousService(IProcessingPipeDelegateParams parameters)
    {
        var esbRoutingEntries = m_esbRoutingConfigs.EsbRoutingEntry;
        if (esbRoutingEntries == null)
            throw new System.Exception("ESB routing entries dictionary could not be null");
        
        var workflowInstanceId = parameters.WorkflowInstanceId;
        var transitionId = parameters.BusinessProcessStateTransitionId;
        
        System.Action<IProcessingPipeDelegateParams> function;
        long key;
        switch (transitionId)
        {
            case 0:
                key = 4;
                break;
            default:
                throw new System.Exception($"Incorrect parameters: workflowInstanceId: {workflowInstanceId}, transitionId: {transitionId}");
        }

        if (!esbRoutingEntries.ContainsKey(key))
            throw new System.Exception($"Specified key does not exist in the ESB routing entries dictionary: key = {key}");
        function = esbRoutingEntries[key];
        if (function == null)
            throw new System.Exception("ESB delegate could not be null");
        
        function(parameters);
    }
}