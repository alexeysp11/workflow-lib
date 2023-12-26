using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class RequestStore2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public RequestStore2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            System.Console.WriteLine("RequestStore2WhStep.Start: begin");
            
            using var context = new DeliveringContext(_contextOptions);

            var model = context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder != null);
            new WarehouseClientController(_contextOptions).Store2WhRequest(new ApiOperation
            {
                RequestObject = model
            });
            
            System.Console.WriteLine("RequestStore2WhStep.Start: end");
        }
    }
}