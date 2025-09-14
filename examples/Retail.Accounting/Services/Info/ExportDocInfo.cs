using System;
using System.Collections.Generic;

namespace VelocipedeUtils.Examples.Retail.Accounting.Services
{
    public class ExportDocInfo
    {
        public int ExportDocId { get; set; }
        public string DocNum { get; set; }
        public string EmployeeName { get; set; }
        public string PurchaserName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
