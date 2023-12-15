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
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private CustomerClientController _customerClientController { get; set; }

        public MakeOrderStep(
            DbContextOptions<DeliveringContext> contextOptions,
            CustomerClientController customerClientController)
        {
            _contextOptions = contextOptions;
            _customerClientController = customerClientController;
        }

        public void Start()
        {
            System.Console.WriteLine("MakeOrderStep.Start: begin");
            using var context = new DeliveringContext(_contextOptions);
            var user = context.UserAccounts.FirstOrDefault();
            var productIds = context.Products.Take(3).Select(x => x.Id).ToList();
            var model = new InitialOrder()
            {
                UserUid = System.Guid.NewGuid().ToString(),
                Login = user.Login,
                PhoneNumber = user.PhoneNumber,
                City = "City1",
                Address = "Address1",
                ProductIds = productIds,
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