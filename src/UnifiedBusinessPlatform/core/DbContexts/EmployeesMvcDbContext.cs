using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Languages;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Core.DbContexts;

public class EmployeesMvcDbContext : DbContext
{
    public EmployeesMvcDbContext(DbContextOptions<EmployeesMvcDbContext> options) : base(options) { }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserAccountGroup> UserAccountGroups { get; set; }
    public DbSet<EmployeeUserAccount> EmployeeUserAccounts { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationItem> OrganizationItems { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Absense> Absenses { get; set; }

    public DbSet<LanguageKey> LanguageKeys { get; set; }
    public DbSet<LanguageKeyValuePair> LanguageKeyValuePairs { get; set; }
    public DbSet<LanguageKeyForm> LanguageKeyForms { get; set; }
}