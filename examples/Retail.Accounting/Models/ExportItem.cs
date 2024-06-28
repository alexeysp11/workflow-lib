using System;

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class ExportItem
    {
        public int ExportItemId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int ExportDocId { get; set; }
        public ExportDoc ExportDoc { get; set; }
    }
}
