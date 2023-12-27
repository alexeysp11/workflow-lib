using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class FinishStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public FinishStore2WhStep(
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
            
            // For the received order, you need to set prices for products and attach a photo/scan of the receipt to the task 
            // (the last one has not yet been implemented).
            var totalPrice = context.DeliveryOrderProducts
                .Where(x => x.DeliveryOrder.Id == model.Id)
                .Sum(x => (float)x.Product.Price * x.Quantity);
            if (totalPrice == null)
                throw new System.Exception("Calculated total price of the products within the delivery order could not be null");
            model.ProductsPrice = (decimal)totalPrice;
            context.SaveChanges();

            // 
            new CourierClientController(_contextOptions).Store2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}