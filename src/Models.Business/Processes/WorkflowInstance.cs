using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.SocialCommunication;
using WorkflowLib.Models.Performance;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// A specific entity (workflow instance) that implements a business process.
    /// </summary>
    public class WorkflowInstance : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstanceContext Context { get; set; }
        
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
        public UserAccount Initiator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<WorkflowInstanceMember> Members { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstance ParentInstance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess BusinessProcess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowTrackingItem Tracking { get; set; }
    }
}