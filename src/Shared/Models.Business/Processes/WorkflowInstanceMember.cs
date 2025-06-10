using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Processes
{
    /// <summary>
    /// Workflow instance member.
    /// </summary>
    public class WorkflowInstanceMember : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Workflow instance.
        /// </summary>
        public WorkflowInstance? Instance { get; set; }

        /// <summary>
        /// User account.
        /// </summary>
        public UserAccount? UserAccount { get; set; }

        /// <summary>
        /// Business task.
        /// </summary>
        public BusinessTask? BusinessTask { get; set; }
    }
}