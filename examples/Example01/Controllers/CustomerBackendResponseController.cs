using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerBackendResponseController : ICustomerBackend
    {
        private WarehouseBackendRequestController _warehouseBackend { get; set; }
        private NotificationsBackendRequestController _notificationsBackend { get; set; }

        public CustomerBackendResponseController(
                WarehouseBackendRequestController warehouseBackend)
            : this(warehouseBackend, new NotificationsBackendRequestController())
        {
        }
        
        public CustomerBackendResponseController(
                WarehouseBackendRequestController warehouseBackend,
                NotificationsBackendRequestController notificationsBackend)
        {
            _warehouseBackend = warehouseBackend;
            _notificationsBackend = notificationsBackend;
        }

        public string MakeOrder(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrder: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrder: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrder: cache");

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakeOrder: end");
            return response;
        }

        public string MakePayment(object input)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                Payment model = input as Payment;

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Calculate delivery time.
                string preprocessResponse = PreprocessOrder(new PlaceOrderModel());

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }

        public string PreprocessOrder(PlaceOrderModel model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.PreprocessOrder: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("CustomerBackend.PreprocessOrder: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.PreprocessOrder: cache");

                // Calculate delivery time.
                var preprocessResponse = _warehouseBackend.PreprocessOrder(model);

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("CustomerBackend.PreprocessOrder: end");
            return response;
        }
    }
}