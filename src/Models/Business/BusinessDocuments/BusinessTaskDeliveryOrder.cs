using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between business task and delivery order.
    /// </summary>
    public class BusinessTaskDeliveryOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Business task.
        /// </summary>
        public BusinessTask BusinessTask { get; set; }

        /// <summary>
        /// Delivery order.
        /// </summary>
        public DeliveryOrder DeliveryOrder { get; set; }

        /// <summary>
        /// Discriminator.
        /// </summary>
        public string Discriminator { get; set; }
    }
}