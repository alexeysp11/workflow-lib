using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.BusinessDocuments
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