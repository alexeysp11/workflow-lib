namespace WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;

/// <summary>
/// Temporary data settings.
/// </summary>
public class TempDataSettings
{
    /// <summary>
    /// Stores UID of initial dataset of employees.
    /// </summary>
    public string EmployeesUid { get; set; }
    
    /// <summary>
    /// Stores UID of initial dataset of vacations.
    /// </summary>
    public string VacationsUid { get; set; }
    
    /// <summary>
    /// Stores filter info on the Employees page.
    /// </summary>
    public string FilterInfoEmployees { get; set; }
    
    /// <summary>
    /// Stores filter info on the Vacations page.
    /// </summary>
    public string FilterInfoVacations { get; set; }
    
    /// <summary>
    /// Stores filter info applied for a "current empolyee" on the Vacations page.
    /// </summary>
    public string EmployeeInfoVacations { get; set; }
    
    /// <summary>
    /// Stores filter options on the Employees page.
    /// </summary>
    public string FilterOptionsEmployees { get; set; }
    
    /// <summary>
    /// Stores filter options on the Vacations page.
    /// </summary>
    public string FilterOptionsVacations { get; set; }
}