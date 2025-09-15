using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Network;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// The step that involves preparing food in the kitchen as part of order processing.
    /// </summary>
    public class PrepareMealStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public PrepareMealStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the preparation of food by kitchen staff.
        /// </summary>
        public bool Start()
        {
            Console.WriteLine("PrepareMealStep.Start: begin");
            
            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? devileryOrder = DeliveryOrderDao.GetDeliveryOrderByNumber(context, "");
            if (devileryOrder == null)
                throw new Exception("Delivery order could not be null");

            // 
            //string response = new KitchenClientController(_contextOptions).PrepareMealExecute(new ApiOperation
            //{
            //    RequestObject = devileryOrder
            //});
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("PrepareMealStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}