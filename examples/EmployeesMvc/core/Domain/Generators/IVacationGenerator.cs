using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Generators;

public interface IVacationGenerator
{
    List<Vacation> GenerateVacations(
        Employee employee,
        int[] vacationIntervals,
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate);
}