using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;
using WorkflowLib.Shared.Models.Business.Delivery;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.FlowchartSteps
{
    /// <summary>
    /// The step that consists of confirming delivery from the store to the warehouse 
    /// (assuming that confirmation is carried out by a warehouse employee).
    /// </summary>
    public class ConfirmStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public ConfirmStore2WhStep(
            DbContextOptions<FoodDeliveryDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the delivery confirmation step from the store to the warehouse.
        /// </summary>
        public bool Start()
        {
            using var context = new FoodDeliveryDbContext(_contextOptions);

            // Check if a delivery has already been made from the warehouse to the kitchen.
            // Run this step only if delivery has NOT taken place.
            DeliveryOperation? deliveryWh2Kitchen = context.DeliveryOperations
                .FirstOrDefault(x => x.DeliveryOperationType == FoodDeliveryType.Wh2Kitchen.ToString());
            if (deliveryWh2Kitchen != null)
            {
                return false;
            }
            
            Console.WriteLine("ConfirmStore2WhStep.Start: begin");

            // Get a delivery order that has a parent and is an internal delivery order.
            var deliveryOrder = context.DeliveryOrders
                .FirstOrDefault(x => x.ParentDeliveryOrder != null 
                    && x.OrderExecutorType == OrderExecutorType.Employee
                    && x.OrderCustomerType == OrderCustomerType.Employee);
            if (deliveryOrder == null)
                throw new Exception("Delivery order could not be null");
            
            // At the step of confirming delivery from the store to the warehouse there should 
            // be a description of how the quantity of products in the warehouse is updated.
            var deliveryOrderProducts = context.DeliveryOrderProducts
                .Include(x => x.Product)
                .Include(x => x.DeliveryOrder)
                .Where(x => x.DeliveryOrder.Id == deliveryOrder.Id);
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                var whproduct = context.WHProducts.FirstOrDefault(x => x.Product.Id == deliveryOrderProduct.Product.Id);
                if (whproduct == null)
                    throw new Exception("Warehouse product could not be null");
                var productTransfer = new ProductTransfer 
                {
                    Uid = Guid.NewGuid().ToString(),
                    WHProduct = whproduct,
                    DeliveryOrderProduct = deliveryOrderProduct,
                    DeliveryOrder = deliveryOrderProduct.DeliveryOrder,
                    Date = DateTime.Now,
                    OldQuantity = whproduct.Quantity,
                    NewQuantity = whproduct.Quantity + deliveryOrderProduct.Quantity,
                    QuantityDelta = deliveryOrderProduct.Quantity
                };
                whproduct.Quantity = (int)productTransfer.NewQuantity;
                context.ProductTransfers.Add(productTransfer);
            }
            context.SaveChanges();

            // 
            //string response = new WarehouseClientController(_contextOptions).ConfirmStore2WhAccept(new ApiOperation
            //{
            //    RequestObject = deliveryOrder
            //});
            //Console.WriteLine($"response: {response}");
            Console.WriteLine("ConfirmStore2WhStep.Start: end");
            
            //return response == "success";
            return true;
        }
    }
}