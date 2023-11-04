using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Customers;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product offering.
    /// </summary>
    public class ProductOffering : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Supplier (comany).
        /// </summary>
        public Company CompanySupplier { get; set; }

        /// <summary>
        /// Supplier (customer).
        /// </summary>
        public Customer CustomerSupplier { get; set; }

        /// <summary>
        /// Beneficiaries (comanies).
        /// </summary>
        public ICollection<Company> CompanyBeneficiaries { get; set; }

        /// <summary>
        /// Beneficiaries (customers).
        /// </summary>
        public ICollection<Customer> CustomerBeneficiaries { get; set; }

        /// <summary>
        /// Products.
        /// </summary>
        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Date created.
        /// </summary>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Date from.
        /// </summary>
        public System.DateTime DateFrom { get; set; }

        /// <summary>
        /// Date to.
        /// </summary>
        public System.DateTime DateTo { get; set; }

        /// <summary>
        /// Actual price.
        /// </summary>
        public decimal Price { get; set; }
    }
}