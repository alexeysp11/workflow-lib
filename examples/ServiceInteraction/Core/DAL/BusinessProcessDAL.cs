using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.DAL;

/// <summary>
/// A class at the DAL level that performs operations related to business processes in the database.
/// </summary>
public class BusinessProcessDAL
{
    private DbContextOptions<ServiceInteractionContext> m_contextOptions { get; set; }

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
        
        using var context = new ServiceInteractionContext(m_contextOptions);
        var process = context.BusinessProcesses.FirstOrDefault(x => x.Name == processName);
        return process;
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
        
        using var context = new ServiceInteractionContext(m_contextOptions);
        context.BusinessProcesses.Attach(process);
        context.WorkflowInstances.Add(workflowInstance);
        context.SaveChanges();

        return workflowInstance;
    }

    /// <summary>
    /// Creates a business task.
    /// </summary>
    public BusinessTask CreateBusinessTask(
        string taskName,
        string taskSubject,
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
            ParentTask = parentTask,
            Priority = priority,
            IsEmulation = isEmulation
        };
        
        using var context = new ServiceInteractionContext(m_contextOptions);
        if (parentTask != null)
            context.BusinessTasks.Attach(parentTask);
        context.BusinessTasks.Add(businessTask);
        context.SaveChanges();

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
        
        using var context = new ServiceInteractionContext(m_contextOptions);
        context.WorkflowInstances.Attach(workflowInstance);
        context.BusinessTasks.Attach(activeTask);
        context.WorkflowTrackingItems.Add(workflowTrackingItem);
        context.SaveChanges();

        return workflowTrackingItem;
    }
}