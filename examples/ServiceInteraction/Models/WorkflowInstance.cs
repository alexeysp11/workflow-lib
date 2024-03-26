using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// A specific entity (workflow instance) that implements a business process.
    /// </summary>
    public class WorkflowInstance : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstance ParentInstance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess BusinessProcess { get; set; }
    }
}