using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakeOrderStep : IFlowchartStep
    {
        private CustomerClientRequestController _customerClient { get; set; }
        private CustomerBackendRequestController _customerBackend { get; set; }
        private FileServiceController _fileService { get; set; }
        private NotificationsBackendRequestController _notificationsBackend { get; set; }

        public MakeOrderStep()
        {
            _fileService = new FileServiceController();
            _notificationsBackend = new NotificationsBackendRequestController();
            _customerBackend = new CustomerBackendRequestController(_fileService, _notificationsBackend);
            _customerClient = new CustomerClientRequestController(_customerBackend);
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