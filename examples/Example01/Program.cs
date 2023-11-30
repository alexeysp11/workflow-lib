using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.FlowchartSteps;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

// Step 1: make order.
System.Console.WriteLine("\nStep 1: make order.");
IFlowchartStep step1 = new MakeOrderStep();
step1.Start();

// Step 2: make payment.
System.Console.WriteLine("\nStep 2: make payment.");
IFlowchartStep step2 = new MakePaymentStep();
step2.Start();

// Creating a business process 
// var makeOrderProcess = new BusinessProcess
// {
//     Name = "makeorder"
// };

// // Create context 
// WorkflowInstanceContext context = new MakeOrderContext()
// {
//     PlaceOrderModel = new PlaceOrderModel
//     {
//         UserUid = System.Guid.NewGuid().ToString(),
//         Login = "user01",
//         PhoneNumber = "+16425",
//         City = "Coutry 1, City 1",
//         Address = "123 Random str",
//         ProductIds = new List<int>(new int[] { 1 })
//     }
// };

// // Creating a workflow instance
// var wfInstance = new WorkflowInstance
// {
//     BusinessProcess = makeOrderProcess,
//     Context = context
// };

// var parsedContext = (MakeOrderContext)(wfInstance.Context);
// parsedContext.DeliveryOrder = new DeliveryOrder
// {
//     Products = new List<Product>
//     {
//         new Product
//         {
//             Id = 1,
//             Name = "Product 1",
//             Price = 12.5m,
//             Quantity = 1
//         }
//     },
//     DeliveryPrice = 20.0m
// };

// System.Console.WriteLine($"BusinessProcess: {wfInstance.BusinessProcess.Name}");
// System.Console.WriteLine($"Address: {parsedContext.PlaceOrderModel.Address}");
// System.Console.WriteLine($"DeliveryPrice: {parsedContext.DeliveryOrder.DeliveryPrice}");
// System.Console.WriteLine($"Name: {parsedContext.DeliveryOrder.Products.FirstOrDefault().Name}");
