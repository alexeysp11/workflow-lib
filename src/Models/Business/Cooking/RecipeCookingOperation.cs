using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a recipe and cooking operation.
    /// </summary>
    public class RecipeCookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Recipe.
        /// </summary>
        public Recipe Recipe { get; set; }
        
        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation CookingOperation { get; set; }
    }
}