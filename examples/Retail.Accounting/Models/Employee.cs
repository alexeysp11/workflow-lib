using System;
using System.Collections.Generic; 

namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> Employees { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Contract> Contracts { get; set; }

        public List<ImportDoc> ImportDocs { get; set; }
        public List<ExportDoc> ExportDocs { get; set; }
    }
}
