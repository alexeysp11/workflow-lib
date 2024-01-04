using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the warehouse employees.
    /// </summary>
    public class WarehouseBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public WarehouseBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region preprocessorder
        /// <summary>
        /// Method for determining the first action of personnel to process an order: for example, 1) transfer ingredients 
        /// from the warehouse to the kitchen or 2) create an order for the delivery of missing ingredients from the store 
        /// to the warehouse.
        /// </summary>
        public string PreprocessOrderRedirect(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                using var context = new DeliveringContext(_contextOptions);

                // Get ingredients amount from DB.
                int ingredientsAmount = 0;
                bool isSufficient = true;

                // Find corresponding records in the DeliveryOrderProduct table by order ID (a table of associations between 
                // the Product, DeliveryOrder and Quantity).
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Include(x => x.DeliveryOrder)
                    .Where(x => x.DeliveryOrder.Id == model.Id);
                var productIds = (from product in deliveryOrderProducts select product.Product.Id).ToList();

                // Using product IDs from the order, find the corresponding products in the WHProduct warehouse. It will be more 
                // relevant for those products that need to be stored in a warehouse in finished form (for example, drinks, snacks).
                // var whproducts = context.WHProducts.Where(x => productIds.Any(pid => pid == x.Product.Id));

                // Using the product IDs from the Product order, find the corresponding records in the Ingredients table (look 
                // at the link to the object FinalProduct). This will allow you to find:
                //     1) corresponding records in the Recipes table (if it is necessary to check the relevance of the recipe 
                // by the BusinessEntityStatus value);
                //     2) products that correspond to the ingredient (look at the link to the IngredientProduct object).
                var ingredients = context.Ingredients
                    .Include(x => x.IngredientProduct)
                    .Include(x => x.FinalProduct)
                    .Where(x => productIds.Any(pid => pid == x.FinalProduct.Id));
                var ingredientProductIds = (from ingredient in ingredients select ingredient.IngredientProduct.Id).ToList();

                // Pseudo-randomly select executors from the warehouse and courier delivery departments.
                var rand = new System.Random();
                var responsibleEmployees = new Dictionary<string, Employee>();
                var userGroupNames = new List<string>() { "warehouse employee", "courier" };
                foreach (var userGroupName in userGroupNames)
                {
                    var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == userGroupName);
                    if (userGroup == null)
                        throw new System.Exception("Specified user group is not defined");

                    var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                    var potentialExecutors = 
                        (from employee in context.Employees 
                        where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                        select employee).ToList();
                    if (potentialExecutors == null || !potentialExecutors.Any())
                        throw new System.Exception("The list of potential executors is null or empty");
                    
                    var selectedEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                    if (selectedEmployee == null)
                        throw new System.Exception("Randomly selected employee is null");
                    
                    responsibleEmployees.Add(userGroupName, selectedEmployee);
                }
                var whEmployee = responsibleEmployees[userGroupNames[0]];
                var courierEmployee = responsibleEmployees[userGroupNames[1]];

                // Based on product IDs and corresponding ingredients, you can:
                //     1) find the corresponding products in the WHProduct warehouse;
                //     2) create a product transfer ProductTransfer, specifying the quantity DeliveryOrderProduct.Quantity as 
                // QuantityDelta (all other fields must also be filled in);
                //     3) subtract the quantity DeliveryOrderProduct.Quantity from the quantity of products in the warehouse 
                // WHProduct.Quantity multiplied by Ingredient.Quantity;
                //     4) compare the number of products that are currently in stock with the minimum quantity WHProduct.MinQuantity:
                //             - if WHProduct.Quantity is greater than or equal to WHProduct.MinQuantity, then deliver from the 
                // warehouse to the kitchen;
                //             - if WHProduct.Quantity is less than WHProduct.MinQuantity, then create DeliveryOrder and 
                // DeliveryOrderProduct objects in order to order delivery from the store (the quantity of each product in the order 
                // is equal to the delta between the actual current value of WHProduct.Quantity and the average of WHProduct.MinQuantity 
                // and WHProduct.MaxQuantity).
                // Attention: Point 4 (see the general description of working with data structures) does not take into account 
                // a situation that can slow down the business process of order processing if WHProduct.Quantity is less than 
                // WHProduct.MinQuantity and greater than zero.
                // In this case, it is necessary to both start the delivery process from the warehouse to the kitchen and order 
                // delivery from the store.
                var whingredients = context.WHProducts
                    .Include(x => x.Product)
                    .Where(x => ingredientProductIds.Any(pid => pid == x.Product.Id));
                var deliveryOrderStore2Wh = new DeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    ParentDeliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id),
                    CustomerUid = whEmployee.Uid,
                    CustomerName = whEmployee.FullName,
                    OrderCustomerType = OrderCustomerType.Employee,
                    ExecutorUid = courierEmployee.Uid,
                    ExecutorName = courierEmployee.FullName,
                    OrderExecutorType = OrderExecutorType.Employee,
                    Destination = model.Origin,
                    OpenOrderDt = System.DateTime.Now
                };
                var deliveryOrderProductsStore2Wh = new List<DeliveryOrderProduct>();
                foreach (var whingredient in whingredients)
                {
                    var ingredient = ingredients.FirstOrDefault(x => x.IngredientProduct.Id == whingredient.Product.Id);
                    if (ingredient == null)
                        throw new System.Exception("Specified ingredient does not exist in the collection");
                    
                    var deliveryOrderProduct = deliveryOrderProducts.FirstOrDefault(x => x.Product.Id == ingredient.FinalProduct.Id);
                    if (deliveryOrderProduct == null)
                        throw new System.Exception("Specified IngredientProduct does not exist in the DeliveryOrderProducts collection");
                    
                    var qtyDelta = deliveryOrderProduct.Quantity * ingredient.Quantity;
                    var productTransfer = new ProductTransfer
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        WHProduct = whingredient,
                        DeliveryOrderProduct = deliveryOrderProduct,
                        DeliveryOrder = deliveryOrderProduct.DeliveryOrder,
                        Date = System.DateTime.Now,
                        OldQuantity = whingredient.Quantity,
                        NewQuantity = whingredient.Quantity - qtyDelta,
                        QuantityDelta = qtyDelta
                    };
                    whingredient.Quantity = (int)productTransfer.NewQuantity;
                    if (whingredient.Quantity < whingredient.MinQuantity)
                    {
                        isSufficient = false;
                        var whingredientLimits = new List<int> { whingredient.MinQuantity, whingredient.MaxQuantity };
                        var deliveryOrderProductStore2Wh = new DeliveryOrderProduct
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            Product = whingredient.Product,
                            DeliveryOrder = deliveryOrderStore2Wh,
                            Quantity = (int)whingredientLimits.Average() - whingredient.Quantity
                        };
                        deliveryOrderProductsStore2Wh.Add(deliveryOrderProductStore2Wh);
                    }
                    context.ProductTransfers.Add(productTransfer);
                }
                if (!isSufficient)
                {
                    deliveryOrderStore2Wh.ProductsPrice = deliveryOrderProductsStore2Wh.Sum(x => x.Product.Price * x.Quantity);
                    context.DeliveryOrders.Add(deliveryOrderStore2Wh);
                    context.DeliveryOrderProducts.AddRange(deliveryOrderProductsStore2Wh);
                }
                System.Console.WriteLine($"isSufficient : {isSufficient}");
                context.SaveChanges();

                // Calculte delivery time.
                var wh2kitchenDuration = new System.TimeSpan(0, 5, 0);
                var kitchen2whDuration = new System.TimeSpan(0, 5, 0);
                var store2whDuration = new System.TimeSpan(0, 15, 0);
                var preparemealDuration = new System.TimeSpan(0, 15, 0);
                var resultDuration = wh2kitchenDuration + kitchen2whDuration + preparemealDuration;

                // Start creating tasks for employees as part of order processing, preparation and delivery. 
                // - If the amount of products/ingredients is sufficient, then invoke wh2kitchen.
                // - Otherwise, invoke store2wh.
                if (isSufficient)
                {
                    response = Wh2KitchenStart(new ApiOperation()
                    {
                        RequestObject = model
                    });
                }
                else
                {
                    resultDuration += store2whDuration;
                    response = RequestStore2WhStart(new ApiOperation()
                    {
                        RequestObject = deliveryOrderStore2Wh
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
        #endregion  // preprocessorder

        #region store2wh
        /// <summary>
        /// A method that allows you to begin the process of delivering products from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: update DB");

                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                
                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Update cache in the client-side app.
                string store2whRequest = new WarehouseClientController(_contextOptions).RequestStore2WhSave(new ApiOperation()
                {
                    RequestObject = model
                });

                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("RequestStore2Wh: request delivery of order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for requesting delivery of order #");
                sbMessageText.Append(model.Id.ToString());
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

                // Notify warehouse employee.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: notify employee");
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = adminUser.Id,
                        ReceiverId = 2,
                        TitleText = titleText,
                        BodyText = sbMessageText.ToString()
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
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that allows you to request the start of the process of delivering products from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).Store2WhStart(new ApiOperation
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
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: end");
            return response;
        }
        #endregion  // requeststore2wh
        
        #region store2wh
        /// <summary>
        /// A method that allows you to save the value of an incoming parameter 
        /// as part of the process of delivering products from the store to the warehouse. 
        /// </summary>
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhSave: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                
                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Store2Wh: confirm delivery of order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for confirming delivery of order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }

                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = adminUser.Id,
                        ReceiverId = 2,
                        TitleText = titleText,
                        BodyText = sbMessageText.ToString()
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
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: end");
            return response;
        }
        #endregion  // store2wh

        #region confirmstore2wh
        /// <summary>
        /// A method that is responsible for confirming the delivery of products from the store to the warehouse.
        /// </summary>
        public string ConfirmStore2WhAccept(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: cache");

                // Get delivery order related to the initial order.
                var deliveryOrder = context.DeliveryOrders
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.ParentDeliveryOrder)
                    .FirstOrDefault();
                if (deliveryOrder == null)
                    throw new System.Exception("Parent delivery order could not be null");
                
                // Start the step for delivering from warehouse to kitchen.
                response = Wh2KitchenStart(new ApiOperation()
                {
                    RequestObject = deliveryOrder
                });
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: end");
            return response;
        }
        #endregion  // confirmstore2wh
        
        #region wh2kitchen
        /// <summary>
        /// A method that allows you to begin the process of delivering products and ingredients from the warehouse to the kitchen.
        /// </summary>
        public string Wh2KitchenStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                
                // Create input parameter.
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == model.Id);
                if (initialOrder == null)
                    throw new System.Exception("Initial order could not be null");
                var initialOrderProducts = context.InitialOrderProducts.Where(x => x.InitialOrder.Id == initialOrder.Id).ToList();
                if (initialOrderProducts == null || !initialOrderProducts.Any())
                    throw new System.Exception("List of products that is related to the initial order could not be null or empty");
                var initialOrderIngredients = context.InitialOrderIngredients.Where(x => x.InitialOrder.Id == initialOrder.Id).ToList();
                if (initialOrderIngredients == null || !initialOrderIngredients.Any())
                    throw new System.Exception("List of ingredients that is related to the initial order could not be null or empty");
                var deliveryWh2Kitchen = new DeliveryWh2Kitchen
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    InitialOrders = new List<InitialOrder>() 
                    {
                        initialOrder
                    },
                    InitialOrderProducts = initialOrderProducts,
                    InitialOrderIngredients = initialOrderIngredients
                };
                context.DeliveriesWh2Kitchen.Add(deliveryWh2Kitchen);
                context.SaveChanges();

                // Update cache in the client-side app.
                string whRequest = new WarehouseClientController(_contextOptions).Wh2KitchenStart(new ApiOperation()
                {
                    RequestObject = deliveryWh2Kitchen
                });
                
                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Wh2Kitchen: deliver order #").Append(model.Id.ToString()).Append(" from the warehouse to the kitchen");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();
                
                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the warehouse to the kitchen.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                
                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = adminUser.Id,
                        ReceiverId = 2,
                        TitleText = titleText,
                        BodyText = sbMessageText.ToString()
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
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: end");
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Wh2KitchenExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: begin");
            try
            {
                // Initializing.
                DeliveryWh2Kitchen model = apiOperation.RequestObject as DeliveryWh2Kitchen;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: cache");

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
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: end");
            return response;
        }
        #endregion  // wh2kitchen

        #region kitchen2wh
        /// <summary>
        /// A method that allows you to begin the process of delivering finished products from the kitchen to the warehouse.
        /// </summary>
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

        /// <summary>
        /// A method that is responsible for controlling the delivery of finished products from the kitchen to the warehouse.
        /// </summary>
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
        #endregion  // kitchen2wh
    }
}