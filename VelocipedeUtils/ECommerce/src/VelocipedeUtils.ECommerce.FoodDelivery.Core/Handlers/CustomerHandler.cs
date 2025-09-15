using System.Text;
using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Extensions;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// A class that represents a backend service controller that processes requests from the customer.
    /// </summary>
    public class CustomerHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
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
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                InitialOrderDao.CreateInitialOrder(context, initialOrder);
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
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
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

                // Get customer by user UID.
                Customer? customer = UserDao.GetCustomerByUserUid(context, userUid: initialOrder.UserUid);
                if (customer == null)
                    throw new Exception("Specified customer does not exist in the database");

                // Create delivery order.
                DeliveryOrder deliveryOrder = DeliveryOrderDao.CreateDeliveryOrderInitial(
                    context,
                    initialOrder.Id,
                    customer.Uid,
                    customer.FullName);

                NotifyCustomerOrderStartProcessing(context, customer.UserAccount.Id, deliveryOrder.Id);

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

        /// <summary>
        /// Notify customer that initial order is ready for processing.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="customerUserAccountId"></param>
        /// <param name="deliveryOrderId"></param>
        /// <exception cref="Exception"></exception>
        private void NotifyCustomerOrderStartProcessing(
            FoodDeliveryDbContext context,
            long customerUserAccountId,
            long deliveryOrderId)
        {
            var sbMessageText = new StringBuilder();

            // Title text.
            sbMessageText.Append("Please, provide your card details to pay for the order #").Append(deliveryOrderId.ToString());
            string titleText = sbMessageText.ToString();
            sbMessageText.Clear();

            // Body text.
            sbMessageText.Append("Hello,\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("We have just received a request from you to process the order #").Append(deliveryOrderId.ToString()).Append(".\n");
            sbMessageText.Append("Please provide us with your card details so that we can complete the payment process for your order.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("Your order will be prepared and delivered after payment.\n");
            sbMessageText.Append("\n");
            sbMessageText.Append("Thank you for using our services!");

            // Send request to the notifications backend.
            UserAccount? adminUser = context.UserAccounts.FirstOrDefault();
            if (adminUser == null)
                throw new Exception("Admin user could not be null");
            var notifications = new List<Notification>
            {
                new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = customerUserAccountId,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                }
            };
            string notificationsRequest = new NotificationsHandler(_contextOptions).SendNotifications(notifications);
        }
    }
}