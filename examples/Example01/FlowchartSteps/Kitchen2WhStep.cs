using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to transfer a finished order from the kitchen to the warehouse.
    /// </summary>
    public class Kitchen2WhStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public Kitchen2WhStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that starts the procedure for transferring a finished order from the kitchen to the warehouse.
        /// </summary>
        public bool Start()
        {
            System.Console.WriteLine("Kitchen2WhStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new WarehouseClientController(_contextOptions).Kitchen2WhExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("Kitchen2WhStep.Start: end");
            
            return response == "success";
        }
    }
}