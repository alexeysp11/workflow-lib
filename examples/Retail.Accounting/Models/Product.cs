using System;
using System.Collections.Generic; 

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }

        public List<ExportItem> ExportItems { get; set; }
        public List<ImportItem> ImportItems { get; set; }
    }
}
