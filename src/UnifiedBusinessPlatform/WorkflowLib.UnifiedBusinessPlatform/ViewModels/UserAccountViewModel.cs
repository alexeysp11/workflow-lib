using System.ComponentModel.DataAnnotations;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.UnifiedBusinessPlatform.ViewModels;

public class UserAccountViewModel
{
    [Key]
    public long UserAccountId { get; set; }

    public EmployeeUserAccount EmployeeUserAccount { get; set; }

    public IEnumerable<UserAccountGroup> UserAccountGroups { get; set; }
}