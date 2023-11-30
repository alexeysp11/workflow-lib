using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class WarehouseBackendRequestController
    {
        private CourierBackendController _courierBackend { get; set; }
        private NotificationsBackendRequestController _notificationsBackend { get; set; }

        #region Constructors
        public WarehouseBackendRequestController(
                NotificationsBackendRequestController notificationsBackend)
            : this(null, notificationsBackend)
        {
        }

        public WarehouseBackendRequestController(
                CourierBackendController courierBackend,
                NotificationsBackendRequestController notificationsBackend)
        {
            _courierBackend = courierBackend;
            _notificationsBackend = notificationsBackend;
        }
        #endregion  // Constructors

        public string PreprocessOrder(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.PreprocessOrder: begin");
            try
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
                if (isSufficient)
                {
                    // Invoke wh2kitchen.
                    response = Wh2Kitchen(model);
                }
                else
                {
                    // Overall deilivery time (taking into account that delivery from store to warehouse is necessary).
                    result += store2whDuration;

                    // Invoke store2wh.
                    response = Store2Wh(model);
                }
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseBackend.PreprocessOrder: end");
            return response;
        }

        public string Store2Wh(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2Wh: begin");
            try
            {
                // Update DB.

                // Notify warehouse employee.
                _notificationsBackend.SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from store to warehouse"
                    }
                });

                // Update cache in the client-side app.
                string paymentRequest = new WarehouseClientRequestController(this).Store2Wh(model);

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseBackend.Store2Wh: end");
            return response;
        }

        public string Wh2Kitchen(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2Kitchen: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2Kitchen: cache");
                
                // Notify warehouse employee.
                _notificationsBackend.SendNotifications(new List<Notification>
                {
                    new Notification
                    {
                        SenderId = 1,
                        ReceiverId = 2,
                        TitleText = "Create request for delivering from warehouse to kitchen",
                    }
                });

                // Update cache in the client-side app.
                string paymentRequest = new WarehouseClientRequestController(this).Wh2Kitchen(model);

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("WarehouseBackend.Wh2Kitchen: end");
            return response;
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