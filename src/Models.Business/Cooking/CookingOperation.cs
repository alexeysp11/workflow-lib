using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;
using WorkflowLib.Models.Business.Processes;

namespace WorkflowLib.Models.Business.Cooking
{
    /// <summary>
    /// Cooking operation.
    /// </summary>
    public class CookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Initial orders.
        /// </summary>
        public ICollection<InitialOrder> InitialOrders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<InitialOrderProduct> InitialOrderProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<InitialOrderIngredient> InitialOrderIngredients { get; set; }
    }
}