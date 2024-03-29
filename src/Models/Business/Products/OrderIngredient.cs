using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Order ingredient.
    /// </summary>
    public class OrderIngredient : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient Ingredient { get; set; }
        
        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}