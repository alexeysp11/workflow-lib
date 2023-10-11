using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    public enum WorkingDayOption
    {
        [Display(Name = "At Work")]
        AtWork = 0,

        [Display(Name = "Holiday")]
        Holiday = 1,

        [Display(Name = "Paid Day Off")]
        PaidDayOff = 2,

        [Display(Name = "Unpaid Day Off")]
        UnpaidDayOff = 3,

        [Display(Name = "Business Trip")]
        BusinessTrip = 4,

        [Display(Name = "Sick Day Off")]
        SickDayOff = 5

    }
}