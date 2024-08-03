using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.DatasetGenerators;

public interface IVacationGenerator
{
    List<Vacation> GenerateVacations(
        Employee employee,
        List<int> vacationIntervals,
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate);
}