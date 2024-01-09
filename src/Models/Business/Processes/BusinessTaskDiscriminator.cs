using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Business task discriminator.
    /// </summary>
    public enum BusinessTaskDiscriminator
    {
        [Display(Name = "RequestStore2Wh")]
        RequestStore2Wh,

        [Display(Name = "ConfirmStore2Wh")]
        ConfirmStore2Wh,

        [Display(Name = "Other")]
        Other
    }
}