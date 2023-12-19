using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class ScanQrOnOrderStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public ScanQrOnOrderStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public void Start()
        {
            System.Console.WriteLine("ScanQrOnOrderStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController(_contextOptions).ScanQrOnOrderExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("ScanQrOnOrderStep.Start: end");
        }
    }
}