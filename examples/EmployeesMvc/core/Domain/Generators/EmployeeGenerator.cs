using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;
using WorkflowLib.Examples.EmployeesMvc.Helpers;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Domain.Generators;

/// <summary>
/// Randomly generates a set of employees
/// </summary>
public class EmployeeGenerator : IEmployeeGenerator
{
    /// <summary>
    /// Generates specified number of employees 
    /// </summary>
    public List<Employee> GenerateEmployees(
        int count, 
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate)
    {
        var employees = new List<Employee>();
        for (int i = 0; i < count; i++)
        {
            var employee = new Employee 
            {
                FullName = GenerateFullName(),
                Gender = GenerateEnum<Gender>(),
                JobTitle = GenerateEnum<JobTitle>(),
                Department = GenerateEnum<Department>(),
                BirthDate = GenerateBirthDate(generateDate)
            };
            employees.Add(employee);
        }
        return employees;
    }
    
    /// <summary>
    /// Generate a fullname of the employee 
    /// </summary>
    private string GenerateFullName()
    {
        var finalString = string.Empty;
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // var stringChars = new char[AppSettings.EmployeeFullNameLength];
        var stringChars = new char[10];
        var random = new Random();
        // for (int i = 0; i < AppSettings.EmployeeFullNameWordsNumber; i++)
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < stringChars.Length; j++)
                stringChars[j] = chars[random.Next(chars.Length)];
            var tmpStr = new String(stringChars);
            finalString += tmpStr.First().ToString().ToUpper() + tmpStr.Substring(1).ToLower() + " ";
        }
        return finalString.Last() == ' ' ? finalString.Remove(finalString.Length - 1) : finalString;
    }

    /// <summary>
    /// Generic method for generating the employee's properties, knowing specified typed of enum 
    /// </summary>
    private T GenerateEnum<T>() where T : System.Enum
    {
        var length = System.Enum.GetNames(typeof(T)).Length;
        return (T)(object) new Random().Next(1, length + 1);
    }

    /// <summary>
    /// Generates a bith date of an employee 
    /// </summary>
    private System.DateTime GenerateBirthDate(System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate)
    {
        // System.DateTime start = System.DateTime.Now.AddYears(-AppSettings.EmployeeMaxAge);
        System.DateTime start = System.DateTime.Now.AddYears(-70);
        // System.DateTime end = System.DateTime.Now.AddYears(-AppSettings.EmployeeMinAge);
        System.DateTime end = System.DateTime.Now.AddYears(-18);
        return generateDate(start, end);
    }
}