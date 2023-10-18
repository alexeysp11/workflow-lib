using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasVatRegistration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Customer> Employees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Project> Projects { get; set; }
    }
}