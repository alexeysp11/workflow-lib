using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Example01.Interfaces;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class CustomerClientController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private CustomerBackendController _customerBackendController { get; set; }

        public CustomerClientController(
            DbContextOptions<DeliveringContext> contextOptions,
            CustomerBackendController customerBackendController)
        {
            _contextOptions = contextOptions;
            _customerBackendController = customerBackendController;
        }

        public string MakeOrder(ApiOperation apiOperation)
        {
            // 
            return "";
        }

        public string MakeOrderRequest(ApiOperation apiOperation)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                InitialOrder model = apiOperation.RequestObject as InitialOrder;
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: validation");

                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");
                var products = new List<InitialOrderProduct>();
                foreach (var pid in model.ProductIds)
                {
                    if (products.Any(x => x.Product.Id == pid))
                        continue;
                    var wp = context.WHProducts.FirstOrDefault(x => x.Product != null && x.Product.Id == pid);
                    if (wp == null)
                        throw new System.Exception("Database consistency is violated: product with such ID does not exist in the DB: " + pid);
                    int qty = model.ProductIds.Where(x => x == pid).Count();
                    var p = context.Products.Where(x => x.Id == pid).FirstOrDefault();
                    products.Add(new InitialOrderProduct
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Name = p.Name,
                        Product = p,
                        InitialOrder = model,
                        Quantity = qty
                    });
                    model.PaymentAmount += qty * p.Price;
                }
                model.Uid = System.Guid.NewGuid().ToString();
                context.InitialOrderProducts.AddRange(products);
                context.InitialOrders.Add(model);
                context.SaveChanges();

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

        public async Task<string> MakeOrderAsync(ApiOperation apiOperation)
        {
            await Task.Delay(500);
            return "";
        }
        
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
                using var context = new DeliveringContext(_contextOptions);

                // Validation.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault();
                if (deliveryOrder.Payments == null)
                    deliveryOrder.Payments = new List<Payment>();
                foreach (var p in model.Payments)
                {
                    var pf = deliveryOrder.Payments.Where(x => x.Uid == p.Uid).FirstOrDefault();
                    if (pf == null)
                    {
                        deliveryOrder.Payments.Add(p);
                    }
                    else
                    {
                        pf.CardNumber = p.CardNumber;
                        pf.Status = p.Status;
                    }
                }
                context.SaveChanges();

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