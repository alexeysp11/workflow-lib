using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Dto;
using WorkflowLib.Examples.EmployeesMvc.Core.Enums;
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
        IEnumerable<Employee> result;
        if (!string.IsNullOrEmpty(employeeDto.FullName) && !string.IsNullOrEmpty(employeeDto.Gender)
            && !string.IsNullOrEmpty(employeeDto.JobTitle) && !string.IsNullOrEmpty(employeeDto.Department))
        {
            result = getEmployees(x => 
                x.FullName.Contains(employeeDto.FullName) 
                && x.Gender.ToString() == employeeDto.Gender
                && x.BirthDate >= employeeDto.DateMin 
                && x.BirthDate <= employeeDto.DateMax
                && x.JobTitle.ToString() == employeeDto.JobTitle 
                && x.Department.ToString() == employeeDto.Department);
        }
        else
        {
            // Retrieve data using the specified filter.
            result = getEmployees(x => x.BirthDate >= employeeDto.DateMin && x.BirthDate <= employeeDto.DateMax);
            if (!string.IsNullOrEmpty(employeeDto.FullName))
                result = result.Where(x => x.FullName.Contains(employeeDto.FullName));
            if (!string.IsNullOrEmpty(employeeDto.Gender))
                result = result.Where(x => x.Gender.ToString() == employeeDto.Gender);
            if (!string.IsNullOrEmpty(employeeDto.JobTitle))
                result = result.Where(x => x.JobTitle.ToString() == employeeDto.JobTitle);
            if (!string.IsNullOrEmpty(employeeDto.Department))
                result = result.Where(x => x.Department.ToString() == employeeDto.Department);
            
            // Retrive date using exclude filter.
            if (filterOptions == FilterOptionType.ExcludeEmployee)
            {
                var excludeList = getEmployees(x => true);
                foreach (var item in result)
                    excludeList = excludeList.Where(x => x.FullName != item.FullName).ToList();
                return excludeList;
            }
        }
        return result;
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
        var employees = new List<Employee>();
        var vacations = new List<Vacation>();

        // Get filtered employees.
        // If all filters are empty and current is not empty, then don't filter employees.
        // TODO: the following if-statement looks a little bit weird, so try to express the condition above in the more elegant way.
        if (
            (
                string.IsNullOrEmpty(employeeDto.FullName)
                && employeeDto.AgeMin <= 0
                && employeeDto.AgeMax <= 0
                && string.IsNullOrEmpty(employeeDto.Gender)
                && string.IsNullOrEmpty(employeeDto.JobTitle)
                && string.IsNullOrEmpty(employeeDto.Department)
            )
            && !string.IsNullOrEmpty(currentFullName))
        {
        }
        else
        {
            employees = FilterEmployees(employeeDto, FilterOptionType.NoFiltersApplied, getEmployees).ToList();
        }

        // Get vacations using filter.
        foreach (var employee in employees)
        {
            var vacationsFiltered = getVacations(x => x.Employee.FullName == employee.FullName);
            vacations.AddRange(vacationsFiltered);
        }

        // Get vacations of the current employee.
        if (!string.IsNullOrEmpty(currentFullName))
        {
            var currentVacations = getVacations(x => x.Employee.FullName.Contains(currentFullName));
            foreach (var vacation in currentVacations)
            {
                if (vacations.Where(x =>
                        x.BeginDate == vacation.BeginDate
                        && x.EndDate == vacation.EndDate
                        && x.Employee.FullName == vacation.Employee.FullName)
                    .ToList().Count == 0)
                {
                    vacations.Add(vacation);
                }
            }
        }

        // Apply filter options.
        if (filterOptions == FilterOptionType.ShowIntersectionsVacations)
            return GetIntersections(vacations, currentFullName);
        if (filterOptions == FilterOptionType.ExcludeIntersectionsVacations)
            return ExcludeIntersections(vacations, currentFullName);
        return vacations;
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