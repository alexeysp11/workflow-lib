using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakeOrderStep : IFlowchartStep
    {
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
            string response = new CustomerClientController().MakeOrderRequest(model);
            System.Console.WriteLine("MakeOrderStep.Start: end");
        }
    }
}