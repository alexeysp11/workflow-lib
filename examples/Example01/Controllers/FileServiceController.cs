using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class FileServiceController
    {
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