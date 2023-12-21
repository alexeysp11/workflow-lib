using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a order ingredient and cooking operation.
    /// </summary>
    public class OrderIngredientCookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Order ingredient.
        /// </summary>
        public OrderIngredient OrderIngredient { get; set; }
        
        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation CookingOperation { get; set; }
    }
}