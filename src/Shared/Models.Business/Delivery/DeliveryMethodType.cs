using System.ComponentModel.DataAnnotations;

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