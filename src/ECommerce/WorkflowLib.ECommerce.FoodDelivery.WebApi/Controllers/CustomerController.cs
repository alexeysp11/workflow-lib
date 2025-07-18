using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Handlers;

namespace WorkflowLib.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// A class that represents a client-side app controller that processes requests from the customer.
    /// </summary>
    public class CustomerController
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }
        private CustomerHandler _customerHandler { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerController(
            DbContextOptions<FoodDeliveryDbContext> contextOptions,
            CustomerHandler customerHandler)
        {
            _contextOptions = contextOptions;
            _customerHandler = customerHandler;
        }

        /// <summary>
        /// The method that is responsible for placing an order.
        /// </summary>
        public string MakeOrderRequest(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("CustomerClient.MakeOrderRequest: begin");
            try
            {
                // Send HTTP request.
                string backendResponse = _customerHandler.MakeOrderRequest(initialOrder);
                
                // Insert into cache.
                Console.WriteLine("CustomerClient.MakeOrderRequest: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerClient.MakeOrderRequest: end");
            return response;
        }
        
        /// <summary>
        /// A method that stores the data necessary to carry out electronic payment on the part of the client.
        /// </summary>
        public string MakePaymentSave(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CustomerClient.MakePaymentSave: begin");
            try
            {
                // Update DB.
                Console.WriteLine("CustomerClient.MakePaymentSave: cache");

                // 
                response = "DB is updated";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerClient.MakePaymentSave: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for transmitting information from the client regarding the completed electronic payment.
        /// </summary>
        public string MakePaymentRespond(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CustomerClient.MakePaymentRespond: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new ArgumentNullException("apiOperation.RequestObject");

                // Validation.
                Console.WriteLine("CustomerClient.MakePaymentRespond: validation");
                
                // Insert into cache.
                // Attention: in this particular example, it is unnecessary to save data, that is in the model object, 
                // because it has already been inserted on the MakePaymentStep.
                // However in a real world app you might need to save data in the method.
                Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // Send HTTP request.
                string backendResponse = _customerHandler.MakePaymentRespond(deliveryOrder);
                
                // Insert into cache.
                Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CustomerClient.MakePaymentRespond: end");
            return response;
        }
    }
}