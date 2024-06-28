using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly ILogger<EmployeesModel> _logger;

        public EmployeesModel(ILogger<EmployeesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string employee_name, string manager_name, 
            string department, float salary, string email, string phone)
        {
            bool isEmployeeCorrect = (employee_name != null && employee_name != string.Empty);
            bool isManagerCorrect = (manager_name != null && manager_name != string.Empty);
            bool isDepartmentCorrect = (department != null && department != string.Empty);
            bool isSalaryCorrect = (salary > 0);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isEmployeeCorrect && isManagerCorrect && isDepartmentCorrect && 
                isSalaryCorrect && isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.InsertEmployee(employee_name, salary, email, 
                    phone, manager_name, department); 
                Repository.IsErrorMessageActivatedOnEmployees = false; 
                _logger.LogInformation($"Added new Employee (employee_name: {employee_name}, manager_name: {manager_name}, department: {department})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnEmployees = true; 
                Repository.ErrorMessageOnEmployees = Repository.GetErrorMessage("Add", 
                    "employee name, manager name, department, salary, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int employee_id, string employee_name, 
            string manager_name, string department, float salary, string email, 
            string phone)
        {
            bool isEmployeeIdCorrect = (employee_id > 0);
            bool isEmployeeNameCorrect = (employee_name != null && employee_name != string.Empty);
            bool isManagerCorrect = (manager_name != null && manager_name != string.Empty);
            bool isDepartmentCorrect = (department != null && department != string.Empty);
            bool isSalaryCorrect = (salary > 0);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isEmployeeIdCorrect && isEmployeeNameCorrect && 
                isManagerCorrect && isDepartmentCorrect && 
                isSalaryCorrect && isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.UpdateEmployee(employee_id, employee_name, 
                    salary, email, phone, manager_name, department); 
                Repository.IsErrorMessageActivatedOnEmployees = false; 
                _logger.LogInformation($"Edited an Employee (employee_name: {employee_name}, manager_name: {manager_name}, department: {department})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnEmployees = true; 
                Repository.ErrorMessageOnEmployees = Repository.GetErrorMessage("Edit", 
                    "employee ID, employee name, manager name, department, salary, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int employee_id)
        {
            bool isEmployeeIdCorrect = (employee_id > 0);
            if (isEmployeeIdCorrect)
            {
                Repository.Instance.DeleteEmployee(employee_id);
                Repository.IsErrorMessageActivatedOnEmployees = false; 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnEmployees = true; 
                Repository.ErrorMessageOnEmployees = Repository.GetErrorMessage("Delete", "employee ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnEmployees = false; 
        }
    }
}
