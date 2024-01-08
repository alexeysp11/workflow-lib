using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Cooking;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Enums;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the kitchen employees.
    /// </summary>
    public class KitchenBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public KitchenBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that is responsible for storing information necessary for the preparation of an order by kitchen staff.
        /// </summary>
        public string PrepareMealStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                if (model == null)
                    throw new System.ArgumentNullException("apiOperation.RequestObject");
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");
                
                // Get initial order, and the products that should be delivered, by delivery order ID.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == deliveryOrder.Id);
                if (initialOrder == null)
                    throw new System.Exception($"Initial order could not be null (delivery order ID: {model.Id})");
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("PrepareMeal: preparing order #").Append(model.Id.ToString());
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for preparing order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(".\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }

                // Send request to the notifications backend.
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = 2,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                string notificationsRequest = new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    notification
                });

                // Create the cooking operation object.
                var cookingOperation = new CookingOperation
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    InitialOrders = new List<InitialOrder>
                    {
                        initialOrder
                    },
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                context.CookingOperations.Add(cookingOperation);
                context.SaveChanges();
                
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

        /// <summary>
        /// The method that the kitchen staff is responsible for preparing the order.
        /// </summary>
        public string PrepareMealExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealExecute: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                if (model == null)
                    throw new System.ArgumentNullException("apiOperation.RequestObject");
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: cache");

                // Close a business task that is associated with a delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == deliveryOrder.Id);
                if (initialOrder == null)
                    throw new System.Exception($"Initial order could not be null (delivery order ID: {model.Id})");
                var cookingOperation = context.CookingOperations
                    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id))
                    .FirstOrDefault();
                if (cookingOperation == null)
                    throw new System.Exception($"Could not find the business task CookingOperation (delivery order ID: {model.Id})");
                cookingOperation.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                context.SaveChanges();

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