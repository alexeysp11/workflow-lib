using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class PrepareMealStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("PrepareMealStep.Start: begin");
            var model = new Payment()
            {
                // 
            };
            string response = new KitchenClientController().PrepareMealExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("PrepareMealStep.Start: end");
        }
    }
}