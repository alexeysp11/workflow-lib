using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ScanQrOnOrderStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("ScanQrOnOrderStep.Start: begin");
            var model = new PlaceOrderModel()
            {
                // 
            };
            string response = new CourierClientController().ScanQrOnOrderExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("ScanQrOnOrderStep.Start: end");
        }
    }
}