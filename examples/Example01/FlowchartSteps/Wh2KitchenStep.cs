using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that completes the procedure for delivering products from the warehouse to the kitchen.
    /// </summary>
    public class Wh2KitchenStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Wh2KitchenStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that completes the delivery procedure from the warehouse to the kitchen.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("Wh2KitchenStep.Start: begin");

            using var context = new DeliveringContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder == null);
            if (model == null)
                throw new System.Exception("Delivery order could not be null");

            // 
            string response = new WarehouseClientController(_contextOptions).Wh2KitchenExecute(new ApiOperation
            {
                RequestObject = model
            });
            
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("Wh2KitchenStep.Start: end");
            
            return response == "success";
        }
    }
}