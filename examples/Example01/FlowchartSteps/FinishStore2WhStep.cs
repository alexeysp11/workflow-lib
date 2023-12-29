using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that completes the procedure for delivering products from the store to the warehouse.
    /// </summary>
    public class FinishStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public FinishStore2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that completes the delivery procedure from the store to the warehouse.
        /// </summary>
        public void Start()
        {
            System.Console.WriteLine("FinishStore2WhStep.Start: begin");
            using var context = new DeliveringContext(_contextOptions);

            // Check whether there were enough ingredients in the order preprocessing step.

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
            string response = new CourierClientController(_contextOptions).Store2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("FinishStore2WhStep.Start: end");
        }
    }
}