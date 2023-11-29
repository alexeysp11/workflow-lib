using Cims.WorkflowLib.Example01.BL;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Monetary;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerBackendRequestController
    {
        private FileServiceController _fileServiceController { get; set; }
        // private WarehouseBackendRequestController _warehouseBackend { get; set; }
        private NotificationsBackendRequestController _notificationsBackend { get; set; }

        public CustomerBackendRequestController(
            FileServiceController fileServiceController,
            // WarehouseBackendRequestController warehouseBackend,
            NotificationsBackendRequestController notificationsBackend)
        {
            _fileServiceController = fileServiceController;
            // _warehouseBackend = warehouseBackend;
            _notificationsBackend = notificationsBackend;
        }

        public string MakeOrder(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrder: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrder: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrder: cache");

                // Invoke makepayment.
                return MakePayment(model);
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakeOrder: end");
            return response;
        }

        public string MakePayment(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
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
                    string qrResult = _fileServiceController.GenerateQrCode(model);

                    // Envelope QR code.
                    System.Console.WriteLine("CustomerBackend.MakePayment: envelope qr");
                }
                else
                {
                    // Update DB.
                    System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                    // Send request to the notifications backend.
                    string errorNotificationsRequest = _notificationsBackend.SendNotifications(new List<Notification>
                    {
                        new Notification
                        {
                            SenderId = 1,
                            ReceiverId = 2,
                            TitleText = "Error while creating request for payment",
                            BodyText = "Hello, we've just received the request for getting delivery order. Please, be informed that the error while creating request for payment has occured."
                        }
                    });

                    // 
                    return "error";
                }

                // Send request to the customer client.
                string paymentRequest = new CustomerClientRequestController(this).MakePayment(new Payment()
                {
                    PaymentType = model.PaymentType,
                    PaymentMethod = model.PaymentMethod,
                    Payer = "Customer",
                    Receiver = "Our company",
                    Status = "Requested"
                });

                // Send request to the notifications backend.
                string notificationsRequest = _notificationsBackend.SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Please, enter your card details to complete the payment for the delivery order",
                        BodyText = "Hello, we've just received the request for getting delivery order. Please, provide us with your card details to complete the payment."
                    }
                });

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        public string PreprocessOrder(PlaceOrderModel model)
        {
            // Get recipes.

            // Send HTTP request to warehouse backend.
            // var dt = _warehouseBackend.PreprocessOrder(model);

            // // Calculate delivery time.
            // var deliveryDuration = new System.TimeSpan(0, 30, 0);
            // deliveryDuration += dt;

            // 
            return "";
        }
    }
}