using System.Collections.Generic;
using System.Linq.Expressions;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Repositories;

public interface IUnitOfWork
{
    GenericRepository<Employee> EmployeeRepository { get; }
    GenericRepository<Absense> VacationRepository { get; }
    FilteredRepository<Employee> EmployeeRepositoryFiltered { get; }
    FilteredRepository<Absense> VacationRepositoryFiltered { get; }

    void InsertVacation(string fullName, System.DateTime start, System.DateTime end);

    List<Employee> GetEmployees(Expression<Func<Employee, bool>> filter = null);
    List<Absense> GetVacations(Expression<Func<Absense, bool>> filter = null);

    string InsertFilteredEmployees(IEnumerable<Employee> entities);
    string InsertFilteredVacations(IEnumerable<Absense> entities);
    IEnumerable<Employee> GetFilteredEmployees(string uid);
    IEnumerable<Absense> GetFilteredVacations(string uid);
}