using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Processes;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a order product and cooking operation.
    /// </summary>
    public class OrderProductCookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Order product.
        /// </summary>
        public OrderProduct OrderProduct { get; set; }
        
        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation CookingOperation { get; set; }
    }
}