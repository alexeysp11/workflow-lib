using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakePaymentStep : IFlowchartStep
    {
        private CustomerClientReceiverController _customerClient { get; set; }
        private CustomerBackendReceiverController _customerBackend { get; set; }
        private WarehouseBackendSenderController _warehouseBackend { get; set; }
        private NotificationsBackendSenderController _notificationsBackend { get; set; }

        public MakePaymentStep()
        {
            _notificationsBackend = new NotificationsBackendSenderController();
            _warehouseBackend = new WarehouseBackendSenderController(_notificationsBackend);
            _customerBackend = new CustomerBackendReceiverController(_warehouseBackend);
            _customerClient = new CustomerClientReceiverController(_customerBackend);
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