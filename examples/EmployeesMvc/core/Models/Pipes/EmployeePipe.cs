using System.Collections.Generic;
using WorkflowLib.Examples.EmployeesMvc.Helpers;

namespace WorkflowLib.Examples.EmployeesMvc.Models;

/// <summary>
/// Pipe component for generating a collection of employees 
/// </summary>
public class EmployeePipe : AbstractPipe
{
    /// <summary>
    /// Constructor of the pipe complonent 
    /// </summary>
    public EmployeePipe(System.Action<PipeResult> function) : base(function)
    {
    }
    /// <summary>
    /// Method that implements a generating algorithm 
    /// </summary>
    public override void Handle(PipeResult result)
    {
        IEmployeeGenerator generator = new EmployeeGenerator();
        result.Employees = generator.GenerateEmployees(result.PipeParams.EmployeeQty, base.GenerateDate);
        _function(result);
    }
}