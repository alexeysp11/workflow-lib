namespace WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;

/// <summary>
/// Class for storing commonly used config values.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Interval for deleting filtered datasets.
    /// </summary>
    public int DbSetCollectorInterval { get; set; }

    /// <summary>
    /// Number of generated employees.
    /// </summary>
    public int EmployeeQty { get; set; }
    
    /// <summary>
    /// Specifed pattern of vacation intervals.
    /// </summary>
    public int[] VacationIntervals { get; set; }
    
    /// <summary>
    /// Number of elements generated inside the collection of vacations.
    /// </summary>
    public int VacationQty
    {
        get 
        {
            return EmployeeQty * VacationIntervals.Length;
        }
    } 

    /// <summary>
    /// Maximum age of a generated employee.
    /// </summary>
    public int EmployeeMaxAge { get; set; }
    
    /// <summary>
    /// Manimum age of a generated employee.
    /// </summary>
    public int EmployeeMinAge { get; set; }

    /// <summary>
    /// Length of a part of a employee's fullname.
    /// </summary>
    public int EmployeeFioLength { get; set; }
    
    /// <summary>
    /// Number of parts that the fullname consists of.
    /// </summary>
    public int EmployeeFioWordsNumber { get; set; }
}