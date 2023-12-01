using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerClientSenderController : ICustomerClient
    {
        private CustomerBackendSenderController _backendController { get; set; }
        
        public CustomerClientSenderController(CustomerBackendSenderController backendController)
        {
            _backendController = backendController;
        }

        public string MakeOrder(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakeOrder: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerClient.MakeOrder: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrder: cache");

                // Send HTTP request.
                string backendResponse = _backendController.MakeOrder(model);
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrder: cache");

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

        public async Task<string> MakeOrderAsync(PlaceOrderModel model)
        {
            await Task.Delay(500);
            return "";
        }
        
        public string MakePayment(object input)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePayment: begin");
            try
            {
                Payment model = input as Payment;

                // Update DB.
                System.Console.WriteLine("CustomerClient.MakePayment: cache");

                // 
                response = "DB is updated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerClient.MakePayment: end");
            return response;
        }
    }
}