using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerClientController
    {
        public string MakeOrder(ApiOperation apiOperation)
        {
            // 
            return "";
        }

        public string MakePaymentRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: begin");
            try
            {
                Payment model = apiOperation.RequestObject as Payment;

                // Validation.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // Send HTTP request.
                string backendResponse = new CustomerBackendController().MakePaymentRespond(new ApiOperation()
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: end");
            return response;
        }

        public string MakeOrderRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Validation.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");

                // Send HTTP request.
                string backendResponse = new CustomerBackendController().MakeOrderRequest(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: end");
            return response;
        }

        public async Task<string> MakeOrderAsync(ApiOperation apiOperation)
        {
            await Task.Delay(500);
            return "";
        }
        
        public string MakePaymentSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentSave: begin");
            try
            {
                Payment model = apiOperation.RequestObject as Payment;

                // Update DB.
                System.Console.WriteLine("CustomerClient.MakePaymentSave: cache");

                // 
                response = "DB is updated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerClient.MakePaymentSave: end");
            return response;
        }
    }
}