namespace WorkflowLib.Examples.EmployeesMvc.Models;

public interface IVacationGenerator
{
    List<Vacation> GenerateVacations(
        Employee employee, 
        int[] vacationIntervals, 
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate); 
}