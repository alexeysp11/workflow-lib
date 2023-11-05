using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Recipe.
    /// </summary>
    public class Recipe : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Ingredients.
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Instruction how to cook.
        /// </summary>
        public string Instruction { get; set; }
    }
}