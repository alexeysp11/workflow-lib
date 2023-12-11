using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class KitchenClientController
    {
        public string PrepareMealSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenClient.PrepareMealSave: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Validation.
                System.Console.WriteLine("KitchenClient.PrepareMealSave: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenClient.PrepareMealSave: end");
            return response;
        }

        public string PrepareMealExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenClient.PrepareMealExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Validation.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // Send HTTP request.
                string backendResponse = new KitchenBackendController().PrepareMealExecute(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenClient.PrepareMealExecute: end");
            return response;
        }
    }
}