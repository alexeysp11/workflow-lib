using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.BL.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL.DAL;

/// <summary>
/// A class at the DAL level that performs operations related to business processes in the database.
/// </summary>
public class BusinessProcessDAL : IBusinessProcessDAL
{
    private object m_object = new object();
    private DbContextOptions<ServiceInteractionContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public BusinessProcessDAL(
        DbContextOptions<ServiceInteractionContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }

    /// <summary>
    /// Returns the business process by its name.
    /// </summary>
    public BusinessProcess GetBusinessProcessByName(string processName)
    {
        if (string.IsNullOrEmpty(processName))
            throw new System.ArgumentNullException(nameof(processName));
        
        BusinessProcess process;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            process = context.BusinessProcesses.FirstOrDefault(x => x.Name == processName);
        }
        return process;
    }

    /// <summary>
    /// Returns a workflow instance by its ID.
    /// </summary>
    public WorkflowInstance GetWorkflowInstanceById(long id)
    {
        WorkflowInstance workflowInstance;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            workflowInstance = context.WorkflowInstances.FirstOrDefault(x => x.Id == id);
        }
        return workflowInstance;
    }

    /// <summary>
    /// Creates a workflow instance.
    /// </summary>
    public WorkflowInstance CreateWorkflowInstance(
        BusinessProcess process,
        WorkflowInstance parentInstance = null,
        bool isEmulation = false)
    {
        if (process == null)
            throw new System.ArgumentNullException(nameof(process));
        
        var workflowInstance = new WorkflowInstance
        {
            Uid = System.Guid.NewGuid().ToString(),
            Name = $"Workflow instance of BusinessProcess #{process.Id} (name: '{process.Name}') - {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}",
            BusinessProcess = process,
            ParentInstance = parentInstance,
            IsEmulation = isEmulation
        };
        
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            context.BusinessProcesses.Attach(process);
            context.WorkflowInstances.Add(workflowInstance);
            context.SaveChanges();
        }

        return workflowInstance;
    }

    /// <summary>
    /// Creates a business task.
    /// </summary>
    public BusinessTask CreateBusinessTask(
        string taskName,
        string taskSubject,
        BusinessProcessState? processState = null,
        BusinessTask parentTask = null,
        TaskPriority priority = TaskPriority.Low,
        bool isEmulation = false)
    {
        if (string.IsNullOrEmpty(taskName))
            throw new System.ArgumentNullException(nameof(taskName));
        
        var businessTask = new BusinessTask
        {
            Uid = System.Guid.NewGuid().ToString(),
            Name = taskName,
            Subject = taskSubject,
            BusinessProcessState = processState,
            ParentTask = parentTask,
            Priority = priority,
            IsEmulation = isEmulation
        };
        
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            if (parentTask != null)
                context.BusinessTasks.Attach(parentTask);
            if (processState != null)
                context.BusinessProcessStates.Attach(processState);
            context.BusinessTasks.Add(businessTask);
            context.SaveChanges();
        }

        return businessTask;
    }

    /// <summary>
    /// Creates a workflow tracking item.
    /// </summary>
    public WorkflowTrackingItem CreateWorkflowTrackingItem(
        WorkflowInstance workflowInstance,
        BusinessTask activeTask)
    {
        if (workflowInstance == null)
            throw new System.ArgumentNullException(nameof(workflowInstance));
        if (activeTask == null)
            throw new System.ArgumentNullException(nameof(activeTask));
        
        var workflowTrackingItem = new WorkflowTrackingItem
        {
            WorkflowInstance = workflowInstance,
            ActiveTask = activeTask
        };
        
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            context.WorkflowInstances.Attach(workflowInstance);
            context.BusinessTasks.Attach(activeTask);
            context.WorkflowTrackingItems.Add(workflowTrackingItem);
            context.SaveChanges();
        }

        return workflowTrackingItem;
    }
    
    /// <summary>
    /// Returns the next state of the business process by transition ID.
    /// </summary>
    public BusinessProcessState GetBPStateByTransition(
        long transitionId, 
        bool isNextTask = true)
    {
        if (transitionId <= 0)
            throw new System.ArgumentOutOfRangeException(nameof(transitionId), $"State transition ID should be positive, but '{transitionId}' was passed");

        BusinessProcessState processState;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            processState = context.BusinessProcessStateTransitions
                .Where(x => x.Id == transitionId)
                .Select(x => isNextTask ? x.ToState : x.FromState)
                .FirstOrDefault();
        }
        return processState;
    }
    
    /// <summary>
    /// Returns a task instance for the given workflow instance ID and state transition ID.
    /// </summary>
    public BusinessTask GetNextBusinessTask(
        long workflowInstanceId, 
        long transitionId)
    {
        if (workflowInstanceId <= 0)
            throw new System.ArgumentOutOfRangeException(nameof(workflowInstanceId), $"Workflow instance ID should be positive, but '{workflowInstanceId}' was passed");
        if (transitionId <= 0)
            throw new System.ArgumentOutOfRangeException(nameof(transitionId), $"State transition ID should be positive, but '{transitionId}' was passed");

        BusinessTask businessTask;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            businessTask = 
                (
                    from btask in context.BusinessTasks
                    join transition in context.BusinessProcessStateTransitions
                        on btask.BusinessProcessState.Id equals transition.ToState.Id
                    join wfTrackingItem in context.WorkflowTrackingItems
                        on btask.Id equals wfTrackingItem.ActiveTask.Id
                    where transition.Id == transitionId && wfTrackingItem.WorkflowInstance.Id == workflowInstanceId
                    select btask
                ).FirstOrDefault();
        }
        return businessTask;
    }

    /// <summary>
    /// Get all business process state transitions.
    /// </summary>
    public IList<BusinessProcessStateTransition> GetBusinessProcessStateTransitions()
    {
        IList<BusinessProcessStateTransition> result;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            result = context.BusinessProcessStateTransitions.Include(x => x.Previous).ToList();
        }
        return result;
    }

    /// <summary>
    /// Get a list of all business processes.
    /// </summary>
    public List<BusinessProcess> GetBusinessProcesses(long userId)
    {
        List<BusinessProcess> result;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            result = context.BusinessProcesses.ToList();
        }
        return result;
    }

    /// <summary>
    /// Get a list of workflow instances of the specified business process.
    /// </summary>
    public List<WorkflowInstance> GetWorkflowInstances(long businessProcessId)
    {
        List<WorkflowInstance> result;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            result = context.WorkflowInstances
                .Where(x => x.BusinessProcess != null && x.BusinessProcess.Id == businessProcessId)
                .ToList();
        }
        return result;
    }
    
    /// <summary>
    /// Get the status of a workflow instance.
    /// </summary>
    public BusinessEntityStatus GetWorkflowInstanceStatus(long workflowInstanceId)
    {
        BusinessEntityStatus result;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            result = (BusinessEntityStatus) (context.WorkflowInstances.FirstOrDefault(x => x.Id == workflowInstanceId).BusinessEntityStatus);
        }
        return result;
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
        BusinessTask result;
        lock (m_object)
        {
            using var context = new ServiceInteractionContext(m_contextOptions);
            result = (BusinessTask) (context.WorkflowTrackingItems
                .FirstOrDefault(x => x.ActiveTask != null && x.WorkflowInstance != null && x.WorkflowInstance.Id == workflowInstanceId)
                .ActiveTask);
        }
        return result;
    }
}