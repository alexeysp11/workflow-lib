using System;
using System.Collections.Generic;

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public class ImportDocInfo
    {
        public int ImportDocId { get; set; }
        public string DocNum { get; set; }
        public string EmployeeName { get; set; }
        public string SupplierName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
