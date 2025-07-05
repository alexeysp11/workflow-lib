using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to make electronic payment on the site.
    /// </summary>
    public class MakePaymentStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        //private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public MakePaymentStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            //_customerClientController = customerClientController;
        }

        /// <summary>
        /// A method that starts the process of electronic payment for an order.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("MakePaymentStep.Start: begin");
            
            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Check integrity of data.
            Payment? payment = context.Payments.FirstOrDefault();
            if (payment == null)
                throw new Exception("Payment could not be found in the database");
            DeliveryOrder? deliveryOrder = context.DeliveryOrders.FirstOrDefault();
            if (deliveryOrder == null 
                || (deliveryOrder != null && deliveryOrder.Payments == null) 
                || (deliveryOrder != null && deliveryOrder.Payments != null && !deliveryOrder.Payments.Contains(payment)))
            {
                throw new Exception("Integrity of data is violated: payment object is not in the payment collection");
            }
            
            // Provide card details and save.
            payment.CardNumber = "RANDOM-0000-0000-0000-0000";
            payment.Status = EnumExtensions.GetDisplayName(PaymentStatus.InProcess);
            context.SaveChanges();
            
            // Send HTTP request.
            //string response = _customerClientController.MakePaymentRespond(new ApiOperation
            //{
            //    RequestObject = deliveryOrder
            //});
            //System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("MakePaymentStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}