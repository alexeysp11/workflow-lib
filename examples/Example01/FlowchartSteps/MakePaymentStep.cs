using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to make electronic payment on the site.
    /// </summary>
    public class MakePaymentStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public MakePaymentStep(
            DbContextOptions<DeliveringContext> contextOptions,
            CustomerClientController customerClientController)
        {
            _contextOptions = contextOptions;
            _customerClientController = customerClientController;
        }

        /// <summary>
        /// A method that starts the process of electronic payment for an order.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("MakePaymentStep.Start: begin");
            
            using var context = new DeliveringContext(_contextOptions);

            // Check integrity of data.
            var payment = context.Payments.FirstOrDefault();
            if (payment == null)
                throw new System.Exception("Payment could not be found in the database");
            var deliveryOrder = context.DeliveryOrders.FirstOrDefault();
            if (deliveryOrder == null 
                || (deliveryOrder != null && deliveryOrder.Payments == null) 
                || (deliveryOrder != null && deliveryOrder.Payments != null && !deliveryOrder.Payments.Contains(payment)))
            {
                throw new System.Exception("Integrity of data is violated: payment object is not in the payment collection");
            }
            
            // Provide card details and save.
            payment.CardNumber = "RANDOM-0000-0000-0000-0000";
            payment.Status = EnumExtensions.GetDisplayName(PaymentStatus.InProcess);
            context.SaveChanges();
            
            // Send HTTP request.
            string response = _customerClientController.MakePaymentRespond(new ApiOperation
            {
                RequestObject = deliveryOrder
            });
            
            // 
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("MakePaymentStep.Start: end");
            
            return response == "success";
        }
    }
}