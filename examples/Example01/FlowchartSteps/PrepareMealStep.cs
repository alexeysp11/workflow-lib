using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Examples.Example01.Controllers;
using Cims.WorkflowLib.Examples.Example01.Contexts;

namespace Cims.WorkflowLib.Examples.Example01.FlowchartSteps
{
    /// <summary>
    /// The step that involves preparing food in the kitchen as part of order processing.
    /// </summary>
    public class PrepareMealStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public PrepareMealStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the preparation of food by kitchen staff.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("PrepareMealStep.Start: begin");
            
            using var context = new DeliveringContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder == null);
            if (model == null)
                throw new System.Exception("Delivery order could not be null");
            
            // 
            string response = new KitchenClientController(_contextOptions).PrepareMealExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("PrepareMealStep.Start: end");
            
            return response == "success";
        }
    }
}