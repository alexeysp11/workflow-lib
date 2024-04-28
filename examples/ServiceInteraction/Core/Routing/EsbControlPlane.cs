using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.ServiceInteraction.Models;

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
    /// Returns the next state transition ID of the specified process.
    /// </summary>
    public long GetNextStateTransitionId(IProcessingPipeDelegateParams parameters)
    {
        return m_esbServiceRegistry.GetNextStateTransitionId(parameters);
    }

    /// <summary>
    /// Get a list of all business processes.
    /// </summary>
    public List<BusinessProcess> GetBusinessProcesses(long userId)
    {
        return new List<BusinessProcess>();
    }

    /// <summary>
    /// Get a list of workflow instances of the specified business process.
    /// </summary>
    public List<WorkflowInstance> GetWorkflowInstances(long businessProcessId)
    {
        return new List<WorkflowInstance>();
    }
    
    /// <summary>
    /// Get the status of a workflow instance.
    /// </summary>
    public string GetWorkflowInstanceStatus(long workflowInstanceId)
    {
        return BusinessEntityStatus.Active.ToString();
    }
    
    /// <summary>
    /// Get the workflow instance details.
    /// </summary>
    public BusinessProcessState GetWorkflowInstanceDetails(long workflowInstanceId)
    {
        return new BusinessProcessState();
    }
    
    /// <summary>
    /// Get the current task for a specific workflow instance.
    /// </summary>
    public BusinessTask GetCurrentTask(long workflowInstanceId)
    {
        return new BusinessTask();
    }

    /// <summary>
    /// Method for preserving the state of the service.
    /// </summary>
    public void PreserveServiceState(IProcessingPipeDelegateParams parameters)
    {
        m_esbServiceRegistry.PreserveServiceState(parameters);
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void MoveWorkflowInstanceNext(IProcessingPipeDelegateParams parameters)
    {
        var transition2Delegate = m_esbRoutingConfigs.Transition2Delegate;
        if (transition2Delegate == null)
            throw new System.InvalidOperationException("The dictionary that binds transition ID to delegate could not be null");
        
        var workflowInstanceId = parameters.WorkflowInstanceId;
        var transitionId = parameters.BusinessProcessStateTransitionId;

        // Get endpoint call ID.
        if (!transition2Delegate.ContainsKey(transitionId))
            throw new System.Exception($"Specified transition ID does not exist in the dictionary (transition ID = {transitionId})");
        var function = transition2Delegate[transitionId];
        if (function == null)
            throw new System.Exception("ESB delegate could not be null");
        
        function(parameters);
    }
}