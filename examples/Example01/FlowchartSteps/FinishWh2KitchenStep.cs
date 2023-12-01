using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class FinishWh2KitchenStep : IFlowchartStep
    {
        private WarehouseClientReceiverController _warehouseClient { get; set; }
        private WarehouseBackendReceiverController _warehouseBackend { get; set; }
        private NotificationsBackendSenderController _notificationsBackend { get; set; }

        public FinishWh2KitchenStep()
        {
            _notificationsBackend = new NotificationsBackendSenderController();
            // kitchen backend.
            _warehouseBackend = new WarehouseBackendReceiverController();
            _warehouseClient = new WarehouseClientReceiverController(_warehouseBackend);
        }

        public void Start()
        {
            var model = new PlaceOrderModel()
            {
                // 
            };
            _warehouseClient.Wh2Kitchen(model);
        }
    }
}