using System;
using System.Collections.Generic;

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
