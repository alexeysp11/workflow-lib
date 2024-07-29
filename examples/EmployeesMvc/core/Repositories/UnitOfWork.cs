using System.Collections.Generic;
using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Pipes;
using WorkflowLib.Examples.EmployeesMvc.Core.Pipes;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

/// <summary>
/// Implementation of the Unit of work pattern.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private GenericRepository<Employee> employeeRepository;
    private GenericRepository<Vacation> vacationRepository;
    private FilteredRepository<Employee> employeeRepositoryFiltered;
    private FilteredRepository<Vacation> vacationRepositoryFiltered;
    private AppSettings _appSettings;

    /// <summary>
    /// Repository of the initial dataset of employees.
    /// </summary>
    public GenericRepository<Employee> EmployeeRepository
    {
        get
        {
            if (this.employeeRepository == null)
            {
                this.employeeRepository = new GenericRepository<Employee>();
            }
            return employeeRepository;
        }
    }

    /// <summary>
    /// Repository of the initial dataset of vacations.
    /// </summary>
    public GenericRepository<Vacation> VacationRepository
    {
        get
        {
            if (this.vacationRepository == null)
            {
                this.vacationRepository = new GenericRepository<Vacation>();
            }
            return vacationRepository;
        }
    }

    /// <summary>
    /// Repository of the filtered dataset of employees.
    /// </summary>
    public FilteredRepository<Employee> EmployeeRepositoryFiltered
    {
        get
        {
            if (this.employeeRepositoryFiltered == null)
            {
                this.employeeRepositoryFiltered = new FilteredRepository<Employee>(_appSettings);
            }
            return employeeRepositoryFiltered;
        }
    }

    /// <summary>
    /// Repository of the filtered dataset of vacations.
    /// </summary>
    public FilteredRepository<Vacation> VacationRepositoryFiltered
    {
        get
        {
            if (this.vacationRepositoryFiltered == null)
            {
                this.vacationRepositoryFiltered = new FilteredRepository<Vacation>(_appSettings);
            }
            return vacationRepositoryFiltered;
        }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public UnitOfWork(AppSettings appSettings)
    {
        _appSettings = appSettings;
        
        var pipeParams = new PipeParams(_appSettings.EmployeeQty, _appSettings.VacationIntervals);
        var result = new PipeResult(pipeParams);
        
        var generatingPipe = new PipeBuilder(_appSettings, InsertIntoRepository)
            .AddGenerating(typeof(EmployeePipe))
            .AddGenerating(typeof(VacationPipe))
            .Build();
        generatingPipe(result);
    }

    /// <summary>
    /// Gets a collection of employees using the specified filter.
    /// </summary>
    public List<Employee> GetEmployees(Expression<Func<Employee, bool>> filter = null)
    {
        return EmployeeRepository.Get(filter: filter).ToList();
    }

    /// <summary>
    /// Gets a collection of vacations using the specified filter.
    /// </summary>
    public List<Vacation> GetVacations(Expression<Func<Vacation, bool>> filter = null)
    {
        return VacationRepository.Get(filter: filter).ToList();
    }

    /// <summary>
    /// Inserts vacation for the specified user.
    /// </summary>
    public void InsertVacation(string fullName, System.DateTime begin, System.DateTime end)
    {
        // Find employee 
        var employees = EmployeeRepository.Get(filter: x => x.FullName == fullName).ToList();
        if (employees.Count == 0) 
            return;
        
        // Check if the vacations overlap.
        var vacations = VacationRepository
            .Get(filter: x => x.Employee.FullName == fullName
                            && (
                                (x.BeginDate <= begin && x.EndDate > begin) 
                                || (x.BeginDate <= end && x.EndDate > end)
                            )).ToList();
        if (vacations.Count == 0)
        {
            VacationRepository.Insert(new Vacation
            {
                BeginDate = begin, 
                EndDate = end,
                Employee = employees.First()
            });
        }
    }
    
    /// <summary>
    /// Saves filtered employees.
    /// </summary>
    public string InsertFilteredEmployees(IEnumerable<Employee> entities)
    {
        return EmployeeRepositoryFiltered.InsertFiltered(entities);
    }

    /// <summary>
    /// Saves filtered vacations.
    /// </summary>
    public string InsertFilteredVacations(IEnumerable<Vacation> entities)
    {
        return VacationRepositoryFiltered.InsertFiltered(entities);
    }

    /// <summary>
    /// Gets filtered employees.
    /// </summary>
    public IEnumerable<Employee> GetFilteredEmployees(string uid)
    {
        return EmployeeRepositoryFiltered.GetFiltered(uid);
    }

    /// <summary>
    /// Gets filtered vacations.
    /// </summary>
    public IEnumerable<Vacation> GetFilteredVacations(string uid)
    {
        return VacationRepositoryFiltered.GetFiltered(uid);
    }
    
    /// <summary>
    /// Inserts initial datasets into the repositories.
    /// </summary>
    private void InsertIntoRepository(PipeResult result)
    {
        foreach (var employee in result.Employees)
        {
            EmployeeRepository.Insert(employee);
        }
        foreach (var vacation in result.Vacations)
        {
            VacationRepository.Insert(vacation);
        }

        System.Console.WriteLine("Data added into the repository");
    }
}
