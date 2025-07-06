using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to directly deliver the order to the customer.
    /// </summary>
    public class DeliverOrderStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public DeliverOrderStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the procedure for delivering an order to a customer.
        /// </summary>
        public bool Start()
        {
            Console.WriteLine("DeliverOrderStep.Start: begin");

            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? devileryOrder = FoodDeliveryDao.GetDeliveryOrderByNumber(context, "");
            if (devileryOrder == null)
                throw new Exception("Delivery order could not be null");

            // 
            //string response = new CourierClientController(_contextOptions).DeliverOrderExecute(new ApiOperation
            //{
            //    RequestObject = devileryOrder
            //});
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("DeliverOrderStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}