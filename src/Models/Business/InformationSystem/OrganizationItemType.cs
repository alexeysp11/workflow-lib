using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
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