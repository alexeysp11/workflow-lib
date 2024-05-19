using System.Collections.Generic;
using WorkflowLib.Models.Business.Customers;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product offering.
    /// </summary>
    public class ProductOffering : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// Supplier (comany).
        /// </summary>
        public Company? CompanySupplier { get; set; }

        /// <summary>
        /// Supplier (customer).
        /// </summary>
        public Customer? CustomerSupplier { get; set; }

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
        /// Actual price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }
    }
}