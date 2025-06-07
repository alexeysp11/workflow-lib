using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that completes the procedure for delivering products from the warehouse to the kitchen.
    /// </summary>
    public class Wh2KitchenStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Wh2KitchenStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that completes the delivery procedure from the warehouse to the kitchen.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("Wh2KitchenStep.Start: begin");

            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? devileryOrder = FoodDeliveryDao.GetDeliveryOrderByNumber(context, "");
            if (devileryOrder == null)
                throw new System.Exception("Delivery order could not be null");

            // 
            //string response = new WarehouseClientController(_contextOptions).Wh2KitchenExecute(new ApiOperation
            //{
            //    RequestObject = devileryOrder
            //});
            //System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("Wh2KitchenStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}