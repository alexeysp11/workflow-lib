using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Actual business task that was assigned to a specific employee.
    /// </summary>
    public class BusinessTask : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Parent task.
        /// </summary>
        public BusinessTask ParentTask { get; set; }

        /// <summary>
        /// Child tasks.
        /// </summary>
        public ICollection<BusinessTask> ChildTasks { get; set; }

        /// <summary>
        /// Shows if it is necessary to send notifications if the task is expired and not completed.
        /// </summary>
        public bool ExpiredNotificationSent { get; set; }

        /// <summary>
        /// Shows if the task is launched in the emulation mode.
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// Priority.
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// Subject.
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Status of the business task.
        /// </summary>
        public BusinessTaskStatus Status { get; set; }
    }
}