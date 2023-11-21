using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.SocialCommunication;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Actual business task that was assigned to a specific employee.
    /// </summary>
    public class BusinessTask : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessTask ParentTask { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<BusinessTask> ChildTasks { get; set; }

        /// <summary>
        /// Actual execution time.
        /// </summary>
        public ExecutionTime ActualExecutionTime { get; set; }

        /// <summary>
        /// Estimated execution time.
        /// </summary>
        public ExecutionTime EstimatedExecutionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount Executor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount ExecutorIsEmulation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount ExecutorReplaced { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ExpiredNotificationSent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TaskPriority Priority { get; set; }
        
        /// <summary>
        /// Collection of risks related to the business task.
        /// </summary>
        public ICollection<Risk> Risks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Status of the business task.
        /// </summary>
        public string Status { get; set; }
    }
}
