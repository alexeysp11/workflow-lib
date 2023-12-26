using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        public WarehouseBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

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
                    ExecutorName = whEmployee.FullName,
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
                    DeliveryWh2Kitchen wh2kitchenModel = new DeliveryWh2Kitchen();
                    response = Wh2KitchenStart(new ApiOperation()
                    {
                        RequestObject = model
                    });
                }
                else
                {
                    resultDuration += store2whDuration;
                    response = Store2WhStart(new ApiOperation()
                    {
                        RequestObject = model
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

        public string Store2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.

                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from store to warehouse",
                        BodyText = ""
                    }
                });

                // Update cache in the client-side app.
                var deliveryOrder = new DeliveryOrder
                {
                    //
                };
                string paymentRequest = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("WarehouseBackend.Store2WhStart: end");
            return response;
        }

        public string Store2WhRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhRequest: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhRequest: cache");

                // Send HTTP request.
                string backendResponse = new CourierBackendController(_contextOptions).Store2WhSave(new ApiOperation
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
            System.Console.WriteLine("WarehouseBackend.Store2WhRequest: end");
            return response;
        }
        
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhSave: cache");

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

                // Send HTTP request.
                string backendResponse = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation
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
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: end");
            return response;
        }

        public string Store2WhConfirm(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Store2WhConfirm: end");
            return response;
        }
        
        public string Wh2KitchenStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");
                
                // Notify warehouse employee.
                new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from warehouse to kitchen",
                        BodyText = ""
                    }
                });

                // Update cache in the client-side app.
                var deliveryWh2Kitchen = new DeliveryWh2Kitchen
                {
                    // 
                };
                string whRequest = new WarehouseClientController(_contextOptions).Wh2KitchenSave(new ApiOperation()
                {
                    RequestObject = deliveryWh2Kitchen
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

        public string Wh2KitchenRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: begin");
            try
            {
                // Initializing.
                DeliveryWh2Kitchen model = apiOperation.RequestObject as DeliveryWh2Kitchen;
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: cache");

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
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenRespond: end");
            return response;
        }

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
    }
}