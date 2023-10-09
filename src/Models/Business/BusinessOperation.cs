using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Business
{
    public class BusinessOperation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExecutionTime ActualExecutionTime { get; set; }
        public ExecutionTime EstimatedExecutionTime { get; set; }
        public string Status { get; set; }
    }
}
