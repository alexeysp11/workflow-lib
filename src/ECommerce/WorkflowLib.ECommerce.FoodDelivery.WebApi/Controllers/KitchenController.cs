using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Handlers;

namespace WorkflowLib.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the kitchen employees.
    /// </summary>
    public class KitchenController
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public KitchenController(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that is responsible for storing information necessary for the preparation of an order by kitchen staff.
        /// </summary>
        public string PrepareMealStart(InitialOrder initialOrder)
        {
            string response = "";
            Console.WriteLine("KitchenClient.PrepareMealStart: begin");
            try
            {
                // This method will take CookingOperation as a parameter.
                // Recipes can be loaded from InitialOrderIngredients -> Ingredient -> Recipe.

                // Validation.
                Console.WriteLine("KitchenClient.PrepareMealStart: validation");
                
                // Insert into cache.
                Console.WriteLine("KitchenClient.PrepareMealStart: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("KitchenClient.PrepareMealStart: end");
            return response;
        }

        /// <summary>
        /// The method that the kitchen staff is responsible for preparing the order.
        /// </summary>
        public string PrepareMealExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            Console.WriteLine("KitchenClient.PrepareMealExecute: begin");
            try
            {
                // Validation.
                Console.WriteLine("KitchenClient.PrepareMealExecute: validation");
                
                // Insert into cache.
                Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // Send HTTP request.
                string backendResponse = new KitchenHandler(_contextOptions).PrepareMealExecute(deliveryOrder);
                
                // Insert into cache.
                Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("KitchenClient.PrepareMealExecute: end");
            return response;
        }
    }
}