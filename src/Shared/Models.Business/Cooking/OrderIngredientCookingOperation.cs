using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a order ingredient and cooking operation.
    /// </summary>
    public class OrderIngredientCookingOperation : BusinessTask, IWfBusinessEntity
    {
        /// <summary>
        /// Order ingredient.
        /// </summary>
        public OrderIngredient? OrderIngredient { get; set; }
        
        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation? CookingOperation { get; set; }
    }
}