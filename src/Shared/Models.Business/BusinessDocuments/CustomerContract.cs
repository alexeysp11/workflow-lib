using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    public class CustomerContract : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Customer.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// Contract.
        /// </summary>
        public Contract? Contract { get; set; }
    }
}