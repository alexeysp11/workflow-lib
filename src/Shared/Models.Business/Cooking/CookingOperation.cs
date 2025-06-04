using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Cooking operation.
    /// </summary>
    public class CookingOperation : BusinessTask, IWfBusinessEntity
    {
        /// <summary>
        /// Initial orders.
        /// </summary>
        [Obsolete("It's better to use InitialOrderCooking object")]
        public ICollection<InitialOrder> InitialOrders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Obsolete("It's better to use InitialOrderProductCooking object")]
        public ICollection<InitialOrderProduct> InitialOrderProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Obsolete("It's better to use InitialOrderIngredientCooking object")]
        public ICollection<InitialOrderIngredient> InitialOrderIngredients { get; set; }
    }
}