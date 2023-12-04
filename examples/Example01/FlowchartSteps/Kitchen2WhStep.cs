using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class Kitchen2WhStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("Kitchen2WhStep.Start: begin");
            var model = new PlaceOrderModel()
            {
                // 
            };
            string response = new WarehouseClientController().Kitchen2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("Kitchen2WhStep.Start: end");
        }
    }
}