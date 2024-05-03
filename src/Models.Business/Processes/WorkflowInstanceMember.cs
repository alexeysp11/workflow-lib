using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Workflow instance member.
    /// </summary>
    public class WorkflowInstanceMember : BusinessEntityWF, IBusinessEntityWF
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