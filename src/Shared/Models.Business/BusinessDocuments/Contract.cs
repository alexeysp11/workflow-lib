using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Contract.
    /// </summary>
    public class Contract : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Contract type.
        /// </summary>
        public ContractType? ContractType { get; set; }

        /// <summary>
        /// Customers.
        /// </summary>
        public ICollection<Customer> Customers { get; private set; }

        /// <summary>
        /// Our employees.
        /// </summary>
        public ICollection<Employee> OurEmployees { get; private set; }

        /// <summary>
        /// Companies that could be considered as customers.
        /// </summary>
        public ICollection<Company> CustomerCompanies { get; private set; }

        /// <summary>
        /// Our organizations.
        /// </summary>
        public ICollection<Organization> OurOrganizations { get; private set; }
    }
}