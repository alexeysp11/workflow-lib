using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseClientReceiverController
    {
        private WarehouseBackendReceiverController _backendController { get; set; }

        public WarehouseClientReceiverController(WarehouseBackendReceiverController backendController)
        {
            _backendController = backendController;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Wh2Kitchen(PlaceOrderModel model)
        {
            // 
            return "";
        }
    }
}