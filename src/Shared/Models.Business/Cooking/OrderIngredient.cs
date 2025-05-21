using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Order ingredient.
    /// </summary>
    public class OrderIngredient : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient? Ingredient { get; set; }
        
        /// <summary>
        /// Order.
        /// </summary>
        public Order? Order { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}