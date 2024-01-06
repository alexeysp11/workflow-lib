using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Example01.Enums
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