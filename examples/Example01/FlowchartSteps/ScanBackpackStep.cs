using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ScanBackpackStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("ScanBackpackStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController().ScanBackpackExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("ScanBackpackStep.Start: end");
        }
    }
}