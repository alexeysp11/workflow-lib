using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Controllers;

namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    public class MakePaymentStep : IFlowchartStep
    {
        public void Start()
        {
            System.Console.WriteLine("MakePaymentStep.Start: begin");
            var model = new Payment()
            {
                // 
            };
            string response = new CustomerClientController().MakePaymentRespond(new ApiOperation
            {
                RequestObject = model
            });
            System.Console.WriteLine("MakePaymentStep.Start: end");
        }
    }
}