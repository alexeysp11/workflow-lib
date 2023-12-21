using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Cooking
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