using System.Collections.Generic;
using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

/// <summary>
/// Implementation of the Unit of work pattern.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private AppSettings _appSettings;

    public GenericRepository<Employee> EmployeeRepository { get; }
    public GenericRepository<Vacation> VacationRepository { get; }
    public FilteredRepository<Employee> EmployeeRepositoryFiltered { get; }
    public FilteredRepository<Vacation> VacationRepositoryFiltered { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public UnitOfWork(AppSettings appSettings)
    {
        _appSettings = appSettings;

        EmployeeRepository = new GenericRepository<Employee>();
        VacationRepository = new GenericRepository<Vacation>();
        EmployeeRepositoryFiltered = new FilteredRepository<Employee>(_appSettings);
        VacationRepositoryFiltered = new FilteredRepository<Vacation>(_appSettings);
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
}