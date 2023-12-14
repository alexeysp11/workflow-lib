using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Ingredient.
    /// </summary>
    public class Ingredient : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product that represents the ingredient itself.
        /// </summary>
        /// <remarks>There could be a situation where flour is both an ingredient and product at the same time.</remarks>
        public Product IngredientProduct { get; set; }

        /// <summary>
        /// Final product that is associated with the ingredient.
        /// </summary>
        public Product FinalProduct { get; set; }

        /// <summary>
        /// Substitute ingredients.
        /// </summary>
        public ICollection<Ingredient> SubstituteIngredients { get; set; }
    }
}