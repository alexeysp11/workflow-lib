using System.Collections.Generic;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Pipes;
using WorkflowLib.Examples.EmployeesMvc.Core.Domain.DatasetGenerators;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Pipes;

/// <summary>
/// Pipe component for generating a collection of employees 
/// </summary>
public class EmployeePipe : AbstractPipe
{
    /// <summary>
    /// Constructor of the pipe complonent 
    /// </summary>
    public EmployeePipe(AppSettings appSettings, System.Action<PipeResult> function) : base(appSettings, function)
    {
    }
    
    /// <summary>
    /// Method that implements a generating algorithm 
    /// </summary>
    public override void Handle(PipeResult result)
    {
        IEmployeeGenerator generator = new EmployeeGenerator(_appSettings);
        result.Employees = generator.GenerateEmployees(result.PipeParams.EmployeeQty, base.GenerateDate);
        _function(result);
    }
}