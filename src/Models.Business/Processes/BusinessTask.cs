using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.SocialCommunication;
using WorkflowLib.Models.Business.RiskManagement;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Actual business task that was assigned to a specific employee.
    /// </summary>
    public class BusinessTask : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// Subject.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Parent task.
        /// </summary>
        public BusinessTask? ParentTask { get; set; }

        /// <summary>
        /// Child tasks.
        /// </summary>
        public ICollection<BusinessTask> ChildTasks { get; set; }
        
        /// <summary>
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }

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
        /// Priority.
        /// </summary>
        public TaskPriority Priority { get; set; }
        
        /// <summary>
        /// Business process state.
        /// </summary>
        public BusinessProcessState? BusinessProcessState { get; set; }
        
        /// <summary>
        /// Collection of risks related to the business task.
        /// </summary>
        public ICollection<Risk> Risks { get; set; }

        /// <summary>
        /// Collection of comments associated with the task.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Shows if it is necessary to send notifications if the task is expired and not completed.
        /// </summary>
        public bool ExpiredNotificationSent { get; set; }

        /// <summary>
        /// Shows if the task is launched in the emulation mode.
        /// </summary>
        public bool IsEmulation { get; set; }
        
        /// <summary>
        /// Status of the business task.
        /// </summary>
        public BusinessTaskStatus Status { get; set; }
    }
}