using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.Cooking;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// A class that represents a backend service controller that processes requests from the customer.
    /// </summary>
    public class CustomerHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        //private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
            //_customerClientController = new CustomerClientController(contextOptions, this);
        }

        /// <summary>
        /// The method that is responsible for placing an order.
        /// </summary>
        public string MakeOrderRequest(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("CustomerBackend.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Validation.
                Console.WriteLine("CustomerClient.MakeOrderRequest: validation");

                // Insert into cache.
                Console.WriteLine("CustomerClient.MakeOrderRequest: cache");
                var initialOrderProducts = new List<InitialOrderProduct>();
                var initialOrderIngredients = new List<InitialOrderIngredient>();
                foreach (var pid in initialOrder.ProductIds)
                {
                    if (initialOrderProducts.Any(x => x.Product.Id == pid))
                        continue;
                    
                    int productQty = initialOrder.ProductIds.Where(x => x == pid).Count();
                    var product = context.Products.Where(x => x.Id == pid).FirstOrDefault();
                    var initialOrderProduct = new InitialOrderProduct
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Name = product.Name,
                        Product = product,
                        InitialOrder = initialOrder,
                        Quantity = productQty
                    };
                    initialOrderProducts.Add(initialOrderProduct);

                    List<Ingredient> ingredientsTmp = context.Ingredients
                        .Include(x => x.IngredientProduct)
                        .Where(x => x.FinalProduct.Id == product.Id)
                        .ToList();
                    foreach (var ingredient in ingredientsTmp)
                    {
                        initialOrderIngredients.Add(new InitialOrderIngredient
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            Name = ingredient.Name,
                            Ingredient = ingredient,
                            InitialOrder = initialOrder,
                            InitialOrderProduct = initialOrderProduct,
                            Quantity = productQty * (int)ingredient.Quantity
                        });
                    }
                    
                    initialOrder.PaymentAmount += productQty * product.Price;
                }
                initialOrder.Uid = System.Guid.NewGuid().ToString();
                context.InitialOrderProducts.AddRange(initialOrderProducts);
                context.InitialOrderIngredients.AddRange(initialOrderIngredients);
                context.InitialOrders.Add(initialOrder);
                context.SaveChanges();

                // Validation.
                Console.WriteLine("CustomerBackend.MakeOrderRequest: validation");

                // Update DB.
                Console.WriteLine("CustomerBackend.MakeOrderRequest: cache");

                // Invoke makepayment.
                response = MakePaymentStart(initialOrder);
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerBackend.MakeOrderRequest: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for starting the electronic payment procedure for an order.
        /// </summary>
        public string MakePaymentStart(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Initializing.
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Validation.
                Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Get payment method.
                if (initialOrder.PaymentType == EnumExtensions.GetDisplayName(PaymentType.Card))
                {
                    // Create a form for card details.
                    Console.WriteLine("CustomerBackend.MakePayment: form for card details");
                }
                else if (initialOrder.PaymentType == EnumExtensions.GetDisplayName(PaymentType.QrCode))
                {
                    // Generate QR code.
                    //string qrResult = new FileServiceController().GenerateQrCode(new ApiOperation()
                    //{
                    //    RequestObject = model
                    //});

                    // Envelope QR code.
                    Console.WriteLine("CustomerBackend.MakePayment: envelope qr");
                }
                else
                {
                    throw new Exception("Incorrect parameter: PaymentType");
                }

                // Save data into DB.
                var destination = initialOrder.Address;
                var organization = context.Organizations
                    .Include(x => x.Company)
                    .FirstOrDefault();
                if (organization == null || organization.Company == null)
                    throw new Exception("Organization or company is not defined");
                if (string.IsNullOrEmpty(organization.Company.Address))
                    throw new Exception("Address of the company is not specified");
                var customer = context.Customers
                    .Include(x => x.UserAccount)
                    .FirstOrDefault(x => x.UserAccount != null && x.UserAccount.Uid == initialOrder.UserUid);
                if (customer == null)
                    throw new Exception("Specified customer does not exist in the database");
                InitialOrder? existedInitialOrder = context.InitialOrders.FirstOrDefault(x => x.Id == initialOrder.Id);
                if (existedInitialOrder == null)
                    throw new Exception("Specified initial order does not exist in the database");
                var deliveryOrder = new DeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Payments = new List<Payment>
                    {
                        new Payment
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            PaymentType = existedInitialOrder.PaymentType,
                            PaymentMethod = existedInitialOrder.PaymentMethod,
                            Amount = existedInitialOrder.PaymentAmount,
                            Payer = customer.FullName,
                            Receiver = string.IsNullOrEmpty(organization.Company.Name) ? "Our company" : organization.Company.Name,
                            Status = EnumExtensions.GetDisplayName(PaymentStatus.Requested)
                        }
                    },
                    CustomerUid = customer.Uid,
                    CustomerName = customer.FullName,
                    OrderCustomerType = OrderCustomerType.Customer,
                    ExecutorUid = organization.Company.Uid,
                    ExecutorName = organization.Company.Name,
                    OrderExecutorType = OrderExecutorType.Company,
                    Origin = organization.Company.Address,
                    Destination = destination,
                    DateStartActual = System.DateTime.Now
                };
                context.DeliveryOrders.Add(deliveryOrder);
                context.Payments.AddRange(deliveryOrder.Payments);
                var initialOrderProducts = context.InitialOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.InitialOrder != null && x.InitialOrder.Id == initialOrder.Id)
                    .ToList();
                foreach (var iop in initialOrderProducts)
                {
                    var deliveryOrderProduct = new DeliveryOrderProduct
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Product = iop.Product,
                        DeliveryOrder = deliveryOrder,
                        Quantity = iop.Quantity
                    };
                    context.DeliveryOrderProducts.Add(deliveryOrderProduct);
                }
                deliveryOrder.ProductsPrice = initialOrder.PaymentAmount;
                deliveryOrder.TotalPrice = initialOrder.PaymentAmount;
                context.SaveChanges();

                // Save the reference to DeliveryOrder.
                existedInitialOrder.DeliveryOrderId = deliveryOrder.Id;
                context.SaveChanges();

                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Please, provide your card details to pay for the order #").Append(deliveryOrder.Id.ToString());
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Hello,\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("We have just received a request from you to process the order #").Append(deliveryOrder.Id.ToString()).Append(".\n");
                sbMessageText.Append("Please provide us with your card details so that we can complete the payment process for your order.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Your order will be prepared and delivered after payment.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Thank you for using our services!");

                // Send request to the notifications backend.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new Exception("Admin user could not be null");
                var notifications = new List<Notification>
                {
                    new Notification
                    {
                        SenderId = adminUser.Id,
                        ReceiverId = customer.UserAccount.Id,
                        TitleText = titleText,
                        BodyText = sbMessageText.ToString()
                    }
                };
                string notificationsRequest = new NotificationsHandler(_contextOptions).SendNotifications(notifications);

                // Update DB.
                Console.WriteLine("CustomerBackend.MakePayment: cache");
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for transmitting information from the client regarding the completed electronic payment.
        /// </summary>
        public string MakePaymentRespond(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Validation.
                Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Calculate delivery time.
                string preprocessResponse = PreprocessOrderRedirect(deliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public string PreprocessOrderRedirect(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Validation.
                Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: validation");

                // Update DB.
                Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: cache");

                // Calculate delivery time.
                var preprocessResponse = new WarehouseHandler(_contextOptions).PreprocessOrderRedirect(deliveryOrder);

                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: end");
            return response;
        }
    }
}