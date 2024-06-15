using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Associate table that connects a recipe and cooking operation.
    /// </summary>
    public class RecipeCookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Recipe.
        /// </summary>
        public Recipe? Recipe { get; set; }
        
        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation? CookingOperation { get; set; }
    }
}