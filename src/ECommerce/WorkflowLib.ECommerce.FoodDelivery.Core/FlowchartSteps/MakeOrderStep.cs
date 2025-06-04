using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Extensions;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// The step that allows the customer to place an order.
    /// </summary>
    public class MakeOrderStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringDbContext> _contextOptions { get; set; }
        //private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public MakeOrderStep(
            DbContextOptions<DeliveringDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            //_customerClientController = customerClientController;
        }

        /// <summary>
        /// A method that begins the procedure for placing and pre-processing an order.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("MakeOrderStep.Start: begin");
            
            using var context = new DeliveringDbContext(_contextOptions);
            
            var customer = context.Customers.Include(x => x.UserAccount).FirstOrDefault(x => x.UserAccount != null);
            if (customer == null)
                throw new System.Exception("Specified customer does not exist in the database");
            if (customer.UserAccount == null)
                throw new System.Exception("Specified user account does not exist in the database");
            var productIds = context.Products.Take(3).Select(x => x.Id).ToList();
            
            var model = new InitialOrder()
            {
                UserUid = customer.UserAccount.Uid,
                Login = customer.UserAccount.Login,
                PhoneNumber = customer.UserAccount.PhoneNumber,
                City = "City1",
                Address = "123, Customer Address",
                ProductIds = productIds,
                PaymentType = EnumExtensions.GetDisplayName(PaymentType.Card)
            };
            
            //string response = _customerClientController.MakeOrderRequest(new ApiOperation
            //{
            //    RequestObject = model
            //});
            
            //System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("MakeOrderStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}