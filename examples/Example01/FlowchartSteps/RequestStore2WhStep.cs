using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows a warehouse employee to make a request for delivery of missing products from the store to the warehouse.
    /// </summary>
    public class RequestStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public RequestStore2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins processing a request for delivery of products from a store to a warehouse.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("RequestStore2WhStep.Start: begin");
            
            using var context = new DeliveringContext(_contextOptions);

            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder != null);
            string response = new WarehouseClientController(_contextOptions).Store2WhRequest(new ApiOperation
            {
                RequestObject = model
            });
            
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("RequestStore2WhStep.Start: end");
            
            return response == "success";
        }
    }
}