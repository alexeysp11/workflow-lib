using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakeOrderStep : IFlowchartStep
    {
        private CustomerClientSenderController _customerClient { get; set; }
        private CustomerBackendSenderController _customerBackend { get; set; }
        private FileServiceController _fileService { get; set; }
        private NotificationsBackendSenderController _notificationsBackend { get; set; }

        public MakeOrderStep()
        {
            _fileService = new FileServiceController();
            _notificationsBackend = new NotificationsBackendSenderController();
            _customerBackend = new CustomerBackendSenderController(_fileService, _notificationsBackend);
            _customerClient = new CustomerClientSenderController(_customerBackend);
        }

        public void Start()
        {
            System.Console.WriteLine("MakeOrderStep.Start: begin");
            var model = new PlaceOrderModel()
            {
                UserUid = "UserUid",
                Login = "Login",
                PhoneNumber = "PhoneNumber",
                City = "City",
                Address = "Address",
                ProductIds = new List<int>() { 1, 2, 3 },
                PaymentType = "card"
            };
            string response = _customerClient.MakeOrder(model);
            System.Console.WriteLine("MakeOrderStep.Start: end");
        }
    }
}