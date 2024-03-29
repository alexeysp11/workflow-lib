using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Contract.
    /// </summary>
    public class Contract : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Contract type.
        /// </summary>
        public ContractType ContractType { get; set; }

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