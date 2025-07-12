namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Substitute ingredient.
    /// </summary>
    public class SubstituteIngredient : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient? Ingredient { get; set; }

        /// <summary>
        /// Alternative ingredient.
        /// </summary>
        public Ingredient? AlternativeIngredient { get; set; }
    }
}