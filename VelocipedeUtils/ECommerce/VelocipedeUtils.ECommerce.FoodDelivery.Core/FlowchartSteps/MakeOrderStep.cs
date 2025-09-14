using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Extensions;
using VelocipedeUtils.Shared.Models.Business.Customers;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// The step that allows the customer to place an order.
    /// </summary>
    public class MakeOrderStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        //private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public MakeOrderStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            //_customerClientController = customerClientController;
        }

        /// <summary>
        /// A method that begins the procedure for placing and pre-processing an order.
        /// </summary>
        public bool Start()
        {
            Console.WriteLine("MakeOrderStep.Start: begin");
            
            using var context = new FoodDeliveryDbContext(_contextOptions);

            Customer? customer = context.Customers.Include(x => x.UserAccount).FirstOrDefault(x => x.UserAccount != null);
            if (customer == null)
                throw new Exception("Specified customer does not exist in the database");
            if (customer.UserAccount == null)
                throw new Exception("Specified user account does not exist in the database");
            List<long> productIds = context.Products.Take(3).Select(x => x.Id).ToList();
            
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
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("MakeOrderStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}