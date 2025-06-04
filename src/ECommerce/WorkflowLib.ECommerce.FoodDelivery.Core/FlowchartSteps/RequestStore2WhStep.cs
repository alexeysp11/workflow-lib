using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that allows a warehouse employee to make a request for delivery of missing products from the store to the warehouse.
    /// </summary>
    public class RequestStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public RequestStore2WhStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins processing a request for delivery of products from a store to a warehouse.
        /// </summary>
        public bool Start()
        {
            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Check if a delivery has already been made from the warehouse to the kitchen.
            // Run this step only if delivery has NOT taken place.
            var deliveryWh2Kitchen = context.DeliveryOperations
                .FirstOrDefault(x => x.DeliveryOperationType == FoodDeliveryType.Wh2Kitchen.ToString());
            if (deliveryWh2Kitchen != null)
            {
                return false;
            }

            System.Console.WriteLine("RequestStore2WhStep.Start: begin");

            // When a warehouse employee receives a BusinessTask to request a delivery from the store to the warehouse, 
            // his active tasks are simply downloaded to them.
            // When a warehouse employee on the client "closes" the BusinessTask task to request delivery from the store to the warehouse, 
            // the DeliveryOrder object is passed to the backend.
            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder != null);
            //string response = new WarehouseClientController(_contextOptions).RequestStore2WhRespond(new ApiOperation
            //{
            //    RequestObject = model
            //});
            //System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("RequestStore2WhStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}