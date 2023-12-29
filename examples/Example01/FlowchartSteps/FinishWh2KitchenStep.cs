using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that completes the procedure for delivering products from the warehouse to the kitchen.
    /// </summary>
    public class FinishWh2KitchenStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public FinishWh2KitchenStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that completes the delivery procedure from the warehouse to the kitchen.
        /// </summary>
        public void Start()
        {
            System.Console.WriteLine("FinishWh2KitchenStep.Start: begin");

            using var context = new DeliveringContext(_contextOptions);

            // Select initial order which has a delivery order that is without a parent and was ordered by the customer.
            var initialOrder = context.InitialOrders
                .Include(x => x.DeliveryOrder)
                .Where(x => x.DeliveryOrder != null)
                .FirstOrDefault(x => x.DeliveryOrder.ParentDeliveryOrder == null 
                    && x.DeliveryOrder.OrderCustomerType == OrderCustomerType.Customer);
            
            // Find collections of InitialOrderIngredient and InitialOrderProduct objects by InitialOrder.
            var initialOrderIngredients = context.InitialOrderIngredients.Where(x => x.InitialOrder.Id == initialOrder.Id);

            // To deliver from the warehouse to the kitchen, you need to create and fill in the DeliveryWh2Kitchen object.
            var model = new DeliveryWh2Kitchen
            {
                //
            };

            // 
            string response = new WarehouseClientController(_contextOptions).Wh2KitchenRespond(new ApiOperation
            {
                RequestObject = model
            });
            
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("FinishWh2KitchenStep.Start: end");
        }
    }
}