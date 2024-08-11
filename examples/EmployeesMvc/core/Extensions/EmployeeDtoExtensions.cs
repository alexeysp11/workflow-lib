using WorkflowLib.Examples.EmployeesMvc.Core.Dto;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Extensions;

public static class EmployeeDtoExtensions
{
    /// <summary>
    /// Helper method for EmployeeDto to check if all filters are empty.
    /// </summary>
    public static bool IsEmpty(this EmployeeDto employeeDto)
    {
        return string.IsNullOrEmpty(employeeDto.FullName)
            && employeeDto.AgeMin <= 0
            && employeeDto.AgeMax <= 0
            && string.IsNullOrEmpty(employeeDto.Gender)
            && string.IsNullOrEmpty(employeeDto.JobTitle)
            && string.IsNullOrEmpty(employeeDto.Department);
    }
}