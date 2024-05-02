using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Processes;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a order ingredient and cooking operation.
    /// </summary>
    public class OrderIngredientCookingOperation : BusinessTask, IBusinessEntityWF
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