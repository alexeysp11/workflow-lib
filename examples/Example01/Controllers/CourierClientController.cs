using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CourierClientController
    {
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.Store2WhSave: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierClient.Store2WhSave: end");
            return response;
        }

        public string Store2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.Store2WhExecute: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController().Store2WhExecute(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierClient.Store2WhExecute: end");
            return response;
        }
    }
}