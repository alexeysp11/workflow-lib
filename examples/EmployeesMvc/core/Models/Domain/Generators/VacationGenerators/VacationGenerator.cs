namespace WorkflowLib.Examples.EmployeesMvc.Models;

/// <summary>
/// Randomly generates a set of vacations 
/// </summary>
public class VacationGenerator : IVacationGenerator
{
    /// <summary>
    /// Generates specified number of employees mapped to every employee 
    /// </summary>
    public List<Vacation> GenerateVacations(
        Employee employee, 
        int[] vacationIntervals, 
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate)
    {
        var result = new List<Vacation>(); 
        var year = System.DateTime.Now.Year; 
        foreach (var interval in vacationIntervals)
        {
            System.DateTime start; 
            System.DateTime end; 
            do 
            {
                start = generateDate(new System.DateTime(year, 1, 1), new System.DateTime(year, 12, 31)); 
                end = start.AddDays(interval); 
            }
            while (end.Year != year); 
            var vacation = new Vacation 
            {
                BeginDate = start, 
                EndDate = end, 
                Employee = employee
            };
            result.Add(vacation); 
        }
        return result; 
    }
}