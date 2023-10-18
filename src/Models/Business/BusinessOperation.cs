using System.Collections.Generic;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// Business operation.
    /// </summary>
    public class BusinessOperation : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Actual execution time.
        /// </summary>
        public ExecutionTime ActualExecutionTime { get; set; }

        /// <summary>
        /// Estimated execution time.
        /// </summary>
        public ExecutionTime EstimatedExecutionTime { get; set; }
        
        /// <summary>
        /// Collection of risks related to the business operation.
        /// </summary>
        public virtual ICollection<Risk> Risks { get; private set; }
        
        /// <summary>
        /// Status of the business operation.
        /// </summary>
        public string Status { get; set; }
    }
}
