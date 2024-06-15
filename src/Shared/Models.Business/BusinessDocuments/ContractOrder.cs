using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between contract and order.
    /// </summary>
    public class ContractOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Contract.
        /// </summary>
        public Contract? Contract { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order? Order { get; set; }
    }
}