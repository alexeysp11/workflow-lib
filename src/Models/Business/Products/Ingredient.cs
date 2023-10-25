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
        /// Product (main ingredient).
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Substitute ingredients.
        /// </summary>
        public ICollection<Ingredient> SubstituteIngredients { get; set; }
    }
}