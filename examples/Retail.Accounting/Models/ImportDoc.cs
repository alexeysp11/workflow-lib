using System;
using System.Collections.Generic; 

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class ImportDoc
    {
        public int ImportDocId { get; set; }
        public string DocNum { get; set; }
        public DateTime DateTime { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int SupplierId { get; set; }
        public Partner Supplier { get; set; }

        public List<ImportItem> ImportItems { get; set; }
    }
}
