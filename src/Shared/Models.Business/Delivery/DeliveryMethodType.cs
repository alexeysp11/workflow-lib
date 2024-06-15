using System.ComponentModel.DataAnnotations;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    /// <summary>
    /// Delivery method type.
    /// </summary>
    public enum DeliveryMethodType
    {
        [Display(Name = "On foot")]
        OnFoot,

        [Display(Name = "Electric scooter")]
        ElectricScooter,
        
        [Display(Name = "Car")]
        Car
    }
}