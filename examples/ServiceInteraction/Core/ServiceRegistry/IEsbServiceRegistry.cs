using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;

/// <summary>
/// Receives information from the database where the request can be forwarded and uses load balancers to calculate the load.
/// </summary>
public interface IEsbServiceRegistry
{
    /// <summary>
    /// Method for selecting an endpoint as part of an implicit call to the next element of the microservice architecture.
    /// </summary>
    Endpoint GetNextEndpoint(
        EndpointCallType endpointCallType,
        BusinessProcessState currentState,
        BusinessProcessStateTransition stateTransition);

    /// <summary>
    /// Method for selecting an endpoint within an explicit call to an element of a microservice architecture (by endpoint types).
    /// </summary>
    Endpoint GetEndpointExplicit(
        EndpointType endpointTypeFrom,
        EndpointType endpointTypeTo);

    /// <summary>
    /// Returns a workflow instance by its ID.
    /// </summary>
    WorkflowInstance GetWorkflowInstanceById(
        long workflowInstanceId);

    /// <summary>
    /// Initializes a business process instance.
    /// </summary>
    WorkflowInstance CreateInitialWI(
        string processName, 
        string taskName);

    /// <summary>
    /// Create a task for a workflow instance.
    /// </summary>
    BusinessTask CreateBusinessTaskByWI(
        WorkflowInstance workflowInstance,
        string taskName,
        long? transitionId = null,
        bool isNextTask = true);

    /// <summary>
    /// Returns a next task instance for the given state transition ID.
    /// </summary>
    BusinessTask GetNextBusinessTask(
        long workflowInstanceId, 
        long transitionId);
    
    /// <summary>
    /// Returns the next state transition ID of the specified process.
    /// </summary>
    long GetNextStateTransitionId(
        IProcessingPipeDelegateParams parameters);
    
    /// <summary>
    /// Method for preserving the state of the service.
    /// </summary>
    void PreserveServiceState(IProcessingPipeDelegateParams parameters);
    
    /// <summary>
    /// Get a list of all business processes.
    /// </summary>
    List<BusinessProcess> GetBusinessProcesses(long userId);

    /// <summary>
    /// Get a list of workflow instances of the specified business process.
    /// </summary>
    List<WorkflowInstance> GetWorkflowInstances(long businessProcessId);
    
    /// <summary>
    /// Get the status of a workflow instance.
    /// </summary>
    BusinessEntityStatus GetWorkflowInstanceStatus(long workflowInstanceId);
    
    /// <summary>
    /// Get the workflow instance details.
    /// </summary>
    BusinessProcessState GetWorkflowInstanceDetails(long workflowInstanceId);
    
    /// <summary>
    /// Get the current task for a specific workflow instance.
    /// </summary>
    BusinessTask GetCurrentTask(long workflowInstanceId);
}