using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakePaymentStep : IFlowchartStep
    {
        private CustomerClientResponseController _customerClient { get; set; }
        private CustomerBackendResponseController _customerBackend { get; set; }
        private WarehouseBackendRequestController _warehouseBackend { get; set; }
        private NotificationsBackendRequestController _notificationsBackend { get; set; }

        public MakePaymentStep()
        {
            _notificationsBackend = new NotificationsBackendRequestController();
            _warehouseBackend = new WarehouseBackendRequestController(_notificationsBackend);
            _customerBackend = new CustomerBackendResponseController(_warehouseBackend);
            _customerClient = new CustomerClientResponseController(_customerBackend);
        }

        public void Start()
        {
            System.Console.WriteLine("MakePaymentStep.Start: begin");
            var model = new Payment()
            {
                // 
            };
            string response = _customerClient.MakePayment(model);
            System.Console.WriteLine("MakePaymentStep.Start: end");
        }
    }
}