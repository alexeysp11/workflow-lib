using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;

namespace WorkflowLib.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// A class that represents a client-side app controller that processes requests from the customer.
    /// </summary>
    public class CustomerClientController
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        private CustomerBackendController _customerBackendController { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerClientController(
            DbContextOptions<FoodDeliveryDbContext> contextOptions,
            CustomerBackendController customerBackendController)
        {
            _contextOptions = contextOptions;
            _customerBackendController = customerBackendController;
        }

        /// <summary>
        /// The method that is responsible for placing an order.
        /// </summary>
        public string MakeOrderRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;

                // Send HTTP request.
                string backendResponse = _customerBackendController.MakeOrderRequest(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: end");
            return response;
        }
        
        /// <summary>
        /// A method that stores the data necessary to carry out electronic payment on the part of the client.
        /// </summary>
        public string MakePaymentSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentSave: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("CustomerClient.MakePaymentSave: cache");

                // 
                response = "DB is updated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakePaymentSave: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for transmitting information from the client regarding the completed electronic payment.
        /// </summary>
        public string MakePaymentRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                if (model == null)
                    throw new System.ArgumentNullException("apiOperation.RequestObject");

                // Validation.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: validation");
                
                // Insert into cache.
                // Attention: in this particular example, it is unnecessary to save data, that is in the model object, 
                // because it has already been inserted on the MakePaymentStep.
                // However in a real world app you might need to save data in the method.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // Send HTTP request.
                string backendResponse = _customerBackendController.MakePaymentRespond(new ApiOperation()
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: end");
            return response;
        }
    }
}