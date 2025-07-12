using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Initial order ingredient used during cooking operation.
    /// </summary>
    public class InitialOrderIngredientCookingOperation : BusinessTask, IWfBusinessEntity
    {
        /// <summary>
        /// Initial order ingredient.
        /// </summary>
        public InitialOrderIngredient? InitialOrderIngredient { get; set; }

        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation? CookingOperation { get; set; }
    }
}