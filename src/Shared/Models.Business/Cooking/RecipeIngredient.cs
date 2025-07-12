namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Recipe ingredient.
    /// </summary>
    public class RecipeIngredient : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient? Ingredient { get; set; }

        /// <summary>
        /// Recipe.
        /// </summary>
        public Recipe? Recipe { get; set; }
    }
}