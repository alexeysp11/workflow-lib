namespace WorkflowLib.Examples.EmployeesMvc.Helpers;

/// <summary>
/// Helper for storing commonly used config values 
/// </summary>
public static class ConfigHelper
{
    /// <summary>
    /// Interval for deleting filtered datasets 
    /// </summary>
    public readonly static int DbSetCollectorInterval = 20000; 

    /// <summary>
    /// Number of generated employees 
    /// </summary>
    public readonly static int EmployeeQty = 100; 
    /// <summary>
    /// Specifed pattern of vacation intervals 
    /// </summary>
    public readonly static int[] VacationIntervals = { 14, 7, 7 }; 
    /// <summary>
    /// Number of elements generated inside the collection of vacations 
    /// </summary>
    public static int VacationQty 
    {
        get 
        {
            return EmployeeQty * VacationIntervals.Length; 
        }
    } 

    /// <summary>
    /// Maximum age of a generated employee 
    /// </summary>
    public readonly static int EmployeeMaxAge = 70; 
    /// <summary>
    /// Manimum age of a generated employee 
    /// </summary>
    public readonly static int EmployeeMinAge = 18; 

    /// <summary>
    /// Length of a part of a employee's fullname
    /// </summary>
    public readonly static int EmployeeFioLength = 10; 
    /// <summary>
    /// Number of parts that the fullname consists of 
    /// </summary>
    public readonly static int EmployeeFioWordsNumber = 3; 
}