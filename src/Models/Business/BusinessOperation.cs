using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessOperation
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
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
        public string Status { get; set; }
    }
}
