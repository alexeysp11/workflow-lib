using System.ComponentModel.DataAnnotations;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Delivery
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