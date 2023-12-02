using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseClientController
    {
        /// <summary>
        /// Storing request for filling a form for deliving from the store to warehouse.
        /// </summary>
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2WhSave: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2WhSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseClient.Store2WhSave: end");
            return response;
        }

        /// <summary>
        /// Storing the request for warhouse employee to deliver from warehouse to kitchen. 
        /// </summary>
        public string Wh2KitchenSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: begin");
            try
            {
                PlaceOrderModel model = apiOperation.RequestObject as PlaceOrderModel;
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: end");
            return response;
        }
    }
}