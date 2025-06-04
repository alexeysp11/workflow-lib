using WorkflowLib.Shared.Models.Business.Cooking;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    public class DeliveryInitialOrderIngredient : BusinessTask, IWfBusinessEntity
    {
        public InitialOrderIngredient? InitialOrderIngredient { get; set; }
        public DeliveryOperation? DeliveryOperation { get; set; }
    }
}
