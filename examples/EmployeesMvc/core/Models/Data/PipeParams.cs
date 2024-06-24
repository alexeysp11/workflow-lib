using System.Collections.Generic; 

namespace WorkflowLib.Examples.EmployeesMvc.Models;

/// <summary>
/// Parameters used for the purpose of generating initial datasets 
/// </summary>
public class PipeParams
{
    /// <summary>
    /// Number of employees in the initial dataset 
    /// </summary>
    public int EmployeeQty { get; }
    /// <summary>
    /// Number of valid vacations, mapped to an employee 
    /// </summary>
    public int[] VacationIntervals { get; }
    
    /// <summary>
    /// Basic constructor 
    /// </summary>
    public PipeParams(int employeeQty, int[] vacationIntervals)
    {
        EmployeeQty = employeeQty; 
        VacationIntervals = vacationIntervals; 
    }
}