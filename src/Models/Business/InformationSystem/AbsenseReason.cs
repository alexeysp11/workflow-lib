using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public enum AbsenseReason
    {
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

        [Display(Name = "Suspension")]
        Suspension,

        [Display(Name = "Family responsibility")]
        FamilyResponsibility
    }
}