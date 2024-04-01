using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Employment termination.
    /// </summary>
    public enum EmploymentTerminationReason
    {
        [Display(Name = "Poor Quality Of Work")]
        PoorQualityOfWork,

        [Display(Name = "Interpersonal Conflicts")]
        InterpersonalConflicts,

        [Display(Name = "Medical Reasons")]
        MedicalReasons,

        [Display(Name = "Difficult Work Schedule/Environment")]
        DifficultWorkScheduleEnvironment,

        [Display(Name = "Difficult Work Schedule/Environment")]
        JobDissatisfaction,

        [Display(Name = "Mental Illness")]
        MentalIllness,

        [Display(Name = "Performance")]
        Performance,

        [Display(Name = "Dependability")]
        Dependability,

        [Display(Name = "Transportation Issue")]
        TransportationIssue,

        [Display(Name = "Begin A New Job")]
        BeginNewJob,

        [Display(Name = "Family Issues")]
        FamilyIssues,

        [Display(Name = "Low Salary")]
        LowSalary,

        [Display(Name = "Fear")]
        Fear,

        [Display(Name = "Lack Supervision")]
        LackSupervision,

        [Display(Name = "Substance Abuse")]
        SubstanceAbuse,

        [Display(Name = "Mutual Agreement")]
        MutualAgreement,

        [Display(Name = "Layoff")]
        Layoff,

        [Display(Name = "Furlough")]
        Furlough,

        [Display(Name = "Job Elimination")]
        JobElimination,

        [Display(Name = "Reduction In Force")]
        ReductionInForce,

        [Display(Name = "Retirement")]
        Retirement,

        [Display(Name = "Lockout")]
        Lockout,

        [Display(Name = "Expired Employment Contract")]
        ExpiredEmploymentContract,

        [Display(Name = "End Of Seasonal Employment")]
        EndOfSeasonalEmployment,

        [Display(Name = "Military Call-Up")]
        MilitaryCallUp,

        [Display(Name = "Job Abondonment")]
        JobAbondonment,

        [Display(Name = "Employee Initiated Strike")]
        EmployeeInitiatedStrike,

        [Display(Name = "Other Reasons")]
        OtherReasons
    }
}