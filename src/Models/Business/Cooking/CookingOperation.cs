using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.Cooking
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