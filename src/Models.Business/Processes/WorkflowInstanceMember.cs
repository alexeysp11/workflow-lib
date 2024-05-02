using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowInstanceMember : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstance? Instance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount? UserAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessTask? BusinessTask { get; set; }
    }
}