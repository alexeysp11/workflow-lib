using System.Linq.Expressions;
using WorkflowLib.UnifiedBusinessPlatform.Core.Dto;
using WorkflowLib.UnifiedBusinessPlatform.Core.Enums;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Domain.Filtering;

public interface ICommonDataFilter
{
    IEnumerable<Employee> FilterEmployees(
        EmployeeDto employeeDto,
        FilterOptionType filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees);
    
    IEnumerable<Absense> FilterVacations(
        EmployeeDto employeeDto,
        string currentFullName,
        FilterOptionType filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees,
        Func<Expression<Func<Absense, bool>>, List<Absense>> getVacations);  
}