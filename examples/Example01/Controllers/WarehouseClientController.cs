using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the kitchen employees.
    /// </summary>
    public class WarehouseClientController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public WarehouseClientController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// Storing request for filling a form for deliving from the store to warehouse.
        /// </summary>
        public string Store2WhSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2WhSave: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2WhSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Store2WhSave: end");
            return response;
        }

        /// <summary>
        /// Requesting delivering from store to warehouse.
        /// </summary>
        public string Store2WhRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2WhRequest: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2WhRequest: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseBackendController(_contextOptions).Store2WhRequest(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Store2WhRequest: end");
            return response;
        }

        /// <summary>
        /// A method that is responsible for confirming the delivery of products from the store to the warehouse.
        /// </summary>
        public string Store2WhConfirm(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Store2WhConfirm: begin");
            try
            {
                // Initializing.
                DeliveryOrder model = apiOperation.RequestObject as DeliveryOrder;

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Store2WhConfirm: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseBackendController(_contextOptions).Store2WhConfirm(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Store2WhConfirm: end");
            return response;
        }
        
        /// <summary>
        /// Storing the request for warhouse employee to deliver from warehouse to kitchen. 
        /// </summary>
        public string Wh2KitchenSave(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: begin");
            try
            {
                DeliveryWh2Kitchen model = apiOperation.RequestObject as DeliveryWh2Kitchen;

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Wh2KitchenSave: end");
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Wh2KitchenRespond(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Wh2KitchenRespond: begin");
            try
            {
                // Initializing.
                DeliveryWh2Kitchen model = apiOperation.RequestObject as DeliveryWh2Kitchen;

                // Update DB.
                System.Console.WriteLine("WarehouseClient.Wh2KitchenRespond: cache");

                // Send HTTP request.
                // think about what type of input parameter the kitchen controller will accept to prepare an order.
                string backendResponse = new WarehouseBackendController(_contextOptions).Wh2KitchenRespond(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Wh2KitchenRespond: end");
            return response;
        }

        /// <summary>
        /// A method that allows you to begin the process of delivering finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhStart(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Kitchen2WhStart: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Kitchen2WhStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
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
        public string Kitchen2WhExecute(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                // Update DB.
                System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: cache");

                // Send HTTP request.
                string backendResponse = new WarehouseBackendController(_contextOptions).Kitchen2WhExecute(new ApiOperation
                {
                    RequestObject = model
                });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseClient.Kitchen2WhExecute: end");
            return response;
        }
    }
}