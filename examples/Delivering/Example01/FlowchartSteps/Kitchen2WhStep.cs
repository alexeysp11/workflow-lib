using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.Examples.Delivering.Example01.Controllers;
using WorkflowLib.Examples.Delivering.Example01.Contexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.Examples.Delivering.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to transfer a finished order from the kitchen to the warehouse.
    /// </summary>
    public class Kitchen2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Kitchen2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that starts the procedure for transferring a finished order from the kitchen to the warehouse.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("Kitchen2WhStep.Start: begin");

            using var context = new DeliveringContext(_contextOptions);
            
            // Unload a delivery order that has a parent and is an internal delivery order.
            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder == null);
            if (model == null)
                throw new System.Exception("Delivery order could not be null");
            
            // 
            string response = new WarehouseClientController(_contextOptions).Kitchen2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("Kitchen2WhStep.Start: end");
            
            return response == "success";
        }
    }
}