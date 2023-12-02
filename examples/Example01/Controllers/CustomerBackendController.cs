using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerBackendController
    {
        
        public string MakeOrderRequest(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: cache");

                // Invoke makepayment.
                response = MakePaymentStart(model);
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: end");
            return response;
        }

        public string MakePaymentStart(object input)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                PlaceOrderModel model = input as PlaceOrderModel;
                
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
                    string qrResult = new FileServiceController().GenerateQrCode(model);

                    // Envelope QR code.
                    System.Console.WriteLine("CustomerBackend.MakePayment: envelope qr");
                }
                else
                {
                    // Update DB.
                    System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                    // Send request to the notifications backend.
                    string errorNotificationsRequest = new NotificationsBackendController().SendNotifications(new List<Notification>
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
                string paymentRequest = new CustomerClientController().MakePaymentSave(new Payment()
                {
                    PaymentType = model.PaymentType,
                    PaymentMethod = model.PaymentMethod,
                    Payer = "Customer",
                    Receiver = "Our company",
                    Status = "Requested"
                });

                // Send request to the notifications backend.
                string notificationsRequest = new NotificationsBackendController().SendNotifications(new List<Notification>
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

        public string PreprocessOrderStart(PlaceOrderModel model)
        {
            // Get recipes.

            // Send HTTP request to warehouse backend.
            // var dt = new WarehouseBackendController().PreprocessOrder(model);

            // // Calculate delivery time.
            // var deliveryDuration = new System.TimeSpan(0, 30, 0);
            // deliveryDuration += dt;

            // 
            return "";
        }

        public string MakeOrderSave(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrder: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrder: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrder: cache");

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakeOrder: end");
            return response;
        }

        public string MakePaymentRespond(object input)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                Payment model = input as Payment;

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Calculate delivery time.
                string preprocessResponse = PreprocessOrderRedirect(new PlaceOrderModel());

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        public string PreprocessOrderRedirect(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: cache");

                // Calculate delivery time.
                var preprocessResponse = new WarehouseBackendController().PreprocessOrderRedirect(model);

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: end");
            return response;
        }
    }
}