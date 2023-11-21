using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// An abstract class that stores the process context (it is intended to implement this class 
    /// specifically for a specific business process at the client application level).
    /// </summary>
    public abstract class WorkflowInstanceContext : BusinessEntityWF, IBusinessEntityWF
    {
    }
}