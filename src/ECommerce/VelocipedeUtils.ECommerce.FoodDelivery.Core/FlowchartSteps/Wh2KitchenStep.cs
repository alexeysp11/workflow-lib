using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Network;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.FlowchartSteps
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
            Console.WriteLine("Wh2KitchenStep.Start: begin");

            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? devileryOrder = DeliveryOrderDao.GetDeliveryOrderByNumber(context, "");
            if (devileryOrder == null)
                throw new Exception("Delivery order could not be null");

            // 
            //string response = new WarehouseClientController(_contextOptions).Wh2KitchenExecute(new ApiOperation
            //{
            //    RequestObject = devileryOrder
            //});
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("Wh2KitchenStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}