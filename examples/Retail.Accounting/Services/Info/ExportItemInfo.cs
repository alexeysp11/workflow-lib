using System;

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public class ExportItemInfo
    {
        public int ExportItemId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
    }
}
