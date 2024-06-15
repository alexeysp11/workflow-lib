using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Type of the organization item.
    /// </summary>
    public enum OrganizationItemType
    {
        [Display(Name = "Department")]
        Department,
        
        [Display(Name = "Job position")]
        JobPosition,
        
        [Display(Name = "Employee group")]
        EmployeeGroup,
        
        [Display(Name = "Nested structure")]
        NestedStructure
    }
}