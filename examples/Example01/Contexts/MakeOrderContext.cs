using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Contexts
{
    public class MakeOrderContext : WorkflowInstanceContext
    {
        public DeliveryOrder DeliveryOrder { get; set; }
        public PlaceOrderModel PlaceOrderModel { get; set; }
    }
}