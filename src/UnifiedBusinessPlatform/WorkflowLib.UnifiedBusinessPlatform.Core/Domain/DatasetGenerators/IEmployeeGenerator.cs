using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Domain.DatasetGenerators;

public interface IEmployeeGenerator
{
    List<Employee> GenerateEmployees(
        int count, 
        System.Func<System.DateTime, System.DateTime, System.DateTime> generateDate);
}