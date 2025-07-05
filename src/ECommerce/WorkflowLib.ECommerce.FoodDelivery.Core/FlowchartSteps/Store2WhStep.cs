using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// A step that completes the procedure for delivering products from the store to the warehouse.
    /// </summary>
    public class Store2WhStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Store2WhStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that completes the delivery procedure from the store to the warehouse.
        /// </summary>
        public bool Start()
        {
            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Check if a delivery has already been made from the warehouse to the kitchen.
            // Run this step only if delivery has NOT taken place.
            var deliveryWh2Kitchen = FoodDeliveryDao.GetDeliveryOperation(context, FoodDeliveryType.Wh2Kitchen.ToString());
            if (deliveryWh2Kitchen != null)
            {
                return false;
            }
            
            System.Console.WriteLine("Store2WhStep.Start: begin");

            // Since at the stage of generating a delivery request, a warehouse employee cannot merge several DeliveryOrders 
            // into one task, the courier simply receives several tasks that indicate orders and products for delivery 
            // (at the UI level, they can be displayed by task, order or product).
            // The DeliveryOrder object associated with the delivery task is passed to the backend service.

            // Check whether there were enough ingredients in the order preprocessing step.

            // Unload a delivery order that has a parent and is an internal delivery order.
            DeliveryOrder? deliveryOrder = FoodDeliveryDao.GetInternalDeliveryOrder(context);
            if (deliveryOrder == null)
            {
                throw new Exception("Delivery order could not be null");
            }
            
            // For the received order, you need to set prices for products and attach a photo/scan of the receipt to the task 
            // (the last one has not yet been implemented).
            float? totalPrice = FoodDeliveryDao.GetDeliveryOrderTotalPrice(context, deliveryOrder.Id);
            if (!totalPrice.HasValue)
            {
                throw new Exception("Calculated total price of the products within the delivery order could not be null");
            }
            FoodDeliveryDao.UpdateDeliveryOrderTotalPrice(context, deliveryOrder, (decimal)totalPrice);

            // 
            //string response = new CourierClientController(_contextOptions).Store2WhExecute(new ApiOperation
            //{
            //    RequestObject = model
            //});
            //System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("Store2WhStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}