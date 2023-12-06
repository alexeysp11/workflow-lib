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
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
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
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
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

        public string ScanQrOnOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController().ScanQrOnOrderStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: end");
            return response;
        }

        public string ScanQrOnOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderExecute: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanQrOnOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = ScanBackpackStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderExecute: end");
            return response;
        }

        public string ScanBackpackStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanBackpackStart: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanBackpackStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController().ScanBackpackStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanBackpackStart: end");
            return response;
        }

        public string ScanBackpackExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanBackpackExecute: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanBackpackExecute: cache");

                // Send HTTP request.
                string backendResponse = DeliverOrderStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanBackpackExecute: end");
            return response;
        }

        public string DeliverOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController().DeliverOrderStart(new ApiOperation
                {
                    RequestObject = model
                });

                // Notify the customer.
                new NotificationsBackendController().SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Your order is on deliver"
                    }
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: end");
            return response;
        }

        public string DeliverOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: begin");
            try
            {
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: end");
            return response;
        }
    }
}