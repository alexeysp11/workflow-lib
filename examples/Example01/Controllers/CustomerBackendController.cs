using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private CustomerClientController _customerClientController { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomerBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
            _customerClientController = new CustomerClientController(contextOptions, this);
        }

        public string MakeOrderRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                using var context = new DeliveringContext(_contextOptions);

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: cache");

                // Invoke makepayment.
                response = MakePaymentStart(new ApiOperation()
                {
                    RequestObject = model
                });
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: end");
            return response;
        }

        public string MakePaymentStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Get payment method.
                if (model.PaymentType == "card")
                {
                    // Create a form for card details.
                    System.Console.WriteLine("CustomerBackend.MakePayment: form for card details");
                }
                else if (model.PaymentType == "qr")
                {
                    // Generate QR code.
                    string qrResult = new FileServiceController().GenerateQrCode(new ApiOperation()
                    {
                        RequestObject = model
                    });

                    // Envelope QR code.
                    System.Console.WriteLine("CustomerBackend.MakePayment: envelope qr");
                }
                else
                {
                    throw new System.Exception("Incorrect parameter: PaymentType");
                }

                // Save data into DB.
                var organization = context.Organizations.Include(x => x.Company).FirstOrDefault();
                if (organization == null || organization.Company == null)
                    throw new System.Exception("Organization or company is not defined");
                var customer = context.Customers.FirstOrDefault(x => x.UserAccount != null && x.UserAccount.Uid == model.UserUid);
                if (customer == null)
                    throw new System.Exception("Specified customer does not exist in the database");
                DeliveryOrder deliveryOrder = new DeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Payments = new List<Payment>
                    {
                        new Payment
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            PaymentType = model.PaymentType,
                            PaymentMethod = model.PaymentMethod,
                            Amount = model.PaymentAmount,
                            Payer = customer.FullName,
                            Receiver = string.IsNullOrEmpty(organization.Company.Name) ? "Our company" : organization.Company.Name,
                            Status = "Requested"
                        }
                    },
                    CustomerUid = customer.Uid
                };
                model.DeliveryOrder = deliveryOrder;
                context.DeliveryOrders.Add(deliveryOrder);
                context.Payments.AddRange(deliveryOrder.Payments);
                var initialOrderProducts = context.InitialOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.InitialOrder != null && x.InitialOrder.Id == model.Id)
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
                deliveryOrder.ProductsPrice = model.PaymentAmount;
                deliveryOrder.TotalPrice = model.PaymentAmount;
                context.SaveChanges();

                // Send request to the customer client.
                string paymentRequest = _customerClientController.MakePaymentSave(new ApiOperation
                {
                    RequestObject = deliveryOrder
                });

                // Send request to the notifications backend.
                var notifications = new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Please, enter your card details to complete the payment for the delivery order",
                        BodyText = "Hello, we've just received the request for getting delivery order. Please, provide us with your card details to complete the payment."
                    }
                };
                string notificationsRequest = new NotificationsBackendController(_contextOptions).SendNotifications(notifications);

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        public string PreprocessOrderStart(ApiOperation apiOperation)
        {
            // Get recipes.

            // Send HTTP request to warehouse backend.
            // var dt = new WarehouseBackendController(_contextOptions).PreprocessOrder(model);

            // // Calculate delivery time.
            // var deliveryDuration = new System.TimeSpan(0, 30, 0);
            // deliveryDuration += dt;

            // 
            return "";
        }

        public string MakeOrderSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrder: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrder: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrder: cache");

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakeOrder: end");
            return response;
        }

        public string MakePaymentRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Calculate delivery time.
                string preprocessResponse = PreprocessOrderRedirect(new ApiOperation()
                {
                    RequestObject = model
                });

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        public string PreprocessOrderRedirect(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Validation.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: cache");

                // Calculate delivery time.
                var preprocessResponse = new WarehouseBackendController(_contextOptions).PreprocessOrderRedirect(new ApiOperation()
                {
                    RequestObject = model
                });

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: end");
            return response;
        }
    }
}