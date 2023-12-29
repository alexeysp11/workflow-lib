using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// A step that allows you to directly deliver the order to the customer.
    /// </summary>
    public class DeliverOrderStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public DeliverOrderStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that begins the procedure for delivering an order to a customer.
        /// </summary>
        public void Start()
        {
            System.Console.WriteLine("DeliverOrderStep.Start: begin");
            var model = new InitialOrder()
            {
                // 
            };
            string response = new CourierClientController(_contextOptions).DeliverOrderExecute(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine($"response: {response}");
            System.Console.WriteLine("DeliverOrderStep.Start: end");
        }
    }
}