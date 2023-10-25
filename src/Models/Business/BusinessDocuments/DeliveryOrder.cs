using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Delivery order.
    /// </summary>
    public class DeliveryOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Name of the delivery order.
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Timestamp when the delivery order was created.
        /// </summary>
        public System.DateTime OpenOrderDt { get; set; }
        
        /// <summary>
        /// Timestamp when the delivery order was closed.
        /// </summary>
        public System.DateTime CloseOrderDt { get; set; }
        
        /// <summary>
        /// Customer UID of the delivery order.
        /// </summary>
        public string CustomerUid { get; set; }
        
        /// <summary>
        /// Customer name of the delivery order.
        /// </summary>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// Company UID of the delivery order.
        /// </summary>
        public string CompanyUid { get; set; }
        
        /// <summary>
        /// Company name of the delivery order.
        /// </summary>
        public string CompanyName { get; set; }
        
        /// <summary>
        /// Delivery method.
        /// </summary>
        public DeliveryMethod DeliveryMethod { get; set; }
        
        /// <summary>
        /// Preparing operations for the delivery order.
        /// </summary>
        public ICollection<BusinessOperation> PreparingOperations { get; set; }
        
        /// <summary>
        /// Delivery operation.
        /// </summary>
        public BusinessOperation DeliveryOperation { get; set; }
        
        /// <summary>
        /// Products associated with the delivery order.
        /// </summary>
        public ICollection<Product> Products { get; set; }
        
        /// <summary>
        /// Price of the products.
        /// </summary>
        public decimal ProductsPrice { get; set; }
        
        /// <summary>
        /// Additonal price of the delivery order.
        /// </summary>
        public decimal AdditonalPrice { get; set; }
        
        /// <summary>
        /// Price for the delivery.
        /// </summary>
        public decimal DeliveryPrice { get; set; }
        
        /// <summary>
        /// Taxes of the delivery order.
        /// </summary>
        public decimal TaxPrice { get; set; }
        
        /// <summary>
        /// Total price of the delivery order.
        /// </summary>
        public decimal TotalPrice { get; set; }
        
        /// <summary>
        /// Initial address of the delivery.
        /// </summary>
        public Address Origin { get; set; }
        
        /// <summary>
        /// Final address of the delivery (destination).
        /// </summary>
        public Address Destination { get; set; }
        
        /// <summary>
        /// Payments made within the delivery order.
        /// </summary>
        public ICollection<Payment> Payments { get; set; }
        
        /// <summary>
        /// Shows if the delivery order could be cancelled.
        /// </summary>
        public bool CouldBeCancelled { get; set; }
        
        /// <summary>
        /// Status of the delivery order.
        /// </summary>
        public string Status { get; set; }
    }
}