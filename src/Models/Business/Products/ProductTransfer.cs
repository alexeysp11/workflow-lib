using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product transfer.
    /// </summary>
    public class ProductTransfer : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Warehouse product.
        /// </summary>
        public WHProduct WHProduct { get; set; }

        /// <summary>
        /// Order product ID.
        /// </summary>
        public OrderProduct OrderProduct { get; set; }

        /// <summary>
        /// Order ID.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Delivery order product ID.
        /// </summary>
        public DeliveryOrderProduct DeliveryOrderProduct { get; set; }

        /// <summary>
        /// Delivery order ID.
        /// </summary>
        public DeliveryOrder DeliveryOrder { get; set; }

        /// <summary>
        /// Parent element.
        /// </summary>
        public ProductTransfer Parent { get; set; }
        
        /// <summary>
        /// Business operation ID.
        /// </summary>
        public long? BusinessOperationId { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        public System.DateTime Date { get; set; }
        
        /// <summary>
        /// Old quantity.
        /// </summary>
        public double? OldQuantity { get; set; }
        
        /// <summary>
        /// New quantity.
        /// </summary>
        public double NewQuantity { get; set; }
        
        /// <summary>
        /// Quantity delta.
        /// </summary>
        public double QuantityDelta { get; set; }
        
        /// <summary>
        /// Old status.
        /// </summary>
        public string? OldStatus { get; set; }
        
        /// <summary>
        /// New status.
        /// </summary>
        public string? NewStatus { get; set; }
    }
}