using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public WarehouseBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        public string PreprocessOrderRedirect(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Get ingredients amount from DB.
                int ingredientsAmount = 0;
                bool isSufficient = true;
                // bool isSufficient = ingredientsAmount >= (model.Products == null ? 0 : model.Products.Count);

                // Понять, хватает ли на складе ингридиентов. И если не хватает, то каких конкретно. 
                // Поэлементно вычесть количество для соответствующего объекта WHProduct, если в коллекции DeliveryOrder.Products 
                // есть элемент с таким же ИД.

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
                    DeliveryWh2Kitchen wh2kitchenModel = new DeliveryWh2Kitchen();
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
                System.Console.WriteLine("ERROR : " + ex.ToString());
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
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.

                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from store to warehouse",
                        BodyText = ""
                    }
                });

                // Update cache in the client-side app.
                string paymentRequest = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation()
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
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
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");
                
                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from warehouse to kitchen",
                        BodyText = ""
                    }
                });

                // Update cache in the client-side app.
                string whRequest = new WarehouseClientController(_contextOptions).Wh2KitchenSave(new ApiOperation()
                {
                    RequestObject = new DeliveryWh2Kitchen()
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: end");
            return response;
        }

        public string Store2WhRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhRequest: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhRequest: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).Store2WhSave(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Store2WhRequest: end");
            return response;
        }
        
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhSave: cache");

                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Confirm the delivery from warehouse to kitchen",
                        BodyText = ""
                    }
                });

                // Send HTTP request.
                string backendResponse = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: end");
            return response;
        }

        public string Store2WhConfirm(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: end");
            return response;
        }

        public string Wh2KitchenRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: cache");

                // Send HTTP request.
                string backendResponse = new KitchenBackendController(_contextOptions).PrepareMealStart(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: end");
            return response;
        }

        public string Kitchen2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseClientController(_contextOptions).Kitchen2WhStart(new ApiOperation
                {
                    RequestObject = model
                });

                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Confirm the delivery from warehouse to kitchen",
                        BodyText = ""
                    }
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: end");
            return response;
        }

        public string Kitchen2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).ScanQrOnOrderStart(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: end");
            return response;
        }
    }
}