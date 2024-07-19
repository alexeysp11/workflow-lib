using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;
using WorkflowLib.Examples.EmployeesMvc.Helpers; 

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;

/// <summary>
/// Class for applying filters against initial datasets.
/// </summary>
public class CommonDataFilter : ICommonDataFilter
{
    #region Filter employees
    /// <summary>
    /// Applies filter to the employees collection.
    /// </summary>
    public IEnumerable<Employee> FilterEmployees(
        string fullName,
        string ageMin,
        string ageMax,
        string gender,
        string jobTitle,
        string department,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees)
    {
        int ageMinInt = ConfigHelper.EmployeeMinAge; 
        int ageMaxInt = ConfigHelper.EmployeeMaxAge; 
        if (!string.IsNullOrEmpty(ageMin))
        {
            if (!System.Int32.TryParse(ageMin, out ageMinInt)) 
                throw new System.Exception("Unable to convert string parameter 'ageMin' to integer"); 
        }
        if (!string.IsNullOrEmpty(ageMax))
        {
            if (!System.Int32.TryParse(ageMax, out ageMaxInt)) 
                throw new System.Exception("Unable to convert string parameter 'ageMax' to integer"); 
        }
        return FilterEmployees(fullName, ageMinInt, ageMaxInt, gender, jobTitle, department, filterOptions, getEmployees); 
    }

    /// <summary>
    /// Applies filter to the employees collection.
    /// </summary>
    private IEnumerable<Employee> FilterEmployees(
        string fullName,
        int ageMin,
        int ageMax,
        string gender,
        string jobTitle,
        string department,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees)
    {
        var dateMin = System.DateTime.Now.AddYears(-ageMax); 
        var dateMax = System.DateTime.Now.AddYears(-ageMin); 
        return FilterEmployees(fullName, dateMin, dateMax, gender, jobTitle, department, filterOptions, getEmployees); 
    }

    /// <summary>
    /// Applies filter to the employees collection.
    /// </summary>
    private IEnumerable<Employee> FilterEmployees(
        string fullName,
        System.DateTime dateMin,
        System.DateTime dateMax,
        string gender,
        string jobTitle,
        string department,
        string filterOptions,
        Func<Expression<Func<Employee, bool>>, List<Employee>> getEmployees)
    {
        IEnumerable<Employee> result; 
        if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(gender)
            && !string.IsNullOrEmpty(jobTitle) && !string.IsNullOrEmpty(department))
        {
            result = getEmployees(x => 
                x.FullName.Contains(fullName) 
                && x.Gender.ToString() == gender
                && x.BirthDate >= dateMin 
                && x.BirthDate <= dateMax
                && x.JobTitle.ToString() == jobTitle 
                && x.Department.ToString() == department); 
        }
        else 
        {
            // Retrieve data using the specified filter.
            result = getEmployees(x => x.BirthDate >= dateMin && x.BirthDate <= dateMax); 
            if (!string.IsNullOrEmpty(fullName))
                result = result.Where(x => x.FullName.Contains(fullName)); 
            if (!string.IsNullOrEmpty(gender))
                result = result.Where(x => x.Gender.ToString() == gender); 
            if (!string.IsNullOrEmpty(jobTitle))
                result = result.Where(x => x.JobTitle.ToString() == jobTitle); 
            if (!string.IsNullOrEmpty(department))
                result = result.Where(x => x.Department.ToString() == department); 
            
            // Retrive date using exclude filter.
            if (filterOptions == StringHelper.FindFilterOptionsExcludeEmployee)
            {
                var excludeList = getEmployees(x => true); 
                foreach (var item in result)
                    excludeList = excludeList.Where(x => x.FullName != item.FullName).ToList(); 
                return excludeList; 
            }
        }
        return result; 
    }
    #endregion  // Filter employees

    #region Filter vacations
    /// <summary>
    /// Applies filters to the vacation collection.
    /// </summary>
    public IEnumerable<Vacation> FilterVacations(
        string fullName,
        string ageMin,
        string ageMax,
        string gender,
        string jobTitle,
        string department,
        string currentFio,
        string filterOptions,
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
                string.IsNullOrEmpty(fullName) 
                && string.IsNullOrEmpty(ageMin) 
                && string.IsNullOrEmpty(ageMax)
                && string.IsNullOrEmpty(gender)
                && string.IsNullOrEmpty(jobTitle)
                && string.IsNullOrEmpty(department)
            )
            && !string.IsNullOrEmpty(currentFio))
        {
        }
        else
        {
            employees = FilterEmployees(fullName, ageMin, ageMax, gender, jobTitle, department, "", getEmployees).ToList(); 
        }

        // Get vacations using filter.
        foreach (var employee in employees)
        {
            var vacationsFiltered = getVacations(x => x.Employee.FullName == employee.FullName); 
            vacations.AddRange(vacationsFiltered); 
        }

        // Get vacations of the current employee.
        if (!string.IsNullOrEmpty(currentFio))
        {
            var currentVacations = getVacations(x => x.Employee.FullName.Contains(currentFio)); 
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
        if (filterOptions == StringHelper.FindFilterOptionsShowIntersections)
            return GetIntersections(vacations, currentFio); 
        if (filterOptions == StringHelper.FindFilterOptionsExcludeIntersections)
            return ExcludeIntersections(vacations, currentFio); 
        return vacations; 
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Vacation> GetIntersections(List<Vacation> vacations, string currentFio)
    {
        if (string.IsNullOrEmpty(currentFio))
            return new List<Vacation>(); 
        
        // 
        var filteredVacations = new List<Vacation>(); 
        var employeeVacations = vacations.Where(x => x.Employee.FullName.Contains(currentFio)); 
        var otherVacations = vacations.Where(x => !x.Employee.FullName.Contains(currentFio)); 
        filteredVacations.AddRange(employeeVacations); 
        foreach (var vacation in employeeVacations)
        {
            // Scenario 1: 
            // vacation:    |-----|
            // others:    |-----|
            // Scenario 2: 
            // vacation:    |-----|
            // others:         |-----|
            // Scenario 3: 
            // vacation:    |-----|
            // others:      |-----|
            var filtered = otherVacations.Where(x => 
                (x.BeginDate <= vacation.BeginDate && x.EndDate > vacation.BeginDate)
                || (x.BeginDate < vacation.EndDate && x.BeginDate >= vacation.EndDate)
                || (x.BeginDate == vacation.BeginDate && x.EndDate == vacation.EndDate)); 
            filteredVacations.AddRange(filtered); 
        }
        return filteredVacations; 
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Vacation> ExcludeIntersections(List<Vacation> vacations, string currentFio)
    {
        if (string.IsNullOrEmpty(currentFio))
            return new List<Vacation>(); 

        // 
        var intersections = GetIntersections(vacations, currentFio); 
        var excludeList = vacations.Where(x => true).ToList(); 
        foreach (var intersection in intersections)
        {
            excludeList = excludeList.Where(x => 
                x.Employee.FullName.Contains(currentFio) 
                || (x.BeginDate != intersection.BeginDate && x.EndDate != intersection.EndDate)).ToList(); 
        }
        return excludeList; 
    }
    #endregion  // Filter vacations
}