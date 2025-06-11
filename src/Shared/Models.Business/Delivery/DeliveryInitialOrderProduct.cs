using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    public class DeliveryInitialOrderProduct : BusinessTask, IWfBusinessEntity
    {
        public InitialOrderProduct? InitialOrderProduct { get; set; }
        public DeliveryOperation? DeliveryOperation { get; set; }
    }
}
