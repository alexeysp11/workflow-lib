using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class KitchenBackendController
    {
        // 
        public string PrepareMealStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");

                // Send HTTP request.
                string backendResponse = new KitchenClientController().PrepareMealSave(new ApiOperation
                {
                    RequestObject = model
                });

                // Send request to the notifications backend.
                string notificationsRequest = new NotificationsBackendController().SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Please, be informed that one request for cooking awaits you"
                    }
                });
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");
                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: end");
            return response;
        }
    }
}