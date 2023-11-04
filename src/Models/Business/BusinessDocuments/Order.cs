using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Order.
    /// </summary>
    public class Order : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Number of the order.
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Timestamp when the order was opened.
        /// </summary>
        public System.DateTime OpenOrderDt { get; set; }
        
        /// <summary>
        /// Timestamp when the order was closed.
        /// </summary>
        public System.DateTime CloseOrderDt { get; set; }
        
        /// <summary>
        /// Customer UID of the order.
        /// </summary>
        public string CustomerUid { get; set; }

        /// <summary>
        /// Customer name of the order.
        /// </summary>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// Company UID of the order.
        /// </summary>
        public string CompanyUid { get; set; }
        
        /// <summary>
        /// Company name of the order.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Products associated with the order.
        /// </summary>
        public ICollection<Product> Products { get; set; }
        
        /// <summary>
        /// Price of the products.
        /// </summary>
        public decimal ProductsPrice { get; set; }
        
        /// <summary>
        /// Additonal price of the order.
        /// </summary>
        public decimal AdditonalPrice { get; set; }

        /// <summary>
        /// Taxes of the order.
        /// </summary>
        public decimal TaxPrice { get; set; }
        
        /// <summary>
        /// Total price of the order.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Payments made within the order.
        /// </summary>
        public ICollection<Payment> Payments { get; set; }
        
        /// <summary>
        /// Shows if the order could be cancelled.
        /// </summary>
        public bool CouldBeCancelled { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public string Status { get; set; }
    }
}