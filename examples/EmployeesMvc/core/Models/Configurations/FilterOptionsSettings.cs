namespace WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;

/// <summary>
/// Filter options settings.
/// </summary>
public class FilterOptionsSettings
{
    /// <summary>
    /// Message displayed when no filters applied.
    /// </summary>
    public string NoFiltersApplied { get; set; }
    
    /// <summary>
    /// Options for showing filtered elements on the Employees page.
    /// </summary>
    public string FindFilterOptionsShowEmployee { get; set; }
    
    /// <summary>
    /// Options for excluding filtered elements on the Employees page.
    /// </summary>
    public string FindFilterOptionsExcludeEmployee { get; set; }
    
    /// <summary>
    /// Options for showing all filtered elements on the Vacations page.
    /// </summary>
    public string FindFilterOptionsShowAllFilteredVacations { get; set; }
    
    /// <summary>
    /// Options for showing only intersections on the Vacations page.
    /// </summary>
    public string FindFilterOptionsShowIntersections { get; set; }
    
    /// <summary>
    /// Options for excluding intersections on the Vacations page.
    /// </summary>
    public string FindFilterOptionsExcludeIntersections { get; set; }

    /// <summary>
    /// Generates an info message about filter options.
    /// </summary>
    public string GetFilterOptionsString(string fullName = "", string ageMin = "", string ageMax = "", string gender = "", string jobTitle = "", string department = "")
    {
        // If no filters applied.
        if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(ageMin) 
            && string.IsNullOrEmpty(ageMax) && string.IsNullOrEmpty(gender)
            && string.IsNullOrEmpty(jobTitle) && string.IsNullOrEmpty(department))
        {
            return NoFiltersApplied;
        }

        // Create a string about a filter.
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
}