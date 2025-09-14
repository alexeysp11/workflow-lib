using System.Linq.Expressions;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Dto;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Enums;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;

namespace VelocipedeUtils.UnifiedBusinessPlatform.Core.Domain.Filtering;

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