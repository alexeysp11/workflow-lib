using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// Company (usually related to the customer).
    /// </summary>
    public class Company
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
        /// Contact of the company.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Address of the company.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Shipping address of the company.
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Does the company have VAT registration.
        /// </summary>
        public bool HasVatRegistration { get; set; }

        /// <summary>
        /// Collection of the employees of the company.
        /// </summary>
        public ICollection<Customer> Employees { get; set; }

        /// <summary>
        /// Collection of the projects related to the company.
        /// </summary>
        public ICollection<Project> Projects { get; set; }
    }
}