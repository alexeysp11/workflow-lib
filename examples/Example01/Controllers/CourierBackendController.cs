using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Enums;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the courier.
    /// </summary>
    public class CourierBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private Notification Notification { get; set; }

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
                if (model == null)
                    throw new System.ArgumentNullException("apiOperation.RequestObject");
                using var context = new DeliveringContext(_contextOptions);

                // Get all the objects related to the specified delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.ArgumentNullException("deliveryOrder");

                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhStart: cache");

                // Update cache in the client-side app.
                string deliveryRequest = new CourierClientController(_contextOptions).Store2WhStart(new ApiOperation()
                {
                    RequestObject = model
                });
                NotifyDeliveryOrder(model, "Store2Wh");
                
                // Create a DeliveryOperation object and associate it with the delivery order.
                var deliveryOperation = new DeliveryOperation
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = Notification.TitleText,
                    Subject = Notification.TitleText,
                    Description = Notification.BodyText,
                    CustomerName = deliveryOrder.CustomerName,
                    Origin = deliveryOrder.Origin,
                    Destination = deliveryOrder.Destination,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                deliveryOrder.DeliveryOperation = deliveryOperation;
                context.DeliveryOperations.Add(deliveryOperation);
                context.SaveChanges();

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
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderStart: cache");

                // Send HTTP request.
                string backendResponse = new CourierClientController(_contextOptions).DeliverOrderStart(new ApiOperation
                {
                    RequestObject = model
                });
                NotifyDeliveryOrder(model, "DeliverOrder");

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

        private string NotifyDeliveryOrder(DeliveryOrder model, string stageName)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.NotifyDeliveryOrder: begin");
            try
            {
                if (model == null)
                    throw new System.Exception("Delivery oder could not be null");
                if (string.IsNullOrEmpty(model.CustomerUid))
                    throw new System.Exception($"CustomerUid could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.CustomerName))
                    throw new System.Exception($"CustomerName could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.ExecutorUid))
                    throw new System.Exception($"ExecutorUid could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.ExecutorName))
                    throw new System.Exception($"ExecutorName could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                
                using var context = new DeliveringContext(_contextOptions);

                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var courierEmployee = context.Employees
                    .Include(x => x.UserAccounts)
                    .FirstOrDefault(x => x.Uid == model.ExecutorUid);
                if (courierEmployee == null)
                    throw new System.Exception("Courier employee could not be null");
                var courierUser = courierEmployee.UserAccounts.FirstOrDefault();
                if (courierUser == null)
                    throw new System.Exception("Courier user could not be null");

                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append(stageName).Append(": deliver order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Ordering information:\n");
                sbMessageText.Append("UID: ").Append(model.Uid).Append(".\n");
                sbMessageText.Append("Creation date: ").Append(model.OpenOrderDt.ToString()).Append(".\n");
                sbMessageText.Append("Order author: ").Append(model.OrderCustomerType.ToString()).Append(" ").Append(model.CustomerName).Append(".\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                sbMessageText.Append("\n");
                sbMessageText.Append("Approximate price for products: $").Append(model.ProductsPrice.ToString()).Append("\n");

                // Notify the customer.
                Notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = courierUser.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    Notification
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.NotifyDeliveryOrder: end");
            return response;
        }
    }
}