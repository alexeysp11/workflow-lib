using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ConfirmStore2WhStep : IFlowchartStep
    {
        public void Start()
        {
            var model = new PlaceOrderModel()
            {
                // 
            };
            new WarehouseClientController().Store2WhConfirm(new ApiOperation
            {
                RequestObject = model
            });
        }
    }
}