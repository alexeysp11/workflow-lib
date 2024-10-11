using System.Linq;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models.Pipes;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Pipes;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Repositories;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Domain.DatasetGenerators;

/// <summary>
/// Class for initializing datasets.
/// </summary>
public class DatasetGenerator
{
    private AppSettings _appSettings;
    private IUnitOfWork _unitOfWork;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public DatasetGenerator(
        AppSettings appSettings,
        IUnitOfWork unitOfWork)
    {
        _appSettings = appSettings;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Initializes datasets.
    /// </summary>
    public void Initialize()
    {
        var pipeParams = new PipeParams(_appSettings.EmployeeQty, _appSettings.VacationIntervals);
        var result = new PipeResult(pipeParams);
        var generatingPipe = new PipeBuilder(_appSettings, InsertIntoRepositories)
            .AddGenerating(typeof(EmployeePipe))
            .AddGenerating(typeof(VacationPipe))
            .Build();
        generatingPipe(result);
    }

    /// <summary>
    /// Inserts initial datasets into the repositories.
    /// </summary>
    private void InsertIntoRepositories(PipeResult result)
    {
        foreach (var employee in result.Employees)
        {
            _unitOfWork.EmployeeRepository.Insert(employee);
        }
        foreach (var vacation in result.Vacations)
        {
            _unitOfWork.VacationRepository.Insert(vacation);
        }

        System.Console.WriteLine("Data added into the repositories");
    }
}