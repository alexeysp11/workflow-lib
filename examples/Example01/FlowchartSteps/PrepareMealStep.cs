using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class PrepareMealStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public PrepareMealStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            System.Console.WriteLine("PrepareMealStep.Start: begin");
            var model = new Payment()
            {
                // 
            };
            string response = new KitchenClientController(_contextOptions).PrepareMealExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("PrepareMealStep.Start: end");
        }
    }
}