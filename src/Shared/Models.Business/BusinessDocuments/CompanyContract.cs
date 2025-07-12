using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    public class CompanyContract : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Contract.
        /// </summary>
        public Contract? Contract { get; set; }
    }
}