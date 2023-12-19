using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// 
    /// </summary>
    public class FinishWh2KitchenStep : IFlowchartStep
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FinishWh2KitchenStep(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            System.Console.WriteLine("FinishWh2KitchenStep.Start: begin");

            using var context = new DeliveringContext(_contextOptions);
            var model = context.InitialOrders.FirstOrDefault();
            new WarehouseClientController(_contextOptions).Wh2KitchenRespond(new ApiOperation
            {
                RequestObject = model
            });
            
            System.Console.WriteLine("FinishWh2KitchenStep.Start: end");
        }
    }
}