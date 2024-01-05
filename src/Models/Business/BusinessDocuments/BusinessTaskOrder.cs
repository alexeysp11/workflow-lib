using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between business task and order.
    /// </summary>
    public class BusinessTaskOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Business task.
        /// </summary>
        public BusinessTask BusinessTask { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
    }
}