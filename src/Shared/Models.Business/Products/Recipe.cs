using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Products
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
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Instruction how to cook.
        /// </summary>
        public string? Instruction { get; set; }
    }
}