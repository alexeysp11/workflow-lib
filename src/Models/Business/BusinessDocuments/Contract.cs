using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// 
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ContractType ContractType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Customer> Customers { get; private set; }

        /// <summary>
        /// Our employees.
        /// </summary>
        public ICollection<Employee> Employees { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Company> Companies { get; private set; }

        /// <summary>
        /// Our organization.
        /// </summary>
        public ICollection<Organization> Organizations { get; private set; }
    }
}