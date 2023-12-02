using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class KitchenClientController
    {
        public string PrepareMealSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenClient.PrepareMealSave: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Validation.
                System.Console.WriteLine("KitchenClient.PrepareMealSave: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("KitchenClient.PrepareMealSave: end");
            return response;
        }
    }
}