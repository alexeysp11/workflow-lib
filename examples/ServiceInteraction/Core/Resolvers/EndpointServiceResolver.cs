using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

/// <summary>
/// This class provides a choice of services to call within the microservice architecture.
/// </summary>
public class EndpointServiceResolver
{
    private EndpointDAL m_endpointDAL;
    private BusinessProcessDAL m_businessProcessDAL;
    private EndpointSelectionParameter m_endpointSelectionParameter;
    private IEndpointLoadBalancer m_loadBalancer;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public EndpointServiceResolver(
        EndpointDAL endpointDAL,
        BusinessProcessDAL businessProcessDAL,
        EndpointSelectionParameter endpointSelectionParameter, 
        IEndpointLoadBalancer loadBalancer)
    {
        m_endpointDAL = endpointDAL;
        m_businessProcessDAL = businessProcessDAL;
        m_endpointSelectionParameter = endpointSelectionParameter;
        m_loadBalancer = loadBalancer;
    }

    /// <summary>
    /// Method for selecting an endpoint as part of an implicit call to the next element of the microservice architecture.
    /// </summary>
    public Endpoint GetNextEndpoint(
        EndpointCallType endpointCallType,
        BusinessProcessState currentState,
        BusinessProcessStateTransition stateTransition)
    {
        if (endpointCallType == null) 
            throw new System.Exception("Endpoint call type could not be null");
        if (currentState == null || currentState.Id == null) 
            throw new System.Exception("Current state could not be null or undefined");
        
        return m_endpointDAL.GetEndpoint(x => x.EndpointCallType == endpointCallType
            && x.BusinessProcessState.Id == currentState.Id
            && (stateTransition == null || x.BusinessProcessStateTransition.Id == stateTransition.Id));
    }

    /// <summary>
    /// Method for selecting an endpoint within an explicit call to an element of a microservice architecture (by endpoint types).
    /// </summary>
    public Endpoint GetEndpointExplicit(
        EndpointType endpointTypeFrom, 
        EndpointType endpointTypeTo)
    {
        if (endpointTypeFrom == null || endpointTypeFrom.Id == null) 
            throw new System.Exception("Source endpoint type could not be null");
        if (endpointTypeTo == null || endpointTypeTo.Id == null) 
            throw new System.Exception("Destination endpoint type could not be null");

        return m_endpointDAL.GetEndpoint(x => x.EndpointTypeFrom.Id == endpointTypeFrom.Id
            && x.EndpointTypeTo.Id == endpointTypeTo.Id);
    }

    /// <summary>
    /// Returns a workflow instance by its ID.
    /// </summary>
    public WorkflowInstance GetWorkflowInstanceById(long id)
    {
        if (id <= 0)
            throw new System.ArgumentOutOfRangeException(nameof(id), $"Workflow instance ID should be positive, but '{id}' was passed");
        
        var workflowInstance = m_businessProcessDAL.GetWorkflowInstanceById(id);
        if (workflowInstance == null)
            throw new System.Exception($"Workflow instance with the specified ID does not exist (id: {id})");
        return workflowInstance;
    }

    /// <summary>
    /// Initializes a business process instance.
    /// </summary>
    public WorkflowInstance CreateBusinessProcessInstance(string processName, string taskName)
    {
        if (string.IsNullOrEmpty(processName))
            throw new System.ArgumentNullException(nameof(processName));
        
        // Get business process.
        var process = m_businessProcessDAL.GetBusinessProcessByName(processName);
        if (process == null)
            throw new System.Exception($"Business process could not be found by name: {processName}");

        // Create workflow instance.
        var workflowInstance = m_businessProcessDAL.CreateWorkflowInstance(process);
        if (workflowInstance == null)
            throw new System.Exception($"Workflow instance is not created (processName: {processName})");
        
        CreateTaskWorkflowInstance(workflowInstance, taskName);
        
        return workflowInstance;
    }

    /// <summary>
    /// Create a task for a workflow instance.
    /// </summary>
    public void CreateTaskWorkflowInstance(WorkflowInstance workflowInstance, string taskName)
    {
        if (workflowInstance == null)
            throw new System.ArgumentNullException(nameof(workflowInstance));
        if (string.IsNullOrEmpty(taskName))
            throw new System.ArgumentNullException(nameof(taskName));
        
        // Create business task.
        string taskSubject = $"{workflowInstance.Id}. {taskName} ({workflowInstance.Name})";
        var businessTask = m_businessProcessDAL.CreateBusinessTask(taskName, taskSubject);
        if (businessTask == null)
            throw new System.Exception($"Business task is not created (processName: workflowInstance.Id: {workflowInstance.Id}, taskName: {taskName})");

        // Create workflow tracking item.
        var workflowTrackingItem = m_businessProcessDAL.CreateWorkflowTrackingItem(workflowInstance, businessTask);
        if (workflowTrackingItem == null)
            throw new System.Exception($"Workflow tracking item is not created (processName: workflowInstance.Id: {workflowInstance.Id}, taskName: {taskName})");
    }
}