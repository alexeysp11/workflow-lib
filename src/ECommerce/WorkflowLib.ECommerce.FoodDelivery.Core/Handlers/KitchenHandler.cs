using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Cooking;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// Backend service controller that serves requests from the kitchen employees.
    /// </summary>
    public class KitchenHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public KitchenHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that is responsible for storing information necessary for the preparation of an order by kitchen staff.
        /// </summary>
        public string PrepareMealStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("KitchenBackend.PrepareMealStart: begin");
            try
            {
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Get initial order, and the products that should be delivered, by delivery order ID.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrderId == existedDeliveryOrder.Id);
                if (initialOrder == null)
                    throw new Exception($"Initial order could not be null (delivery order ID: {deliveryOrder.Id})");
                List<DeliveryOrderProduct> deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(
                    context,
                    deliveryOrder.Id,
                    true);
                if (deliveryOrderProducts.Count() == 0)
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                
                // Get sender and receiver of the notification.
                var rand = new System.Random();
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new Exception("Admin user could not be null");
                //var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "kitchen employee");
                //if (userGroup == null)
                //    throw new Exception($"Specified user group is not defined (delivery order ID: {model.Id})");
                //var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                //var potentialExecutors = 
                //    (from employee in context.Employees 
                //    where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                //    select employee).ToList();
                //if (potentialExecutors == null || !potentialExecutors.Any())
                //    throw new Exception($"The list of potential executors is null or empty (delivery order ID: {model.Id})");
                //var kitchenEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                Employee? kitchenEmployee = null;
                if (kitchenEmployee == null)
                    throw new Exception($"Randomly selected employee is null (delivery order ID: {deliveryOrder.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("PrepareMeal: preparing order #").Append(deliveryOrder.Id.ToString());
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for preparing order #");
                sbMessageText.Append(deliveryOrder.Id.ToString());
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
                    ReceiverId = kitchenEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                string notificationsRequest = new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
                {
                    notification
                });

                // Create the cooking operation object.
                var businessTask = new CookingOperation
                {
                    Uid = Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    InitialOrders = new List<InitialOrder>
                    {
                        initialOrder
                    },
                    Status = BusinessTaskStatus.Open
                };
                var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
                {
                    Uid = Guid.NewGuid().ToString(),
                    BusinessTask = businessTask,
                    DeliveryOrder = existedDeliveryOrder,
                    Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.CookingOperation)
                };
                context.CookingOperations.Add(businessTask);
                context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
                context.SaveChanges();
                
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("KitchenBackend.PrepareMealStart: end");
            return response;
        }

        /// <summary>
        /// The method that the kitchen staff is responsible for preparing the order.
        /// </summary>
        public string PrepareMealExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("KitchenBackend.PrepareMealExecute: begin");
            try
            {
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Close a business task that is associated with a delivery order.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");
                InitialOrder? initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrderId == existedDeliveryOrder.Id);
                if (initialOrder == null)
                    throw new Exception($"Initial order could not be null (delivery order ID: {existedDeliveryOrder.Id})");
                var cookingOperation = context.CookingOperations
                    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id))
                    .FirstOrDefault();
                if (cookingOperation == null)
                    throw new Exception($"Could not find the business task CookingOperation (delivery order ID: {existedDeliveryOrder.Id})");
                cookingOperation.Status = BusinessTaskStatus.Closed;
                context.SaveChanges();

                // Send HTTP request.
                string backendResponse = new WarehouseHandler(_contextOptions).Kitchen2WhStart(existedDeliveryOrder);
                
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("KitchenBackend.PrepareMealExecute: end");
            return response;
        }
    }
}