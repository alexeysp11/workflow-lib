using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ConfirmStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public ConfirmStore2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            using var context = new DeliveringContext(_contextOptions);
            
            // Unload a delivery order that has a parent and is an internal delivery order.
            var model = context.DeliveryOrders
                .FirstOrDefault(x => x.ParentDeliveryOrder != null 
                    && x.OrderExecutorType == OrderExecutorType.Employee
                    && x.OrderCustomerType == OrderCustomerType.Employee);
            if (model == null)
                throw new System.Exception("Delivery order could not be null");
            
            // At the step of confirming delivery from the store to the warehouse there should 
            // be a description of how the quantity of products in the warehouse is updated.
            var deliveryOrderProducts = context.DeliveryOrderProducts
                .Include(x => x.Product)
                .Include(x => x.DeliveryOrder)
                .Where(x => x.DeliveryOrder.Id == model.Id);
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                var whproduct = context.WHProducts.FirstOrDefault(x => x.Product.Id == deliveryOrderProduct.Product.Id);
                if (whproduct == null)
                    throw new System.Exception("Warehouse product could not be null");
                var productTransfer = new ProductTransfer 
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    WHProduct = whproduct,
                    DeliveryOrderProduct = deliveryOrderProduct,
                    DeliveryOrder = deliveryOrderProduct.DeliveryOrder,
                    Date = System.DateTime.Now,
                    OldQuantity = whproduct.Quantity,
                    NewQuantity = whproduct.Quantity + deliveryOrderProduct.Quantity,
                    QuantityDelta = deliveryOrderProduct.Quantity
                };
                whproduct.Quantity = (int)productTransfer.NewQuantity;
                context.ProductTransfers.Add(productTransfer);
            }
            context.SaveChanges();

            // 
            new WarehouseClientController(_contextOptions).Store2WhConfirm(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}