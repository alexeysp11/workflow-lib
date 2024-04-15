using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Routing;

/// <summary>
/// Provides functionality for the service mesh control plane (receives information where to redirect the process 
/// and causes a redirect using EsbProxies).
/// </summary>
public class EsbControlPlane
{
    private EsbRoutingConfigs m_esbRoutingConfigs;
    private IEsbServiceRegistry m_esbServiceRegistry;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public EsbControlPlane(
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
    /// Returns the next state transition ID of the specified process.
    /// </summary>
    public long GetNextStateTransitionId(IProcessingPipeDelegateParams parameters)
    {
        return m_esbServiceRegistry.GetNextStateTransitionId(parameters);
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
        var esbRoutingEntries = m_esbRoutingConfigs.EsbRoutingEntries;
        if (esbRoutingEntries == null)
            throw new System.Exception("ESB routing entries dictionary could not be null");
        var transition2EdpointCall = m_esbRoutingConfigs.Transition2EdpointCallDictionary;
        if (transition2EdpointCall == null)
            throw new System.Exception("Transition ID to endpoint ID dictionary could not be null");

        var workflowInstanceId = parameters.WorkflowInstanceId;
        var transitionId = parameters.BusinessProcessStateTransitionId;

        // Get endpoint call ID.
        if (!transition2EdpointCall.ContainsKey(transitionId))
            throw new System.Exception($"Specified transition ID does not exist in the dictionary: transitionId = {transitionId}");
        var edpointCallId = transition2EdpointCall[transitionId];
        
        // Get the delegate from the dictionary depending on the edpointCallId value.
        if (!esbRoutingEntries.ContainsKey(edpointCallId))
            throw new System.Exception($"Specified edpoint call ID does not exist in the ESB routing entries dictionary: edpointCallId = {edpointCallId}");
        var function = esbRoutingEntries[edpointCallId];
        if (function == null)
            throw new System.Exception("ESB delegate could not be null");
        
        function(parameters);
    }
}