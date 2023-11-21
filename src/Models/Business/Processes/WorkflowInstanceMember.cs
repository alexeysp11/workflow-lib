using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowInstanceMember : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstance Instance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount UserAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessTask BusinessTask { get; set; }
    }
}