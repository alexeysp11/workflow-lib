using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Reason of the absence.
    /// </summary>
    public enum AbsenseReason
    {
        [Display(Name = "Skipping")]
        Skipping,

        [Display(Name = "Unpaid time off")]
        UnpaidTimeOff,

        [Display(Name = "Paid time off")]
        PaidTimeOff,

        [Display(Name = "Annual leave")]
        AnnualLeave,

        [Display(Name = "Family and medical leave")]
        FamilyMedicalLeave,

        [Display(Name = "Disability leave")]
        DisabilityLeave,

        [Display(Name = "Sabbatical")]
        Sabbatical,

        [Display(Name = "Community service")]
        CommunityService,

        [Display(Name = "Military service")]
        MilitaryService,

        [Display(Name = "Travel")]
        Travel,

        [Display(Name = "Business trip")]
        BusinessTrip,

        [Display(Name = "Suspension")]
        Suspension,

        [Display(Name = "Personal leave")]
        PersonalLeave,

        [Display(Name = "Bereavement leave")]
        BereavementLeave,

        [Display(Name = "Jury duty")]
        JuryDuty,

        [Display(Name = "Health issues")]
        HealthIssues,

        [Display(Name = "Childcare leave")]
        ChildcareLeave,

        [Display(Name = "Family responsibility")]
        FamilyResponsibility,

        [Display(Name = "Vacation")]
        Vacation,

        [Display(Name = "Emergency leave")]
        EmergencyLeave,

        [Display(Name = "Study leave")]
        StudyLeave
    }
}