using Cims.WorkflowLib.Example01.Controllers;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.BL
{
    public class CustomerBackendBL
    {
        private FileServiceController _fileServiceController { get; set; }

        public CustomerBackendBL(
            FileServiceController fileServiceController)
        {
            _fileServiceController = fileServiceController;
        }

        public string AskForPayment(InitialOrder model)
        {
            string result = "";

            // Get payment method.
            if (model.PaymentType == "card")
            {
                // Create a form for card details.
            }
            else if (model.PaymentType == "qr")
            {
                // Generate QR code.
                // string qrResult = _fileServiceController.GenerateQrCode(model);

                // Envelope QR code.
            }
            else
            {
                // Update DB.
                // Send request to the notifications backend.

                // 
                return "error";
            }

            // Send request to the customer client.

            // Send request to the notifications backend.
            
            // Update DB.

            return result;
        }
    }
}