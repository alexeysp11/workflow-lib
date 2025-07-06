using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Handlers;

namespace WorkflowLib.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the courier.
    /// </summary>
    public class CourierController
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierController(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that allows to save a request for the delivery of products from a store to a warehouse.
        /// </summary>
        public string Store2WhStart(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierClient.Store2WhStart: begin");
            try
            {
                // Update DB.
                Console.WriteLine("CourierClient.Store2WhStart: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierClient.Store2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierClient.Store2WhExecute: begin");
            try
            {
                // Update DB.
                Console.WriteLine("CourierClient.Store2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierHandler(_contextOptions).Store2WhExecute(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierClient.Store2WhExecute: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for starting the order delivery process.
        /// </summary>
        public string DeliverOrderStart(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("CourierClient.DeliverOrderStart: begin");
            try
            {
                // Update DB.
                Console.WriteLine("CourierClient.DeliverOrderStart: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierClient.DeliverOrderStart: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("CourierClient.DeliverOrderExecute: begin");
            try
            {
                // Update DB.
                Console.WriteLine("CourierClient.DeliverOrderExecute: cache");

                // Send HTTP request.
                string backendResponse = new CourierHandler(_contextOptions).DeliverOrderExecute(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("CourierClient.DeliverOrderExecute: end");
            return response;
        }
    }
}