using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Data;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class KitchenBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public KitchenBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public string PrepareMealStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");

                // Send HTTP request.
                string backendResponse = new KitchenClientController(_contextOptions).PrepareMealSave(new ApiOperation
                {
                    RequestObject = model
                });

                // Send request to the notifications backend.
                string notificationsRequest = new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Please, be informed that one request for cooking awaits you",
                        BodyText = ""
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
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: end");
            return response;
        }

        public string PrepareMealExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseBackendController(_contextOptions).Kitchen2WhStart(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenBackend.PrepareMealExecute: end");
            return response;
        }
    }
}