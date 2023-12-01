using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseClientSenderController
    {
        private WarehouseBackendSenderController _backendController { get; set; }

        public WarehouseClientSenderController(WarehouseBackendSenderController backendController)
        {
            _backendController = backendController;
        }

        /// <summary>
        /// Storing request for filling a form for deliving from the store to warehouse.
        /// </summary>
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

        /// <summary>
        /// Storing the request for warhouse employee to deliver from warehouse to kitchen. 
        /// </summary>
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