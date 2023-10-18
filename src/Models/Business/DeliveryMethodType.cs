using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business
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