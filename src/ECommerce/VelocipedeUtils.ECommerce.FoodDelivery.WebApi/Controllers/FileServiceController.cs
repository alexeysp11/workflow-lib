using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;

namespace VelocipedeUtils.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// A backend service that is responsible for generating and processing files.
    /// </summary>
    public class FileServiceController
    {
        /// <summary>
        /// A method that generates a QR code for payment based on a customer order. 
        /// </summary>
        public string GenerateQrCode(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("FileServiceController.GenerateQrCode: begin");
            try
            {
                // Update DB.
                Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // Generating QR code.
                Console.WriteLine("FileServiceController.GenerateQrCode: generating qr code");
                
                // Update DB.
                Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // 
                response = "qr code generated";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("FileServiceController.GenerateQrCode: end");
            return response;
        }
    }
}