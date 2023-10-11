using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.Responsibilities
{
    /// <summary>
    /// 
    /// </summary>
    public enum EmployerResponsibilityType
    {
        [Display(Name = "Management, Supervision, Control")]
        ManagementSupervisionControl,
        
        [Display(Name = "Training and Development")]
        TrainingAndDevelopment,

        [Display(Name = "Safe, Hygienic Workplace")]
        SafeHygienicWorkplace,

        [Display(Name = "Health Benifits")]
        HealthBenifits,

        [Display(Name = "Work-Life Balance")]
        WorkLifeBalance,

        [Display(Name = "Regular Wage and Appraisals")]
        RegularWageAndAppraisals,

        [Display(Name = "Job Security")]
        JobSecurity,

        [Display(Name = "Carrier Growth Opportunity")]
        CarrierGrowthOpportunity
    }
}