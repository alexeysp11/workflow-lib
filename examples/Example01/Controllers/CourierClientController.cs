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

        public string ScanQrOnOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: end");
            return response;
        }

        public string ScanQrOnOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController().ScanQrOnOrderExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: end");
            return response;
        }

        public string ScanBackpackStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanBackpackStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanBackpackStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierClient.ScanBackpackStart: end");
            return response;
        }
        
        public string ScanBackpackExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanBackpackExecute: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanBackpackExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController().ScanBackpackExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.ScanBackpackExecute: end");
            return response;
        }
        
        public string DeliverOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.DeliverOrderStart: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CourierClient.DeliverOrderStart: end");
            return response;
        }
        
        public string DeliverOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController().DeliverOrderExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: end");
            return response;
        }
    }
}