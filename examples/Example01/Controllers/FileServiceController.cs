using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// A backend service that is responsible for generating and processing files.
    /// </summary>
    public class FileServiceController
    {
        /// <summary>
        /// A method that generates a QR code for payment based on a customer order. 
        /// </summary>
        public string GenerateQrCode(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("FileServiceController.GenerateQrCode: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                
                // Update DB.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // Generating QR code.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: generating qr code");
                
                // Update DB.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // 
                response = "qr code generated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("FileServiceController.GenerateQrCode: end");
            return response;
        }
    }
}