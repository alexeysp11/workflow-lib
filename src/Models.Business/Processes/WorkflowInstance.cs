using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Gets or sets the business process associated with this workflow instance.
        /// </summary>
        public BusinessProcess BusinessProcess { get; set; }
        
        /// <summary>
        /// Workflow instance context.
        /// </summary>
        [NotMapped]
        public WorkflowInstanceContext? Context { get; set; }
        
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
        /// Initiator.
        /// </summary>
        public UserAccount? Initiator { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the workflow instance is in emulation mode.
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// Collection of workflow instance members.
        /// </summary>
        public ICollection<WorkflowInstanceMember> Members { get; set; }

        /// <summary>
        /// Gets or sets the parent workflow instance if applicable.
        /// </summary>
        public WorkflowInstance? ParentInstance { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}