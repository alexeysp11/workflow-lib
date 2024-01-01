using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the courier.
    /// </summary>
    public class CourierBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region store2wh
        /// <summary>
        /// A method that allows to save a request for the delivery of products from a store to a warehouse.
        /// </summary>
        public string Store2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhStart: cache");
                
                // Notify courier employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Deliver from store to warehouse",
                        BodyText = ""
                    }
                });

                // Update cache in the client-side app.
                string deliveryRequest = new CourierClientController(_contextOptions).Store2WhStart(new ApiOperation()
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
            System.Console.WriteLine("CourierBackend.Store2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhExecute: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhExecute: cache");

                // Update cache in the client-side app.
                string deliveryRequest = new WarehouseBackendController(_contextOptions).Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("CourierBackend.Store2WhExecute: end");
            return response;
        }
        #endregion  // store2wh

        #region scanqronorder
        /// <summary>
        /// The method that is responsible for starting the process of scanning the QR code on the order 
        /// to begin the delivery procedure.
        /// </summary>
        public string ScanQrOnOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController(_contextOptions).ScanQrOnOrderStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for scanning the QR code on the order to begin the delivery procedure.
        /// </summary>
        public string ScanQrOnOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderExecute: begin");
            try
            {
                // Initializing.
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
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.ScanQrOnOrderExecute: end");
            return response;
        }
        #endregion  // scanqronorder

        #region scanbackpack
        /// <summary>
        /// The method that is responsible for starting the process of scanning the QR code on the backpack 
        /// to begin the delivery procedure.
        /// </summary>
        public string ScanBackpackStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanBackpackStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.ScanBackpackStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController(_contextOptions).ScanBackpackStart(new ApiOperation
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
            System.Console.WriteLine("CourierBackend.ScanBackpackStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for scanning the QR code on the backpack to begin the delivery procedure.
        /// </summary>
        public string ScanBackpackExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.ScanBackpackExecute: begin");
            try
            {
                // Initializing.
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
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.ScanBackpackExecute: end");
            return response;
        }
        #endregion  // scanbackpack

        #region deliverorder
        /// <summary>
        /// The method that is responsible for starting the order delivery process.
        /// </summary>
        public string DeliverOrderStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;

                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController(_contextOptions).DeliverOrderStart(new ApiOperation
                {
                    RequestObject = model
                });

                // Notify the customer.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Your order is on deliver",
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
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: end");
            return response;
        }
        #endregion  // deliverorder
    }
}