using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class InitialOrderIngredient : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Ingredient.
        /// </summary>
        public Ingredient Ingredient { get; set; }
        
        /// <summary>
        /// Initial order.
        /// </summary>
        public InitialOrder InitialOrder { get; set; }
        
        /// <summary>
        /// Initial order product.
        /// </summary>
        public InitialOrderProduct InitialOrderProduct { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}