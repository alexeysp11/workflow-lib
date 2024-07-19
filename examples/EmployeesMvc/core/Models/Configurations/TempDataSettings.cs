namespace WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;

/// <summary>
/// Temporary data settings.
/// </summary>
public class TempDataSettings
{
    /// <summary>
    /// Name of a variable for storing UID of initial dataset of employees.
    /// </summary>
    public string EmployeesUidStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing UID of initial dataset of vacations.
    /// </summary>
    public string VacationsUidStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing filter info on the Employees page.
    /// </summary>
    public string FilterInfoEmployeesStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing filter info on the Vacations page.
    /// </summary>
    public string FilterInfoVacationsStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing filter info applied for a "current empolyee" on the Vacations page.
    /// </summary>
    public string EmployeeInfoVacationsStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing filter options on the Employees page.
    /// </summary>
    public string FilterOptionsEmployeesStr { get; set; }
    
    /// <summary>
    /// Name of a variable for storing filter options on the Vacations page.
    /// </summary>
    public string FilterOptionsVacationsStr { get; set; }
}