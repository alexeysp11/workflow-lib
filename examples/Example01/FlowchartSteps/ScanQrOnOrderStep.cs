using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// The step that is responsible for scanning the QR code on the order to register the start of the delivery procedure.
    /// </summary>
    public class ScanQrOnOrderStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public ScanQrOnOrderStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// The method that starts scanning the order.
        /// </summary>
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
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("ScanQrOnOrderStep.Start: end");
        }
    }
}