using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    public enum EmployeeBenefitType
    {
        [Display(Name = "Child Care")]
        ChildCare,

        [Display(Name = "Health Insurance")]
        HealthInsurance,

        [Display(Name = "Dental Insurance")]
        DentalInsurance,

        [Display(Name = "Life Insurance")]
        LifeInsurance,

        [Display(Name = "Retirement Plan")]
        RetirementPlan,

        [Display(Name = "Vision Care")]
        VisionCare,

        [Display(Name = "Fitness")]
        Fitness,

        [Display(Name = "Paid Vacation Leave")]
        PaidVacationLeave,

        [Display(Name = "Personal Leave")]
        PersonalLeave,

        [Display(Name = "Sick Leave")]
        SickLeave
    }
}