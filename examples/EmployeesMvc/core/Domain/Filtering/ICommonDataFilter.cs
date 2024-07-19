using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;

public interface ICommonDataFilter
{
    IEnumerable<Employee> FilterEmployees(
        string fullName,
        string ageMin,
        string ageMax,
        string gender,
        string jobTitle,
        string department,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees); 
    
    IEnumerable<Vacation> FilterVacations(
        string fullName,
        string ageMin,
        string ageMax,
        string gender,
        string jobTitle,
        string department,
        string currentFio,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees,
        Func<Expression<Func<Vacation, bool>>, List<Vacation>> getVacations);  
}