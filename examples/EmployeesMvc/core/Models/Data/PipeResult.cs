using System.Collections.Generic; 

namespace WorkflowLib.Examples.EmployeesMvc.Models;

/// <summary>
/// Represents all the generated collections 
/// </summary>
public class PipeResult
{
    /// <summary>
    /// Parameters used for the purpose of generating initial datasets 
    /// </summary>
    public PipeParams PipeParams { get; }
    /// <summary>
    /// Generated dataset of employees 
    /// </summary>
    public List<Employee> Employees { get; set; }
    /// <summary>
    /// Generated dataset of vacations 
    /// </summary>
    public List<Vacation> Vacations { get; set; }
    
    /// <summary>
    /// Basic constructor 
    /// </summary>
    public PipeResult(PipeParams pipeParams)
    {
        PipeParams = pipeParams; 
        Employees = new List<Employee>(); 
        Vacations = new List<Vacation>(); 
    }
}