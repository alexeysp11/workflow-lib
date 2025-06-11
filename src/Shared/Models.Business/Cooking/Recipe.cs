using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Recipe.
    /// </summary>
    public class Recipe : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Ingredients.
        /// </summary>
        [Obsolete("It's better to use IngredientRecipe object")]
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Instruction how to cook.
        /// </summary>
        public string? Instruction { get; set; }
    }
}