using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between business task and delivery order.
    /// </summary>
    public class BusinessTaskDeliveryOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Business task.
        /// </summary>
        public BusinessTask? BusinessTask { get; set; }

        /// <summary>
        /// Delivery order.
        /// </summary>
        public DeliveryOrder? DeliveryOrder { get; set; }

        /// <summary>
        /// Discriminator.
        /// </summary>
        public string? Discriminator { get; set; }
    }
}