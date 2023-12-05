using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.FlowchartSteps;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

// Step 01: make order.
System.Console.WriteLine("\nStep 01: make order.");
IFlowchartStep step01 = new MakeOrderStep();
step01.Start();

// Step 02: make payment.
System.Console.WriteLine("\nStep 02: make payment.");
IFlowchartStep step02 = new MakePaymentStep();
step02.Start();

// Step 03: finish delivering from warehouse to kitchen.
System.Console.WriteLine("\nStep 03: finish delivering from warehouse to kitchen.");
IFlowchartStep step03 = new FinishWh2KitchenStep();
step03.Start();

// Step 04: request for delivering from store to warehouse.
System.Console.WriteLine("\nStep 04: request for delivering from store to warehouse.");
IFlowchartStep step04 = new RequestStore2WhStep();
step04.Start();

// Step 05: deliver from store to warehouse.
System.Console.WriteLine("\nStep 05: deliver from store to warehouse.");
IFlowchartStep step05 = new FinishStore2WhStep();
step05.Start();

// Step 06: confirm delivering from store to warehouse.
System.Console.WriteLine("\nStep 06: confirm delivering from store to warehouse.");
IFlowchartStep step06 = new ConfirmStore2WhStep();
step06.Start();

// Step 07: prepare meal.
System.Console.WriteLine("\nStep 07: prepare meal.");
IFlowchartStep step07 = new PrepareMealStep();
step07.Start();

// Step 08: deliver from kitchen to warehouse.
System.Console.WriteLine("\nStep 08: deliver from kitchen to warehouse.");
IFlowchartStep step08 = new Kitchen2WhStep();
step08.Start();

// Step 09: scan QR code on the delivery order.
System.Console.WriteLine("\nStep 09: scan QR code on the delivery order.");
IFlowchartStep step09 = new ScanQrOnOrderStep();
step09.Start();

// Step 10: scan backpack.
System.Console.WriteLine("\nStep 10: scan backpack.");
IFlowchartStep step10 = new ScanBackpackStep();
step10.Start();

// Step 11: deliver order.
System.Console.WriteLine("\nStep 11: deliver order.");
IFlowchartStep step11 = new DeliverOrderStep();
step11.Start();

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
