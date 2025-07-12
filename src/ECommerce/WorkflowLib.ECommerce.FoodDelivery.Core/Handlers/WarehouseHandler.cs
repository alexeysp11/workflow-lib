using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;
using WorkflowLib.ECommerce.FoodDelivery.Core.Dal;
using WorkflowLib.Shared.Models.Business.Cooking;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// Backend service controller that serves requests from the warehouse employees.
    /// </summary>
    public class WarehouseHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        private TimeSpan _wh2kitchenDuration;
        private TimeSpan _kitchen2whDuration;
        private TimeSpan _store2whDuration;
        private TimeSpan _prepareMealDuration;

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public WarehouseHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
            
            // Calculte delivery time.
            _wh2kitchenDuration = new TimeSpan(0, 5, 0);
            _kitchen2whDuration = new TimeSpan(0, 5, 0);
            _store2whDuration = new TimeSpan(0, 15, 0);
            _prepareMealDuration = new TimeSpan(0, 15, 0);
        }

        /// <summary>
        /// Method for determining the first action of personnel to process an order: for example, 1) transfer ingredients 
        /// from the warehouse to the kitchen or 2) create an order for the delivery of missing ingredients from the store 
        /// to the warehouse.
        /// </summary>
        public string PreprocessOrderRedirect(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);

                // Pseudo-randomly select executors from the warehouse and courier delivery departments.
                var rand = new System.Random();
                var responsibleEmployees = new Dictionary<string, Employee>();
                var userGroupNames = new List<string>() { "warehouse employee", "courier" };
                foreach (var userGroupName in userGroupNames)
                {
                    UserDao.GetResponsibleEmployeeByGroupName(context, userGroupName);
                    //responsibleEmployees.Add(userGroupName, selectedEmployee);
                }
                Employee whEmployee = responsibleEmployees[userGroupNames[0]];
                Employee courierEmployee = responsibleEmployees[userGroupNames[1]];

                // Create delivery order on warehouse.
                TimeSpan resultDuration = _wh2kitchenDuration + _kitchen2whDuration + _prepareMealDuration;
                DeliveryOrder? deliveryOrderStore2Wh = DeliveryOrderDao.CreateDeliveryOrderOnWh(
                    context,
                    deliveryOrder,
                    whEmployee,
                    courierEmployee);
                if (deliveryOrderStore2Wh == null)
                {
                    response = Wh2KitchenStart(deliveryOrder);
                }
                else
                {
                    resultDuration += _store2whDuration;
                    response = RequestStore2WhStart(deliveryOrderStore2Wh);
                }
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: end");
            return response;
        }
        
        /// <summary>
        /// A method that allows you to begin the process of delivering products from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.RequestStore2WhStart: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("WarehouseBackend.RequestStore2WhStart: update DB");

                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");
                
                // Get the products that should be delivered.
                List<DeliveryOrderProduct> deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(
                    context,
                    deliveryOrder.Id,
                    true);
                if (deliveryOrderProducts.Count() == 0)
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {deliveryOrder.Id})");

                // Notify warehouse employee to the deliver order.
                NotifyEmployeeDeliverStore2Wh(context, existedDeliveryOrder, deliveryOrderProducts);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.RequestStore2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that allows you to request the start of the process of delivering products
        /// from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhRespond(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Get the delivery order from DB.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");

                // Get the business tasks.
                List<BusinessTask?> businessTasks = BusinessTaskDao.GetBusinessTasksByDeliveryOrderId(
                    context,
                    deliveryOrder.Id,
                    BusinessTaskDiscriminator.RequestStore2Wh);
                if (businessTasks == null || !businessTasks.Any())
                    throw new Exception($"The collection of BusinessTask objects could not be null or empty (delivery order ID: {deliveryOrder.Id})");

                // Close the business tasks.
                BusinessTaskDao.CloseBusinessTasks(context, businessTasks);

                // Change the status of the corresponding delivery order.
                DeliveryOrderDao.ChangeDeliveryOrderStatus(context, existedDeliveryOrder, OrderStatus.Requested);

                // Send HTTP request.
                string backendResponse = new CourierHandler(_contextOptions).Store2WhStart(existedDeliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: end");
            return response;
        }
        
        /// <summary>
        /// A method that allows you to save the value of an incoming parameter 
        /// as part of the process of delivering products from the store to the warehouse. 
        /// </summary>
        public string Store2WhSave(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.Store2WhSave: begin");
            try
            {
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Send HTTP request.
                //string backendResponse = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation
                //{
                //    RequestObject = model
                //});

                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                {
                    throw new Exception($"Specified delivery order is not found");
                }

                // Get the products that should be delivered.
                List<DeliveryOrderProduct> deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(
                    context,
                    deliveryOrder.Id,
                    true);
                if (deliveryOrderProducts == null || !deliveryOrderProducts.Any())
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {deliveryOrder.Id})");

                // Notify employee to confirm the delivery order from store to warehouse.
                NotifyEmployeeConfirmStore2Wh(context, deliveryOrder, deliveryOrderProducts);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.Store2WhSave: end");
            return response;
        }

        /// <summary>
        /// A method that is responsible for confirming the delivery of products from the store to the warehouse.
        /// </summary>
        public string ConfirmStore2WhAccept(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: cache");

                // Close the business task that is related to the delivery order passed as a parameter.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");
                List<BusinessTask?> businessTasks = BusinessTaskDao.GetBusinessTasksByDeliveryOrderId(
                    context,
                    deliveryOrder.Id,
                    BusinessTaskDiscriminator.ConfirmStore2Wh);
                if (businessTasks == null || !businessTasks.Any())
                    throw new Exception($"The collection of BusinessTask objects could not be null or empty (delivery order ID: {deliveryOrder.Id})");

                // Close the business tasks.
                BusinessTaskDao.CloseBusinessTasks(context, businessTasks);

                // Change the status of the corresponding delivery order.
                existedDeliveryOrder.DateEndActual = DateTime.UtcNow;
                DeliveryOrderDao.ChangeDeliveryOrderStatus(context, existedDeliveryOrder, OrderStatus.Finished);

                // Get the parent delivery order that should be delivered from the warehouse to the kitchen.
                DeliveryOrder? parentDeliveryOrder = DeliveryOrderDao.GetParentDeliveryOrderById(context, deliveryOrder.Id);
                if (parentDeliveryOrder == null)
                    throw new Exception("Parent delivery order could not be null");
                DeliveryOrderDao.ChangeDeliveryOrderStatus(context, parentDeliveryOrder, OrderStatus.InProcess);
                
                // Start the step for delivering from warehouse to kitchen.
                response = Wh2KitchenStart(parentDeliveryOrder);
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: end");
            return response;
        }
        
        /// <summary>
        /// A method that allows you to begin the process of delivering products and ingredients from the warehouse to the kitchen.
        /// </summary>
        public string Wh2KitchenStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.Wh2KitchenStart: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");

                // Get the object related to the specified delivery order.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");

                // Getting the products that should be delivered.
                List<DeliveryOrderProduct> deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(
                    context,
                    deliveryOrder.Id,
                    true);
                if (deliveryOrderProducts.Count() == 0)
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {existedDeliveryOrder.Id})");

                // Notify responsible employee to deliver order from warehouse to kitchen.
                Notification notification = NotifyWh2KitchenStart(
                    context,
                    existedDeliveryOrder.Id,
                    deliveryOrderProducts);

                // Create the business task for delivering order from warehouse to kitchen.
                CreateWh2KitchenBusinessTask(context, existedDeliveryOrder, notification);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.Wh2KitchenStart: end");
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Wh2KitchenExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);

                // Close a business task that is associated with a delivery order.
                InitialOrder? initialOrder = InitialOrderDao.GetByDeliveryOrderId(context, deliveryOrder.Id);
                if (initialOrder == null)
                    throw new Exception($"Could not find the initial order (delivery order ID: {deliveryOrder.Id})");
                DeliveryOperation? deliveryWh2Kitchen = null;
                //DeliveryOperation deliveryWh2Kitchen = context.DeliveryOperations
                //    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id) && x.DeliveryOperationType == FoodDeliveryType.Wh2Kitchen.ToString())
                //    .FirstOrDefault();
                if (deliveryWh2Kitchen == null)
                    throw new Exception($"Could not find the business task DeliveryWh2Kitchen (delivery order ID: {deliveryOrder.Id})");
                BusinessTaskDao.CloseBusinessTasks(context, [deliveryWh2Kitchen]);

                string backendResponse = new KitchenHandler(_contextOptions).PrepareMealStart(deliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: end");
            return response;
        }
        
        /// <summary>
        /// A method that allows you to begin the process of delivering finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.Kitchen2WhStart: begin");
            try
            {
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Get initial order by delivery order ID.
                DeliveryOrder? existedDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id);
                if (existedDeliveryOrder == null)
                    throw new Exception($"Delivery order could not be null (delivery order ID: {deliveryOrder.Id})");
                InitialOrder? initialOrder = InitialOrderDao.GetByDeliveryOrderId(context, existedDeliveryOrder.Id);
                if (initialOrder == null)
                    throw new Exception($"Initial order could not be null (delivery order ID: {deliveryOrder.Id})");

                // Getting the products that should be delivered.
                List<DeliveryOrderProduct> deliveryOrderProducts = DeliveryOrderDao.GetDeliveryOrderProducts(
                    context,
                    deliveryOrder.Id,
                    true);
                if (deliveryOrderProducts.Count() == 0)
                    throw new Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {deliveryOrder.Id})");

                NotifyKitchen2WhStart(context, existedDeliveryOrder, deliveryOrderProducts);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.Kitchen2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that is responsible for controlling the delivery of finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Update DB.
                Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: cache");

                // Close a business task that is associated with a delivery order.
                InitialOrder? initialOrder = InitialOrderDao.GetByDeliveryOrderId(context, deliveryOrder.Id);
                if (initialOrder == null)
                    throw new Exception($"Could not find the initial order (delivery order ID: {deliveryOrder.Id})");
                DeliveryOperation? deliveryKitchen2Wh = null;
                //var deliveryKitchen2Wh = context.DeliveryOperations
                //    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id) && x.DeliveryOperationType == FoodDeliveryType.Kitchen2Wh.ToString())
                //    .FirstOrDefault();
                if (deliveryKitchen2Wh == null)
                    throw new Exception($"Could not find the business task DeliveryKitchen2Wh (delivery order ID: {deliveryOrder.Id})");
                BusinessTaskDao.CloseBusinessTasks(context, [deliveryKitchen2Wh]);

                // Send HTTP request.
                string backendResponse = new CourierHandler(_contextOptions).DeliverOrderStart(deliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: end");
            return response;
        }
        
        /// <summary>
        /// Get warehouse employee randomly.
        /// </summary>
        private Employee GetWarehouseEmployeeRandomly()
        {
            //using var context = new FoodDeliveryDbContext(_contextOptions);
            //var rand = new System.Random();
            //var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "warehouse employee");
            //if (userGroup == null)
            //    throw new Exception($"Specified user group is not defined");
            //var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
            //var potentialExecutors = 
            //    (from employee in context.Employees 
            //    where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
            //    select employee).ToList();
            //if (potentialExecutors == null || !potentialExecutors.Any())
            //    throw new Exception($"The list of potential executors is null or empty");
            //var selectedEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
            //if (selectedEmployee == null)
            //    throw new Exception($"Randomly selected employee is null");
            //return selectedEmployee;
            return new Employee();
        }

        /// <summary>
        /// Notify warehouse employee to the deliver order.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrder">Delivery order</param>
        /// <param name="deliveryOrderProducts">Delivery order products</param>
        /// <returns></returns>
        private void NotifyEmployeeDeliverStore2Wh(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            List<DeliveryOrderProduct> deliveryOrderProducts)
        {
            // Get sender and receiver of the notification.
            UserAccount? adminUser = UserDao.GetAdminUserAccount(context);
            if (adminUser == null)
                throw new Exception("Admin user could not be null");
            Employee warehouseEmployee = GetWarehouseEmployeeRandomly();

            // Title text.
            var sbMessageText = new StringBuilder();
            sbMessageText.Append("RequestStore2Wh: request delivery of order #").Append(deliveryOrder.Id.ToString()).Append(" from the store to the warehouse");
            string titleText = sbMessageText.ToString();
            sbMessageText.Clear();

            // Body text.
            sbMessageText.Append("Please be informed that you are responsible for requesting delivery of order #");
            sbMessageText.Append(deliveryOrder.Id.ToString());
            sbMessageText.Append(" from the store to the warehouse.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("The system automatically determined that the warehouse is short of the following products:\n");
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
            }
            sbMessageText.Append("\n");
            sbMessageText.Append("Please check that the list of products required for delivery is correct and confirm your request.\n");

            // Create notification object.
            var notification = new Notification
            {
                SenderId = adminUser.Id,
                ReceiverId = warehouseEmployee.Id,
                TitleText = titleText,
                BodyText = sbMessageText.ToString()
            };

            // Create a business task for requesting delivery of order from the store to the warehouse.
            BusinessTaskDao.CreateStore2WhBusinessTask(context, deliveryOrder, notification);

            // Notify warehouse employee.
            new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
            {
                notification
            });
        }

        /// <summary>
        /// Notify employee to confirm the delivery order from store to warehouse.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrder"></param>
        private void NotifyEmployeeConfirmStore2Wh(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            List<DeliveryOrderProduct> deliveryOrderProducts)
        {
            // Get sender and receiver of the notification.
            var adminUser = context.UserAccounts.FirstOrDefault();
            if (adminUser == null)
                throw new Exception("Admin user could not be null");
            var warehouseEmployee = GetWarehouseEmployeeRandomly();

            // Title text.
            var sbMessageText = new StringBuilder();
            sbMessageText.Append("ConfirmStore2Wh: confirm delivery of order #").Append(deliveryOrder.Id.ToString()).Append(" from the store to the warehouse");
            string titleText = sbMessageText.ToString();
            sbMessageText.Clear();

            // Body text.
            sbMessageText.Append("Please be informed that you are responsible for confirming delivery of order #");
            sbMessageText.Append(deliveryOrder.Id.ToString());
            sbMessageText.Append(" from the store to the warehouse.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("Products for delivery:\n");
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
            }
            
            // Create notification object.
            var notification = new Notification
            {
                SenderId = adminUser.Id,
                ReceiverId = warehouseEmployee.Id,
                TitleText = titleText,
                BodyText = sbMessageText.ToString()
            };

            // Create a business task for requesting delivery of order from the store to the warehouse.
            var businessTask = new BusinessTask
            {
                Uid = Guid.NewGuid().ToString(),
                Name = notification.TitleText,
                Subject = notification.TitleText,
                Description = notification.BodyText,
                Status = BusinessTaskStatus.Open
            };
            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = deliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.ConfirmStore2Wh)
            };
            context.BusinessTasks.Add(businessTask);
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
            context.SaveChanges();

            // Notify warehouse employee.
            new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
            {
                notification
            });
        }

        /// <summary>
        /// Create the business task for delivering order from warehouse to kitchen.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="existedDeliveryOrder">Delivery order</param>
        /// <param name="notification">Notification</param>
        private void CreateWh2KitchenBusinessTask(
            FoodDeliveryDbContext context,
            DeliveryOrder existedDeliveryOrder,
            Notification notification)
        {
            InitialOrder? initialOrder = context.InitialOrders
                .FirstOrDefault(x => x.DeliveryOrderId == existedDeliveryOrder.Id);
            if (initialOrder == null)
                throw new Exception("Initial order could not be null");

            List<InitialOrderProduct> initialOrderProducts = context.InitialOrderProducts
                .Where(x => x.InitialOrder.Id == initialOrder.Id)
                .ToList();
            if (initialOrderProducts == null || !initialOrderProducts.Any())
                throw new Exception("List of products that is related to the initial order could not be null or empty");

            List<InitialOrderIngredient> initialOrderIngredients = context.InitialOrderIngredients
                .Where(x => x.InitialOrder.Id == initialOrder.Id)
                .ToList();
            if (initialOrderIngredients == null || !initialOrderIngredients.Any())
                throw new Exception("List of ingredients that is related to the initial order could not be null or empty");

            var businessTask = new DeliveryOperation
            {
                Uid = Guid.NewGuid().ToString(),
                Name = notification.TitleText,
                Subject = notification.TitleText,
                Description = notification.BodyText,
                Status = BusinessTaskStatus.Open,
                DeliveryOperationType = FoodDeliveryType.Wh2Kitchen.ToString()
                //InitialOrders = new List<InitialOrder>
                //{
                //    initialOrder
                //},
                //InitialOrderProducts = initialOrderProducts,
                //InitialOrderIngredients = initialOrderIngredients
            };

            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = existedDeliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.DeliveryOperation)
            };

            context.DeliveryOperations.Add(businessTask);
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);

            context.SaveChanges();
        }

        /// <summary>
        /// Notify responsible employee to deliver order from warehouse to kitchen.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <param name="deliveryOrderProducts"></param>
        private Notification NotifyWh2KitchenStart(
            FoodDeliveryDbContext context,
            long deliveryOrderId,
            List<DeliveryOrderProduct> deliveryOrderProducts)
        {
            // Get sender and receiver of the notification.
            UserAccount? adminUser = context.UserAccounts.FirstOrDefault();
            if (adminUser == null)
                throw new Exception("Admin user could not be null");
            Employee warehouseEmployee = GetWarehouseEmployeeRandomly();

            // Title text.
            var sbMessageText = new StringBuilder();
            sbMessageText.Append("Wh2Kitchen: deliver order #").Append(deliveryOrderId.ToString()).Append(" from the warehouse to the kitchen");
            string titleText = sbMessageText.ToString();
            sbMessageText.Clear();

            // Body text.
            sbMessageText.Append("Please be informed that you are responsible for shipping order #");
            sbMessageText.Append(deliveryOrderId.ToString());
            sbMessageText.Append(" from the warehouse to the kitchen.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("Products for delivery:\n");
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
            }

            // Notify warehouse employee.
            var notification = new Notification
            {
                SenderId = adminUser.Id,
                ReceiverId = warehouseEmployee.Id,
                TitleText = titleText,
                BodyText = sbMessageText.ToString()
            };
            new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
            {
                notification
            });

            return notification;
        }

        /// <summary>
        /// Notify about delivery from kitchen to warehouse.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="deliveryOrder"></param>
        private void NotifyKitchen2WhStart(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            List<DeliveryOrderProduct> deliveryOrderProducts)
        {
            // Get sender and receiver of the notification.
            var adminUser = context.UserAccounts.FirstOrDefault();
            if (adminUser == null)
                throw new Exception("Admin user could not be null");
            var warehouseEmployee = GetWarehouseEmployeeRandomly();

            // Title text.
            var sbMessageText = new StringBuilder();
            sbMessageText.Append("Kitchen2Wh: deliver order #").Append(deliveryOrder.Id.ToString()).Append(" from the kitchen to the warehouse");
            string titleText = sbMessageText.ToString();
            sbMessageText.Clear();

            // Body text.
            sbMessageText.Append("Please be informed that you are responsible for shipping order #");
            sbMessageText.Append(deliveryOrder.Id.ToString());
            sbMessageText.Append(" from the kitchen to the warehouse.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("Products for delivery:\n");
            foreach (var deliveryOrderProduct in deliveryOrderProducts)
            {
                sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
            }

            // Notify warehouse employee.
            var notification = new Notification
            {
                SenderId = adminUser.Id,
                ReceiverId = warehouseEmployee.Id,
                TitleText = titleText,
                BodyText = sbMessageText.ToString()
            };
            new NotificationsHandler(_contextOptions).SendNotifications(new List<Notification>
                {
                    notification
                });

            // Create DeliveryKitchen2Wh object.
            var businessTask = new DeliveryOperation
            {
                Uid = Guid.NewGuid().ToString(),
                Name = notification.TitleText,
                Subject = notification.TitleText,
                Description = notification.BodyText,
                //InitialOrders = new List<InitialOrder>
                //{
                //    initialOrder
                //},
                Status = BusinessTaskStatus.Open,
                DeliveryOperationType = FoodDeliveryType.Kitchen2Wh.ToString()
            };
            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = deliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.DeliveryOperation)
            };
            context.DeliveryOperations.Add(businessTask);
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
            context.SaveChanges();
        }
    }
}