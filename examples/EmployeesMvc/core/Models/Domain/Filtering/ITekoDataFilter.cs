using System.Linq.Expressions;

namespace WorkflowLib.Examples.EmployeesMvc.Models;

public interface ITekoDataFilter
{
    IEnumerable<Employee> FilterEmployees(string fio, string ageMin, string ageMax, string gender, string jobTitle, string department, 
        string filterOptions, Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees); 
    
    IEnumerable<Vacation> FilterVacations(string fio, string ageMin, string ageMax, string gender, string jobTitle, string department, 
        string currentFio, string filterOptions, Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees,
        Func<Expression<Func<Vacation, bool>>, List<Vacation>> getVacations);  
}