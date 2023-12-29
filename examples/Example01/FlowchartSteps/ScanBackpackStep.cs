using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// The step that is responsible for scanning the backpack as part of the start of the order delivery procedure.
    /// </summary>
    public class ScanBackpackStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public ScanBackpackStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins scanning the backpack to begin delivery.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("ScanBackpackStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController(_contextOptions).ScanBackpackExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("ScanBackpackStep.Start: end");
            
            return response == "success";
        }
    }
}