using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between contract and order.
    /// </summary>
    public class ContractOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Contract.
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
    }
}