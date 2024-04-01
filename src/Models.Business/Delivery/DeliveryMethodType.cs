using System.ComponentModel.DataAnnotations;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Delivery
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