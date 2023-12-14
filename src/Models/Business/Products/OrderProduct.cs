using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// OrderProduct.
    /// </summary>
    public class OrderProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product Product { get; set; }
        
        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}