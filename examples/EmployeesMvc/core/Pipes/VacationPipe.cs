using System.Linq;
using System.Collections.Generic;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Pipes;
using WorkflowLib.Examples.EmployeesMvc.Core.Domain.Generators;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Pipes;

/// <summary>
/// Pipe component for generating a collection of employees.
/// </summary>
public class VacationPipe : AbstractPipe
{
    /// <summary>
    /// Constructor of the pipe complonent.
    /// </summary>
    public VacationPipe(System.Action<PipeResult> function) : base(function)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Vacation> GenerateVacations(List<Employee> employees, int[] vacationIntervals)
    {
        var vacations = new List<Vacation>();
        foreach (var employee in employees)
        {
            IVacationGenerator generator = new VacationGenerator();
            var employeeVacations = generator.GenerateVacations(employee, vacationIntervals, GenerateDate);
            vacations.AddRange(employeeVacations);
        }
        return vacations;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void AddVacation(PipeResult result, string fullName, System.DateTime begin, System.DateTime end)
    {
        // Get available slots for the employee.
        var slots = result.Vacations
            .Where(x => x.Employee.FullName == fullName 
                        && x.BeginDate <= begin 
                        && x.EndDate > begin 
                        && x.BeginDate < end 
                        && x.EndDate >= end).ToList();
        if (slots.Count == 0)
            return;

        // Generate for the employee.
        var employee = result.Employees.FirstOrDefault(x => x.FullName == fullName);
        var vacation = new Vacation 
        {
            BeginDate = begin, 
            EndDate = end, 
            Employee = employee
        };
        result.Vacations.Add(vacation);
    }
    
    /// <summary>
    /// Method that implements a generating algorithm.
    /// </summary>
    public override void Handle(PipeResult result)
    {
        result.Vacations = GenerateVacations(result.Employees, result.PipeParams.VacationIntervals);
        _function(result);
    }
}