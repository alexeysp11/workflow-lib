using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the kitchen employees.
    /// </summary>
    public class KitchenClientController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public KitchenClientController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// A method that is responsible for storing information necessary for the preparation of an order by kitchen staff.
        /// </summary>
        public string PrepareMealStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenClient.PrepareMealStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;

                // This method will take CookingOperation as a parameter.
                // Recipes can be loaded from InitialOrderIngredients -> Ingredient -> Recipe.

                // Validation.
                System.Console.WriteLine("KitchenClient.PrepareMealStart: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenClient.PrepareMealStart: end");
            return response;
        }

        /// <summary>
        /// The method that the kitchen staff is responsible for preparing the order.
        /// </summary>
        public string PrepareMealExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("KitchenClient.PrepareMealExecute: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;
                
                // Validation.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // Send HTTP request.
                string backendResponse = new KitchenBackendController(_contextOptions).PrepareMealExecute(new ApiOperation
                {
                    RequestObject = model
                });
                
                // Insert into cache.
                System.Console.WriteLine("KitchenClient.PrepareMealExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenClient.PrepareMealExecute: end");
            return response;
        }
    }
}