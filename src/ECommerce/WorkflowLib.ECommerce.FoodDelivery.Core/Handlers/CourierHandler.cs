using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// Backend service controller that serves requests from the courier.
    /// </summary>
    public class CourierHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        private Notification Notification { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that allows to save a request for the delivery of products from a store to a warehouse.
        /// </summary>
        public string Store2WhStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierBackend.Store2WhStart: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);

                // Get the object related to the specified delivery order.
                var existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");

                // Update DB.
                Console.WriteLine("CourierBackend.Store2WhStart: cache");
                
                // Create a DeliveryOperation object and associate it with the delivery order.
                NotifyDeliverOrder(deliveryOrder, "Store2Wh");
                CreateDeliveryTaskStore2WhStart(context, existedDeliveryOrder, Notification);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierBackend.Store2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierBackend.Store2WhExecute: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("CourierBackend.Store2WhExecute: cache");

                // Close the related business tasks.
                List<BusinessTask?> deliveryOperations = DeliveryOrderDao.GetBusinessTaskDeliveryOrders(
                    context,
                    deliveryOrderId: deliveryOrder.Id);
                BusinessTaskDao.CloseBusinessTasks(context, deliveryOperations);

                // Notify warehouse backend controller.
                string deliveryRequest = new WarehouseHandler(_contextOptions).Store2WhSave(deliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierBackend.Store2WhExecute: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for starting the order delivery process.
        /// </summary>
        public string DeliverOrderStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierBackend.DeliverOrderStart: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("CourierBackend.DeliverOrderStart: cache");

                // Get the object related to the specified delivery order.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");

                // Create a DeliveryOperation object and associate it with the delivery order.
                NotifyDeliverOrder(deliveryOrder, "DeliverOrder");
                CreateDeliveryTaskDeliverStart(context, existedDeliveryOrder, Notification);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierBackend.DeliverOrderStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierBackend.DeliverOrderExecute: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("CourierBackend.DeliverOrderExecute: cache");

                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order is not defined (delivery order ID: {deliveryOrder.Id})");

                // Close the related business tasks.
                List<BusinessTask?> deliveryOperations = BusinessTaskDao.GetBusinessTaskDeliveryOrders(context, existedDeliveryOrder.Id);
                BusinessTaskDao.CloseBusinessTasks(context, deliveryOperations);
                existedDeliveryOrder.DateEndActual = DateTime.UtcNow;
                existedDeliveryOrder.Status = EnumExtensions.GetDisplayName(OrderStatus.Finished);
                context.SaveChanges();

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierBackend.DeliverOrderExecute: end");
            return response;
        }

        /// <summary>
        /// Notify about delivery order.
        /// </summary>
        /// <param name="deliveryOrder"></param>
        /// <param name="stageName"></param>
        /// <returns></returns>
        private string NotifyDeliverOrder(DeliveryOrder deliveryOrder, string stageName)
        {
            string response = "";
            Console.WriteLine("CourierBackend.NotifyDeliveryOrder: begin");
            try
            {
                if (deliveryOrder == null)
                    throw new Exception("Delivery oder could not be null");
                if (string.IsNullOrEmpty(deliveryOrder.CustomerUid))
                    throw new Exception($"CustomerUid could not be null or empty in the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                if (string.IsNullOrEmpty(deliveryOrder.CustomerName))
                    throw new Exception($"CustomerName could not be null or empty in the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                if (string.IsNullOrEmpty(deliveryOrder.ExecutorUid))
                    throw new Exception($"ExecutorUid could not be null or empty in the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                if (string.IsNullOrEmpty(deliveryOrder.ExecutorName))
                    throw new Exception($"ExecutorName could not be null or empty in the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                
                using var context = new FoodDeliveryDbContext(_contextOptions);

                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new Exception($"Admin user could not be null (delivery order ID: {deliveryOrder.Id})");
                Employee courierEmployee = null;
                if (deliveryOrder.OrderExecutorType == OrderExecutorType.Employee)
                {
                    //courierEmployee = context.Employees
                    //    .Include(x => x.UserAccounts)
                    //    .FirstOrDefault(x => x.Uid == model.ExecutorUid);
                }
                else
                {
                    var rand = new System.Random();

                    //var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "courier");
                    //if (userGroup == null)
                    //    throw new Exception($"Specified user group is not defined (delivery order ID: {model.Id})");

                    //var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                    //var potentialExecutors = 
                    //    (from employee in context.Employees 
                    //    where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                    //    select employee).ToList();
                    //if (potentialExecutors == null || !potentialExecutors.Any())
                    //    throw new Exception($"The list of potential executors is null or empty (delivery order ID: {model.Id})");
                    
                    //courierEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                    if (courierEmployee == null)
                        throw new Exception($"Randomly selected employee is null (delivery order ID: {deliveryOrder.Id})");
                }
                if (courierEmployee == null)
                    throw new Exception($"Courier employee could not be null (delivery order ID: {deliveryOrder.Id})");
                //var courierUser = courierEmployee.UserAccounts.FirstOrDefault();
                //if (courierUser == null)
                //    throw new Exception($"Courier user could not be null (delivery order ID: {model.Id})");

                // Getting the products that should be delivered.
                var deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(context, deliveryOrder.Id, true);
                if (deliveryOrderProducts.Count() == 0)
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {deliveryOrder.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append(stageName).Append(": deliver order #").Append(deliveryOrder.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(deliveryOrder.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Ordering information:\n");
                sbMessageText.Append("UID: ").Append(deliveryOrder.Uid).Append(".\n");
                sbMessageText.Append("Creation date: ").Append(deliveryOrder.DateStartActual.ToString()).Append(".\n");
                sbMessageText.Append("Order author: ").Append(deliveryOrder.OrderCustomerType.ToString()).Append(" ").Append(deliveryOrder.CustomerName).Append(".\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                sbMessageText.Append("\n");
                sbMessageText.Append("Approximate price for products: $").Append(deliveryOrder.ProductsPrice.ToString()).Append("\n");

                // Notify the customer.
                Notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = 0, //courierUser.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
                {
                    Notification
                });

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierBackend.NotifyDeliveryOrder: end");
            return response;
        }

        /// <summary>
        /// Create business task for delivering from store to warehouse.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="existedDeliveryOrder"></param>
        /// <param name="notification"></param>
        private void CreateDeliveryTaskStore2WhStart(
            FoodDeliveryDbContext context,
            DeliveryOrder existedDeliveryOrder,
            Notification notification)
        {
            var businessTask = new DeliveryOperation
            {
                Uid = Guid.NewGuid().ToString(),
                Name = Notification.TitleText,
                Subject = Notification.TitleText,
                Description = Notification.BodyText,
                CustomerName = existedDeliveryOrder.CustomerName,
                Origin = existedDeliveryOrder.Origin,
                Destination = existedDeliveryOrder.Destination,
                Status = BusinessTaskStatus.Open
            };
            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = existedDeliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.DeliveryOperation)
            };
            // deliveryOrder.DeliveryOperation = businessTask;
            context.DeliveryOperations.Add(businessTask);
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
            context.SaveChanges();
        }

        /// <summary>
        /// Create business task for delivering order.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="existedDeliveryOrder"></param>
        /// <param name="notification"></param>
        private void CreateDeliveryTaskDeliverStart(
            FoodDeliveryDbContext context,
            DeliveryOrder existedDeliveryOrder,
            Notification notification)
        {
            var businessTask = new DeliveryOperation
            {
                Uid = Guid.NewGuid().ToString(),
                Name = Notification.TitleText,
                Subject = Notification.TitleText,
                Description = Notification.BodyText,
                CustomerName = existedDeliveryOrder.CustomerName,
                Origin = existedDeliveryOrder.Origin,
                Destination = existedDeliveryOrder.Destination,
                Status = BusinessTaskStatus.Open
            };
            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = existedDeliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.DeliveryOperation)
            };
            // deliveryOrder.DeliveryOperation = businessTask;
            context.DeliveryOperations.Add(businessTask);
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
            context.SaveChanges();
        }
    }
}