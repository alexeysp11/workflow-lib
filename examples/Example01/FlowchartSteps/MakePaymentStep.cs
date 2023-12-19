using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakePaymentStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private CustomerClientController _customerClientController { get; set; }

        public MakePaymentStep(
            DbContextOptions<DeliveringContext> contextOptions,
            CustomerClientController customerClientController)
        {
            _contextOptions = contextOptions;
            _customerClientController = customerClientController;
        }

        public void Start()
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
            payment.Status = "In process";
            context.SaveChanges();
            
            // Send HTTP request.
            string response = _customerClientController.MakePaymentRespond(new ApiOperation
            {
                RequestObject = deliveryOrder
            });
            
            // 
            System.Console.WriteLine("MakePaymentStep.Start: end");
        }
    }
}