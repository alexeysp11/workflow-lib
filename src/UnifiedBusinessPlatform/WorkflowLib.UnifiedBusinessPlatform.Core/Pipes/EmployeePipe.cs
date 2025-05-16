using System.Collections.Generic;
using WorkflowLib.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.UnifiedBusinessPlatform.Core.Models.Pipes;
using WorkflowLib.UnifiedBusinessPlatform.Core.Domain.DatasetGenerators;

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Pipes;

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