using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CourierBackendController
    {
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhSave: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhSave: cache");
                
                // Notify courier employee.
                new NotificationsBackendController().SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Deliver from store to warehouse"
                    }
                });

                // Update cache in the client-side app.
                string deliveryRequest = new CourierClientController().Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("CourierBackend.Store2WhSave: end");
            return response;
        }

        public string Store2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhExecute: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhExecute: cache");

                // Update cache in the client-side app.
                string deliveryRequest = new WarehouseBackendController().Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("CourierBackend.Store2WhExecute: end");
            return response;
        }

        public string DeliverOrder(ApiOperation apiOperation)
        {
            return "";
        }
    }
}