using System.Linq;
using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.FlowchartSteps;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01
{
    /// <summary>
    /// 
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private MakeOrderStep _step01 { get; set; }
        private MakePaymentStep _step02 { get; set; }
        private FinishWh2KitchenStep _step03 { get; set; }
        private RequestStore2WhStep _step04 { get; set; }
        private FinishStore2WhStep _step05 { get; set; }
        private ConfirmStore2WhStep _step06 { get; set; }
        private PrepareMealStep _step07 { get; set; }
        private Kitchen2WhStep _step08 { get; set; }
        private ScanQrOnOrderStep _step09 { get; set; }
        private ScanBackpackStep _step10 { get; set; }
        private DeliverOrderStep _step11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExampleInstance(
            MakeOrderStep step01, 
            MakePaymentStep step02, 
            FinishWh2KitchenStep step03, 
            RequestStore2WhStep step04, 
            FinishStore2WhStep step05, 
            ConfirmStore2WhStep step06, 
            PrepareMealStep step07, 
            Kitchen2WhStep step08, 
            ScanQrOnOrderStep step09, 
            ScanBackpackStep step10,
            DeliverOrderStep step11)
        {
            _step01 = step01;
            _step02 = step02;
            _step03 = step03;
            _step04 = step04;
            _step05 = step05;
            _step06 = step06;
            _step07 = step07;
            _step08 = step08;
            _step09 = step09;
            _step10 = step10;
            _step11 = step11;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            // Step 01: make order.
            System.Console.WriteLine("\nStep 01: make order.");
            _step01.Start();

            // Step 02: make payment.
            System.Console.WriteLine("\nStep 02: make payment.");
            _step02.Start();

            // Step 03: finish delivering from warehouse to kitchen.
            System.Console.WriteLine("\nStep 03: finish delivering from warehouse to kitchen.");
            _step03.Start();

            // Step 04: request for delivering from store to warehouse.
            System.Console.WriteLine("\nStep 04: request for delivering from store to warehouse.");
            _step04.Start();

            // Step 05: deliver from store to warehouse.
            System.Console.WriteLine("\nStep 05: deliver from store to warehouse.");
            _step05.Start();

            // Step 06: confirm delivering from store to warehouse.
            System.Console.WriteLine("\nStep 06: confirm delivering from store to warehouse.");
            _step06.Start();

            // Step 07: prepare meal.
            System.Console.WriteLine("\nStep 07: prepare meal.");
            _step07.Start();

            // Step 08: deliver from kitchen to warehouse.
            System.Console.WriteLine("\nStep 08: deliver from kitchen to warehouse.");
            _step08.Start();

            // Step 09: scan QR code on the delivery order.
            System.Console.WriteLine("\nStep 09: scan QR code on the delivery order.");
            _step09.Start();

            // Step 10: scan backpack.
            System.Console.WriteLine("\nStep 10: scan backpack.");
            _step10.Start();

            // Step 11: deliver order.
            System.Console.WriteLine("\nStep 11: deliver order.");
            _step11.Start();
        }
    }
}