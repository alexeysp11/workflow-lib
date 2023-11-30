using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseClientRequestController
    {
        private WarehouseBackendRequestController _backendController { get; set; }

        public WarehouseClientRequestController(WarehouseBackendRequestController backendController)
        {
            _backendController = backendController;
        }

        public string Store2Wh(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2Wh: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2Wh: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseClient.Store2Wh: end");
            return response;
        }

        public string Wh2Kitchen(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2Kitchen: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2Kitchen: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseClient.Wh2Kitchen: end");
            return response;
        }
    }
}