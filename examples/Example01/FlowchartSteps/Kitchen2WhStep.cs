using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class Kitchen2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public Kitchen2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            System.Console.WriteLine("Kitchen2WhStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new WarehouseClientController(_contextOptions).Kitchen2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("Kitchen2WhStep.Start: end");
        }
    }
}