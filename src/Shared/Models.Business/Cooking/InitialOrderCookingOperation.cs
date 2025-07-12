using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.Shared.Models.Business.Cooking
{
    /// <summary>
    /// Initial order cooking operation.
    /// </summary>
    public class InitialOrderCookingOperation : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Initial order.
        /// </summary>
        public InitialOrder? InitialOrder {  get; set; }

        /// <summary>
        /// Cooking operation.
        /// </summary>
        public CookingOperation? CookingOperation {  get; set; }
    }
}