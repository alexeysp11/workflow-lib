using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to transfer a finished order from the kitchen to the warehouse.
    /// </summary>
    public class Kitchen2WhStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Kitchen2WhStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that starts the procedure for transferring a finished order from the kitchen to the warehouse.
        /// </summary>
        public bool Start()
        {
            Console.WriteLine("Kitchen2WhStep.Start: begin");

            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? devileryOrder = DeliveryOrderDao.GetDeliveryOrderByNumber(context, "");
            if (devileryOrder == null)
                throw new Exception("Delivery order could not be null");

            // 
            //string response = new WarehouseClientController(_contextOptions).Kitchen2WhExecute(new ApiOperation
            //{
            //    RequestObject = devileryOrder
            //});
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("Kitchen2WhStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}