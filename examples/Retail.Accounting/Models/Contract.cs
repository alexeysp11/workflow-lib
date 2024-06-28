using System;
using System.Collections.Generic; 

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}