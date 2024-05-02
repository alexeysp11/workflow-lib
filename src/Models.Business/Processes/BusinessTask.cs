using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.SocialCommunication;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Actual business task that was assigned to a specific employee.
    /// </summary>
    public class BusinessTask : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Collection of comments associated with the task.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Parent task.
        /// </summary>
        public BusinessTask? ParentTask { get; set; }

        /// <summary>
        /// Child tasks.
        /// </summary>
        public ICollection<BusinessTask> ChildTasks { get; set; }

        /// <summary>
        /// Actual start time of the operation.
        /// </summary>
        public System.DateTime? ActualDateTimeBegin { get; set; }

        /// <summary>
        /// Actual end time of the operation.
        /// </summary>
        public System.DateTime? ActualDateTimeEnd { get; set; }

        /// <summary>
        /// Estimated start time of the operation.
        /// </summary>
        public System.DateTime? EstimatedDateTimeBegin { get; set; }

        /// <summary>
        /// Estimated end time of the operation.
        /// </summary>
        public System.DateTime? EstimatedDateTimeEnd { get; set; }

        /// <summary>
        /// Executor.
        /// </summary>
        public UserAccount? Executor { get; set; }

        /// <summary>
        /// Executor by default in the emulation mode.
        /// </summary>
        public UserAccount? ExecutorIsEmulation { get; set; }

        /// <summary>
        /// Executor after replacement.
        /// </summary>
        public UserAccount? ExecutorReplaced { get; set; }

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
        /// Collection of risks related to the business task.
        /// </summary>
        public ICollection<Risk> Risks { get; set; }

        /// <summary>
        /// Subject.
        /// </summary>
        public string? Subject { get; set; }
        
        /// <summary>
        /// Status of the business task.
        /// </summary>
        public string? Status { get; set; }
    }
}
