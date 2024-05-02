using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.SocialCommunication;

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
        /// Actual start time of the operation.
        /// </summary>
        public System.DateTime ActualDateTimeBegin { get; set; }

        /// <summary>
        /// Actual end time of the operation.
        /// </summary>
        public System.DateTime ActualDateTimeEnd { get; set; }

        /// <summary>
        /// Estimated start time of the operation.
        /// </summary>
        public System.DateTime EstimatedDateTimeBegin { get; set; }

        /// <summary>
        /// Estimated end time of the operation.
        /// </summary>
        public System.DateTime EstimatedDateTimeEnd { get; set; }

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