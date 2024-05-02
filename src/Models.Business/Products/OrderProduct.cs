using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Order product.
    /// </summary>
    public class OrderProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }
        
        /// <summary>
        /// Order.
        /// </summary>
        public Order? Order { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}