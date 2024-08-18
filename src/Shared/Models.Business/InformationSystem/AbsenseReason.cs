using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Reason of the absence.
    /// </summary>
    public enum AbsenseReason
    {
        [Display(Name = "Illness")]
        ChronicIllness,

        [Display(Name = "Acute illness")]
        AcuteIllness,

        [Display(Name = "Chronic illness")]
        ChronicIllness,

        [Display(Name = "Skipping")]
        Skipping,

        [Display(Name = "Family emergency")]
        FamilyEmergency,

        [Display(Name = "Routine dental appointment")]
        RoutineDentalAppt,

        [Display(Name = "Preventative medical appointment")]
        PreventativeMedicalAppt,

        [Display(Name = "Travel")]
        Travel,

        [Display(Name = "Business trip")]
        BusinessTrip,

        [Display(Name = "Suspension")]
        Suspension,

        [Display(Name = "Family responsibility")]
        FamilyResponsibility
    }
}