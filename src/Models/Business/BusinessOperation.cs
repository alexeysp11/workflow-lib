using System.Collections.Generic;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessOperation : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ExecutionTime ActualExecutionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExecutionTime EstimatedExecutionTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Risk> Risks { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
