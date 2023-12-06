using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class DeliverOrderStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("DeliverOrderStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController().DeliverOrderExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("DeliverOrderStep.Start: end");
        }
    }
}