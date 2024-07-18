namespace WorkflowLib.Examples.EmployeesMvc.Helpers;

/// <summary>
/// Helper for storing commonly used string values 
/// </summary>
public static class StringHelper
{
    #region TempData UID
    /// <summary>
    /// Name of a variable for storing UID of initial dataset of employees 
    /// </summary>
    public readonly static string EmployeesUidStr = "employeesUid"; 
    /// <summary>
    /// Name of a variable for storing UID of initial dataset of vacations
    /// </summary>
    public readonly static string VacationsUidStr = "vacationsUid"; 
    /// <summary>
    /// Name of a variable for storing filter info on the Employees page
    /// </summary>
    public readonly static string FilterInfoEmployeesStr = "filterInfoEmployees"; 
    /// <summary>
    /// Name of a variable for storing filter info on the Vacations page
    /// </summary>
    public readonly static string FilterInfoVacationsStr = "filterInfoVacations"; 
    /// <summary>
    /// Name of a variable for storing filter info applied for a "current empolyee" on the Vacations page
    /// </summary>
    public readonly static string EmployeeInfoVacationsStr = "employeeInfoVacations"; 
    /// <summary>
    /// Name of a variable for storing filter options on the Employees page
    /// </summary>
    public readonly static string FilterOptionsEmployeesStr = "filterOptionsEmployees"; 
    /// <summary>
    /// Name of a variable for storing filter options on the Vacations page
    /// </summary>
    public readonly static string FilterOptionsVacationsStr = "filterOptionsVacations"; 
    #endregion  // TempData UID

    #region Filter options
    /// <summary>
    /// Message displayed when no filters applied 
    /// </summary>
    public readonly static string NoFiltersApplied = "No filters applied"; 
    /// <summary>
    /// Options for showing filtered elements on the Employees page 
    /// </summary>
    public readonly static string FindFilterOptionsShowEmployee = "Show employee"; 
    /// <summary>
    /// Options for excluding filtered elements on the Employees page 
    /// </summary>
    public readonly static string FindFilterOptionsExcludeEmployee = "Exclude employee"; 
    /// <summary>
    /// Options for showing all filtered elements on the Vacations page 
    /// </summary>
    public readonly static string FindFilterOptionsShowAllFilteredVacations = "Find all filtered vacations"; 
    /// <summary>
    /// Options for showing only intersections on the Vacations page 
    /// </summary>
    public readonly static string FindFilterOptionsShowIntersections = "Show intersections"; 
    /// <summary>
    /// Options for excluding intersections on the Vacations page 
    /// </summary>
    public readonly static string FindFilterOptionsExcludeIntersections = "Exclude intersections"; 
    #endregion  // Filter options

    #region Public methods 
    /// <summary>
    /// Generates an info message about filter options 
    /// </summary>
    public static string GetFilterOptionsString(string fullName = "", string ageMin = "", string ageMax = "", string gender = "", string jobTitle = "", string department = "")
    {
        // If no filters applied 
        if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(ageMin) 
            && string.IsNullOrEmpty(ageMax) && string.IsNullOrEmpty(gender)
            && string.IsNullOrEmpty(jobTitle) && string.IsNullOrEmpty(department))
        {
            return NoFiltersApplied; 
        }

        // Create a string about a filter
        string result = string.Empty; 
        if (!string.IsNullOrEmpty(fullName))
            result += "FullName: " + fullName; 
        if (!string.IsNullOrEmpty(ageMin) || !string.IsNullOrEmpty(ageMax))
        {
            if (!string.IsNullOrEmpty(result))
                result += ", "; 
            string fromString = (string.IsNullOrEmpty(ageMin) ? "" : (string.IsNullOrEmpty(ageMax) ? "older than " : "from ") + ageMin + " "); 
            string toString = (string.IsNullOrEmpty(ageMax) ? "" : (string.IsNullOrEmpty(ageMin) ? "younger than " : "to ") + ageMax); 
            result += "age: " + fromString + toString; 
        }
        if (!string.IsNullOrEmpty(gender))
        {
            if (!string.IsNullOrEmpty(result))
                result += ", "; 
            result += "gender: " + gender; 
        }
        if (!string.IsNullOrEmpty(jobTitle))
        {
            if (!string.IsNullOrEmpty(result))
                result += ", "; 
            result += "job title: " + jobTitle; 
        }
        if (!string.IsNullOrEmpty(department))
        {
            if (!string.IsNullOrEmpty(result))
                result += ", "; 
            result += "department: " + department; 
        }
        return result;
    }
    #endregion  // Public methods 
}