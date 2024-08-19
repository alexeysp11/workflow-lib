using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Examples.EmployeesMvc.Core.DbContexts;

public class EmployeesMvcDbContext : DbContext
{
    public EmployeesMvcDbContext(DbContextOptions<EmployeesMvcDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Absense> Absenses { get; set; }
}