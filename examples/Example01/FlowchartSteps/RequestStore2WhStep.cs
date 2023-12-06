using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class RequestStore2WhStep : IFlowchartStep
    {
        public void Start()
        {
            var model = new InitialOrder()
            {
                // 
            };
            new WarehouseClientController().Store2WhRequest(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}