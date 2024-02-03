using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Examples.Delivering.Example01.Controllers;
using Cims.WorkflowLib.Examples.Delivering.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Examples.Delivering.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to directly deliver the order to the customer.
    /// </summary>
    public class DeliverOrderStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public DeliverOrderStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the procedure for delivering an order to a customer.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("DeliverOrderStep.Start: begin");

            using var context = new DeliveringContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder == null);
            if (model == null)
                throw new System.Exception("Delivery order could not be null");
            
            // 
            string response = new CourierClientController(_contextOptions).DeliverOrderExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("DeliverOrderStep.Start: end");
            
            return response == "success";
        }
    }
}