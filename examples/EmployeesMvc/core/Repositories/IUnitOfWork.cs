using System.Collections.Generic;
using System.Linq.Expressions;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.HumanResources;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

public interface IUnitOfWork
{
    GenericRepository<Employee> EmployeeRepository { get; }
    GenericRepository<Vacation> VacationRepository { get; }
    FilteredRepository<Employee> EmployeeRepositoryFiltered { get; }
    FilteredRepository<Vacation> VacationRepositoryFiltered { get; }

    void InsertVacation(string fullName, System.DateTime start, System.DateTime end);

    List<Employee> GetEmployees(Expression<Func<Employee, bool>> filter = null);
    List<Vacation> GetVacations(Expression<Func<Vacation, bool>> filter = null);

    string InsertFilteredEmployees(IEnumerable<Employee> entities);
    string InsertFilteredVacations(IEnumerable<Vacation> entities);
    IEnumerable<Employee> GetFilteredEmployees(string uid);
    IEnumerable<Vacation> GetFilteredVacations(string uid);
}