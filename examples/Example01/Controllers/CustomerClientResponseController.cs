using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerClientResponseController : ICustomerClient
    {
        private CustomerBackendResponseController _backendController { get; set; }

        public CustomerClientResponseController(
                CustomerBackendResponseController backendController)
        {
            _backendController = backendController;
        }

        public string MakeOrder(PlaceOrderModel model)
        {
            // 
            return "";
        }

        public string MakePayment(object input)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePayment: begin");
            try
            {
                Payment model = input as Payment;

                // Validation.
                System.Console.WriteLine("CustomerClient.MakePayment: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePayment: cache");

                // Send HTTP request.
                string backendResponse = _backendController.MakePayment(model);
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePayment: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerClient.MakeOrder: end");
            return response;
        }
    }
}