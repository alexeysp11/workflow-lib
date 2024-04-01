using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Order status.
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