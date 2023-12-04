using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class FinishStore2WhStep : IFlowchartStep
    {
        public void Start()
        {
            var model = new PlaceOrderModel()
            {
                // 
            };
            new CourierClientController().Store2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}