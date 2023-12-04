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

// Step 3: finish delivering from warehouse to kitchen.
System.Console.WriteLine("\nStep 3: finish delivering from warehouse to kitchen.");
IFlowchartStep step3 = new FinishWh2KitchenStep();
step3.Start();

// Step 4: request for delivering from store to warehouse.
System.Console.WriteLine("\nStep 4: request for delivering from store to warehouse.");
IFlowchartStep step4 = new RequestStore2WhStep();
step4.Start();

// Step 5: deliver from store to warehouse.
System.Console.WriteLine("\nStep 5: deliver from store to warehouse.");
IFlowchartStep step5 = new FinishStore2WhStep();
step5.Start();

// Step 6: confirm delivering from store to warehouse.
System.Console.WriteLine("\nStep 6: confirm delivering from store to warehouse.");
IFlowchartStep step6 = new ConfirmStore2WhStep();
step6.Start();

// Step 7: prepare meal.
System.Console.WriteLine("\nStep 7: prepare meal.");
IFlowchartStep step7 = new PrepareMealStep();
step7.Start();

// Step 8: deliver from kitchen to warehouse.
System.Console.WriteLine("\nStep 8: deliver from kitchen to warehouse.");
IFlowchartStep step8 = new Kitchen2WhStep();
step8.Start();

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
