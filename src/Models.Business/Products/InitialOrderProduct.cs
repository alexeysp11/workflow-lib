using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class InitialOrderProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }
        
        /// <summary>
        /// InitialOrder.
        /// </summary>
        public InitialOrder? InitialOrder { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}