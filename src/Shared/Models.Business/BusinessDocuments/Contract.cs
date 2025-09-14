using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;

namespace VelocipedeUtils.Shared.Models.Business.BusinessDocuments
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
        [Obsolete("It's better to use CustomerContract object")]
        public ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// Our employees.
        /// </summary>
        [Obsolete("It's better to use EmployeeContract object")]
        public ICollection<Employee> OurEmployees { get; set; }

        /// <summary>
        /// Companies that could be considered as customers.
        /// </summary>
        [Obsolete("It's better to use CompanyContract object")]
        public ICollection<Company> CustomerCompanies { get; set; }

        /// <summary>
        /// Our organizations.
        /// </summary>
        [Obsolete("It's better to use OrganizationContract object")]
        public ICollection<Organization> OurOrganizations { get; set; }
    }
}