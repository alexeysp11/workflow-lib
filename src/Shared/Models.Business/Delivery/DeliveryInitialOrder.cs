using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    public class DeliveryInitialOrder : BusinessTask, IWfBusinessEntity
    {
        public InitialOrder? InitialOrder { get; set; }
        public DeliveryOperation? DeliveryOperation { get; set; }
    }
}
