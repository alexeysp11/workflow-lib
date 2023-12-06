using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class FinishWh2KitchenStep : IFlowchartStep
    {
        public void Start()
        {
            var model = new InitialOrder()
            {
                // 
            };
            new WarehouseClientController().Wh2KitchenRespond(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}