using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business
{
    public enum DeliveryMethodType
    {
        [Display(Name = "On Foot")]
        OnFoot,

        [Display(Name = "Electric Scooter")]
        ElectricScooter,
        
        [Display(Name = "Car")]
        Car
    }
}