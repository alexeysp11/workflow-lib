using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowLib.Examples.Retail.Accounting.Models; 

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public static class DepartmentService
    {
        public static void InsertDepartmentIfNotExists(string departmentTitle)
        {
            using (var db = new AccountingContext())
            {
                var departmentList = db.Department
                    .Where(p => p.Title == departmentTitle)
                    .ToList(); 
                if (departmentList.Count == 0)
                {
                    db.Add(new Department { Title = departmentTitle });
                    db.SaveChanges();
                }
            }
        }

        public static int? GetDepartmentId(string departmentTitle)
        {
            int? departmentId = 0; 
            using (var db = new AccountingContext())
            {
                var departmentList = db.Department
                    .Where(d => d.Title == departmentTitle)
                    .ToList(); 
                if (departmentList.Count != 0)
                {
                    departmentId = departmentList[0].DepartmentId; 
                }
                else
                {
                    departmentId = null; 
                }
            }
            return departmentId; 
        }
    }
}