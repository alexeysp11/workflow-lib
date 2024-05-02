using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// Company (usually related to the customer).
    /// </summary>
    public class Company : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Registration number of the company.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// VAT number of the company.
        /// </summary>
        public string VatNumber { get; set; }
        
        /// <summary>
        /// CRM role type.
        /// </summary>
        public CRMRoleType CRMRoleType { get; set; }

        /// <summary>
        /// Contact of the company.
        /// </summary>
        public Contact? Contact { get; set; }

        /// <summary>
        /// Address of the company.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Shipping address of the company.
        /// </summary>
        public string? ShippingAddress { get; set; }

        /// <summary>
        /// Does the company have VAT registration.
        /// </summary>
        public bool HasVatRegistration { get; set; }

        /// <summary>
        /// Collection of the employees of the company.
        /// </summary>
        public ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// Collection of the projects related to the company.
        /// </summary>
        public ICollection<Project> Projects { get; set; }
        
        /// <summary>
        /// Contracts.
        /// </summary>
        public ICollection<Contract> Contracts { get; private set; }
    }
}