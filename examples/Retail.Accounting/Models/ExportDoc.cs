using System;
using System.Collections.Generic;

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class ExportDoc
    {
        public int ExportDocId { get; set; }
        public string DocNum { get; set; }
        public DateTime DateTime { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PurchaserId { get; set; }
        public Partner Purchaser { get; set; }

        public List<ExportItem> ExportItems { get; set; }
    }
}
