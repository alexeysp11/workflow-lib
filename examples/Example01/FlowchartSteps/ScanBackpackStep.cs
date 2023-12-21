using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ScanBackpackStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public ScanBackpackStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            System.Console.WriteLine("ScanBackpackStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController(_contextOptions).ScanBackpackExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("ScanBackpackStep.Start: end");
        }
    }
}