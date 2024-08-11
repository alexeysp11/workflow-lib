using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Dto;
using WorkflowLib.Examples.EmployeesMvc.Core.Enums;
using WorkflowLib.Examples.EmployeesMvc.Core.Extensions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;

/// <summary>
/// Class for applying filters against initial datasets.
/// </summary>
public class CommonDataFilter : ICommonDataFilter
{
    private AppSettings _appSettings;

    public CommonDataFilter(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    /// <summary>
    /// Applies filter to the employees collection.
    /// </summary>
    public IEnumerable<Employee> FilterEmployees(
        EmployeeDto employeeDto,
        FilterOptionType filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees)
    {
        // 1. Build the main filter expression.
        Expression<Func<Employee, bool>> filterExpression = x => 
            x.BirthDate >= employeeDto.DateMin && x.BirthDate <= employeeDto.DateMax;

        // 2. Add additional filters based on provided criteria.
        if (!string.IsNullOrEmpty(employeeDto.FullName))
        {
            filterExpression = filterExpression.AndAlso(x => x.FullName.Contains(employeeDto.FullName));
        }
        if (!string.IsNullOrEmpty(employeeDto.Gender))
        {
            filterExpression = filterExpression.AndAlso(x => x.Gender.ToString() == employeeDto.Gender);
        }
        if (!string.IsNullOrEmpty(employeeDto.JobTitle))
        {
            filterExpression = filterExpression.AndAlso(x => x.JobTitle.ToString() == employeeDto.JobTitle);
        }
        if (!string.IsNullOrEmpty(employeeDto.Department))
        {
            filterExpression = filterExpression.AndAlso(x => x.Department.ToString() == employeeDto.Department);
        }

        // 3. Apply the filter.
        var filteredEmployees = getEmployees(filterExpression);

        // 4. Handle exclude filter.
        if (filterOptions == FilterOptionType.ExcludeEmployee)
        {
            var allEmployees = getEmployees(x => true);
            return allEmployees.Except(filteredEmployees);
        }

        return filteredEmployees;
    }

    /// <summary>
    /// Applies filters to the vacation collection.
    /// </summary>
    public IEnumerable<Vacation> FilterVacations(
        EmployeeDto employeeDto,
        string currentFullName,
        FilterOptionType filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees,
        Func<Expression<Func<Vacation, bool>>, List<Vacation>> getVacations)
    {
        if (employeeDto.IsEmpty() && !string.IsNullOrEmpty(currentFullName))
        {
            return FilterVacationsByCurrentEmployee(currentFullName, getVacations, filterOptions);
        }
        var employees = FilterEmployees(employeeDto, FilterOptionType.NoFiltersApplied, getEmployees);
        var vacations = employees.SelectMany(e => getVacations(v => v.Employee.FullName == e.FullName)).ToList();
        return FilterVacationsByCurrentEmployee(currentFullName, getVacations, filterOptions, vacations);
    }

    /// <summary>
    /// Filter vacations by current employee name.
    /// </summary>
    private IEnumerable<Vacation> FilterVacationsByCurrentEmployee(
        string currentFullName,
        Func<Expression<Func<Vacation, bool>>, List<Vacation>> getVacations,
        FilterOptionType filterOptions,
        List<Vacation> existingVacations = null)
    {
        // Get vacations of the current employee.
        if (!string.IsNullOrEmpty(currentFullName))
        {
            var currentVacations = getVacations(v => v.Employee.FullName.Contains(currentFullName));
            if (existingVacations == null)
            {
                existingVacations = currentVacations.ToList();
            }
            else
            {
                // Add current vacations that are not already in the list.
                existingVacations.AddRange(currentVacations.Where(v => !existingVacations.Any(x =>
                    x.BeginDate == v.BeginDate && x.EndDate == v.EndDate && x.Employee.FullName == v.Employee.FullName)));
            }
        }

        // Apply filter options.
        if (filterOptions == FilterOptionType.ShowIntersectionsVacations)
            return GetIntersections(existingVacations ?? new List<Vacation>(), currentFullName);
        if (filterOptions == FilterOptionType.ExcludeIntersectionsVacations)
            return ExcludeIntersections(existingVacations ?? new List<Vacation>(), currentFullName);
        return existingVacations ?? new List<Vacation>();
    }

    /// <summary>
    /// Gets a list of intersections between the specified employee's vacations and the vacations of other employees.
    /// </summary>
    private List<Vacation> GetIntersections(
        List<Vacation> vacations,
        string currentFullName)
    {
        if (string.IsNullOrEmpty(currentFullName))
            return new List<Vacation>();
        
        var filteredVacations = new List<Vacation>();
        foreach (var vacation in vacations)
        {
            if (!vacation.Employee.FullName.Contains(currentFullName))
            {
                continue;
            }
            filteredVacations.Add(vacation);
            var filtered = vacations
                .Where(x => !x.Employee.FullName.Contains(currentFullName)
                    && x.BeginDate < vacation.EndDate
                    && vacation.BeginDate < x.EndDate);
            filteredVacations.AddRange(filtered);
        }
        return filteredVacations;
    }

    /// <summary>
    /// Gets a list of vacations that do not intersect with the specified employee's vacations.
    /// </summary>
    private List<Vacation> ExcludeIntersections(
        List<Vacation> vacations,
        string currentFullName)
    {
        if (string.IsNullOrEmpty(currentFullName))
            return new List<Vacation>();

        var excludeList = new List<Vacation>();
        foreach (var vacation in vacations)
        {
            if (vacation.Employee.FullName.Contains(currentFullName))
            {
                excludeList.Add(vacation);
                continue;
            }
            var hasIntersection = vacations
                .Where(x => x.Employee.FullName.Contains(currentFullName)
                    && x.BeginDate < vacation.EndDate && vacation.BeginDate < x.EndDate)
                .Any();
            if (!hasIntersection)
            {
                excludeList.Add(vacation);
            }
        }
        return excludeList;
    }
}