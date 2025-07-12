using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Initial order product used during cooking operation.
    /// </summary>
    public class InitialOrderProductCookingOperation : BusinessTask, IWfBusinessEntity
    {
        /// <summary>
        /// Initial order product.
        /// </summary>
        public InitialOrderProduct? InitialOrderProduct { get; set; }

        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation? CookingOperation { get; set; }
    }
}