using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Example01.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum OrderStatus
    {
        [Display(Name = "Requested")]
        Requested,

        [Display(Name = "In process")]
        InProcess,

        [Display(Name = "Ready to deliver")]
        ReadyToDeliver,

        [Display(Name = "Delivered")]
        Delivered,

        [Display(Name = "Finished")]
        Finished
    }
}