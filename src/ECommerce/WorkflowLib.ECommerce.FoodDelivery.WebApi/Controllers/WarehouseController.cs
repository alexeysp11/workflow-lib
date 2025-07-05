using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Network;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.ECommerce.FoodDelivery.Core.Handlers;

namespace WorkflowLib.ECommerce.FoodDelivery.WebApi.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the kitchen employees.
    /// </summary>
    public class WarehouseController
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public WarehouseController(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region requeststore2wh
        /// <summary>
        /// Storing request for filling a form for deliving from the store to warehouse.
        /// </summary>
        public string RequestStore2WhSave(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.RequestStore2WhSave: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.RequestStore2WhSave: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.RequestStore2WhSave: end");
            return response;
        }

        /// <summary>
        /// Requesting delivering from store to warehouse.
        /// </summary>
        public string RequestStore2WhRespond(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.RequestStore2WhRespond: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.RequestStore2WhRespond: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseHandler(_contextOptions).RequestStore2WhRespond(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.RequestStore2WhRespond: end");
            return response;
        }
        #endregion  // requeststore2wh

        #region store2wh
        /// <summary>
        /// Storing request for filling a form for deliving from the store to warehouse.
        /// </summary>
        public string Store2WhSave(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2WhSave: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2WhSave: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Store2WhSave: end");
            return response;
        }
        #endregion  // store2wh

        #region confirmstore2wh
        /// <summary>
        /// A method that is responsible for confirming the delivery of products from the store to the warehouse.
        /// </summary>
        public string ConfirmStore2WhAccept(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.ConfirmStore2WhAccept: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.ConfirmStore2WhAccept: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseHandler(_contextOptions).ConfirmStore2WhAccept(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.ConfirmStore2WhAccept: end");
            return response;
        }
        #endregion  // confirmstore2wh
        
        #region wh2kitchen
        /// <summary>
        /// Storing the request for warhouse employee to deliver from warehouse to kitchen. 
        /// </summary>
        public string Wh2KitchenStart(DeliveryOperation deliveryOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2KitchenStart: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2KitchenStart: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Wh2KitchenStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for carrying out the delivery of products from the warehouse to the kitchen.
        /// </summary>
        public string Wh2KitchenExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2KitchenExecute: begin");
            try
            {
                // Initializing.
                if (deliveryOrder == null)
                    throw new System.ArgumentNullException("apiOperation.RequestObject");

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2KitchenExecute: cache");

                // Send HTTP request.
                // think about what type of input parameter the kitchen controller will accept to prepare an order.
                string backendResponse = new WarehouseHandler(_contextOptions).Wh2KitchenExecute(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Wh2KitchenExecute: end");
            return response;
        }
        #endregion  // wh2kitchen

        #region kitchen2wh
        /// <summary>
        /// A method that allows you to begin the process of delivering finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhStart(InitialOrder initialOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Kitchen2WhStart: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Kitchen2WhStart: cache");

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Kitchen2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that is responsible for controlling the delivery of finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhExecute(DeliveryOrder deliveryOrder)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: begin");
            try
            {
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseHandler(_contextOptions).Kitchen2WhExecute(deliveryOrder);

                // 
                response = "success";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: end");
            return response;
        }
        #endregion  // kitchen2wh
    }
}