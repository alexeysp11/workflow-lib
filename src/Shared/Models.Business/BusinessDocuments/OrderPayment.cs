using WorkflowLib.Shared.Models.Business.Monetary;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Order payment.
    /// </summary>
    public class OrderPayment : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Order.
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// Payment.
        /// </summary>
        public Payment? Payment { get; set; }
    }
}