using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseBackendController
    {
        public string PreprocessOrderRedirect(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Get ingredients amount from DB.
                int ingredientsAmount = 0;

                // 
                bool isSufficient = ingredientsAmount >= model.ProductIds.Count;

                // Calculte delivery time.
                var wh2kitchenDuration = new System.TimeSpan(0, 5, 0);
                var kitchen2whDuration = new System.TimeSpan(0, 5, 0);
                var store2whDuration = new System.TimeSpan(0, 15, 0);
                var preparemealDuration = new System.TimeSpan(0, 15, 0);

                // Overall deilivery time (best-case scenario).
                System.TimeSpan result = wh2kitchenDuration + kitchen2whDuration + preparemealDuration;

                // 
                if (isSufficient)
                {
                    // Invoke wh2kitchen.
                    response = Wh2KitchenStart(new ApiOperation()
                    {
                        RequestObject = model
                    });
                }
                else
                {
                    // Overall deilivery time (taking into account that delivery from store to warehouse is necessary).
                    result += store2whDuration;

                    // Invoke store2wh.
                    response = Store2WhStart(new ApiOperation()
                    {
                        RequestObject = model
                    });
                }
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: end");
            return response;
        }

        public string Store2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.

                // Notify warehouse employee.
                new NotificationsBackendController().SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from store to warehouse"
                    }
                });

                // Update cache in the client-side app.
                string paymentRequest = new WarehouseClientController().Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("WarehouseBackend.Store2WhStart: end");
            return response;
        }

        public string Wh2KitchenStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");
                
                // Notify warehouse employee.
                new NotificationsBackendController().SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from warehouse to kitchen",
                    }
                });

                // Update cache in the client-side app.
                string paymentRequest = new WarehouseClientController().Wh2KitchenSave(new ApiOperation()
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
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: end");
            return response;
        }

        public string Kitchen2WhStart(ApiOperation apiOperation)
        {
            // 
            return "";
        }
    }
}