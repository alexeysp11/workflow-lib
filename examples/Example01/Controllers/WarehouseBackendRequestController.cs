using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseBackendRequestController
    {
        private CourierBackendController _courierBackend { get; set; }

        public WarehouseBackendRequestController(CourierBackendController courierBackend)
        {
            _courierBackend = courierBackend;
        }

        public System.TimeSpan PreprocessOrder(PlaceOrderModel model)
        {
            // Get ingredients amount from DB.
            int ingredientsAmount = 0;

            // 
            bool isSufficient = ingredientsAmount >= model.ProductIds.Count;

            // Calculte delivery time.
            var wh2kitchenDuration = new System.TimeSpan(0, 5, 0);
            var kitchen2whDuration = new System.TimeSpan(0, 5, 0);
            var store2whDuration = new System.TimeSpan(0, 15, 0);
            var preparemealDuration = new System.TimeSpan(0, 15, 0);

            // Overall deilivery time (best-case scenario).
            System.TimeSpan result = wh2kitchenDuration + kitchen2whDuration + preparemealDuration;

            // 
            if (!isSufficient)
            {
                // Overall deilivery time (taking into account that delivery from store to warehouse is necessary).
                result += store2whDuration;

                // Invoke store2wh.
                _courierBackend.Store2Wh(model);
            }
            // Invoke wh2kitchen.
            Wh2Kitchen(model);

            // 
            return result;
        }

        public string Wh2Kitchen(PlaceOrderModel model)
        {
            // Preprocess.
            // Notify warehouse employee.
            // Redirect to warehouse client-side app.

            // 
            return "";
        }

        public string Wh2KitchenNotifyManager(PlaceOrderModel model)
        {
            // 
            return "";
        }

        public string Kitchen2Wh(PlaceOrderModel model)
        {
            // 
            return "";
        }
    }
}