using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Products
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
        /// InitialOrder.
        /// </summary>
        public InitialOrder InitialOrder { get; set; }
        
        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}