using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.Shared.Models.Business.Products
{
    /// <summary>
    /// Delivery order product.
    /// </summary>
    public class DeliveryOrderProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }
        
        /// <summary>
        /// Delivery order.
        /// </summary>
        public DeliveryOrder? DeliveryOrder { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}