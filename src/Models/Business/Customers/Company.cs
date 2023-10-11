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
        public int Id { get; set; }

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
        public string RegistrationNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeEmail { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficePhone { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShippingAddress { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasVatRegistration { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Customer> Employees { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Project> Projects { get; private set; }
    }
}