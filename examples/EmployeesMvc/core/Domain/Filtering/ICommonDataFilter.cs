using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Dto;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;

public interface ICommonDataFilter
{
    IEnumerable<Employee> FilterEmployees(
        EmployeeDto employeeDto,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees);
    
    IEnumerable<Vacation> FilterVacations(
        EmployeeDto employeeDto,
        string currentFullName,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees,
        Func<Expression<Func<Vacation, bool>>, List<Vacation>> getVacations);  
}