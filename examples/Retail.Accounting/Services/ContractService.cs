using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowLib.Examples.Retail.Accounting.Models;

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public static class ContractService
    {
        public static void InsertContract(int employeeId, DateTime dateTimeStart, 
            DateTime? dateTimeEnd)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new Contract 
                { 
                    EmployeeId = employeeId, 
                    EmploymentDate = dateTimeStart, 
                    TerminationDate = dateTimeEnd 
                });
                db.SaveChanges();
            }
        }

        public static void InsertContractFromUi(string employeeName, DateTime dateTimeStart, 
            DateTime? dateTimeEnd)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName);
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null);
                employeeId = EmployeeService.GetEmployeeId(employeeName);
            }
            ContractService.InsertContract((int)employeeId, dateTimeStart, dateTimeEnd);
        }
    }
}