using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Data;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakeOrderStep : IFlowchartStep
    {
        private CustomerClientController _customerClientController { get; set; }

        public MakeOrderStep(
            CustomerClientController customerClientController)
        {
            _customerClientController = customerClientController;
        }

        public void Start()
        {
            System.Console.WriteLine("MakeOrderStep.Start: begin");
            var model = new InitialOrder()
            {
                UserUid = System.Guid.NewGuid().ToString(),
                Login = "Login1",
                PhoneNumber = "PhoneNumber1",
                City = "City1",
                Address = "Address1",
                ProductIds = new List<int>() { 1, 1, 2, 3, 3, 3 },
                PaymentType = "card"
            };
            string response = _customerClientController.MakeOrderRequest(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("MakeOrderStep.Start: end");
        }
    }
}