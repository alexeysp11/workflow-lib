using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the courier.
    /// </summary>
    public class CourierClientController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierClientController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that allows to save a request for the delivery of products from a store to a warehouse.
        /// </summary>
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.Store2WhSave: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.Store2WhSave: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.Store2WhExecute: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).Store2WhExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.Store2WhExecute: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for starting the process of scanning the QR code on the order 
        /// to begin the delivery procedure.
        /// </summary>
        public string ScanQrOnOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.ScanQrOnOrderStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for scanning the QR code on the order to begin the delivery procedure.
        /// </summary>
        public string ScanQrOnOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).ScanQrOnOrderExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.ScanQrOnOrderExecute: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for starting the process of scanning the QR code on the backpack 
        /// to begin the delivery procedure.
        /// </summary>
        public string ScanBackpackStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanBackpackStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanBackpackStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.ScanBackpackStart: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for scanning the QR code on the backpack to begin the delivery procedure.
        /// </summary>
        public string ScanBackpackExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.ScanBackpackExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.ScanBackpackExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).ScanBackpackExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.ScanBackpackExecute: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for starting the order delivery process.
        /// </summary>
        public string DeliverOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.DeliverOrderStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.DeliverOrderStart: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).DeliverOrderExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: end");
            return response;
        }
    }
}