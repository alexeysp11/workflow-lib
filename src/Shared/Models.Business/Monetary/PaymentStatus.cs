using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Business.Monetary
{
    /// <summary>
    /// Payment status.
    /// </summary>
    public enum PaymentStatus
    {
        [Display(Name = "Requested")]
        Requested,

        [Display(Name = "In process")]
        InProcess,

        [Display(Name = "Processed")]
        Processed,
        
        [Display(Name = "Confirmed")]
        Confirmed,

        [Display(Name = "Cancelled")]
        Cancelled,

        [Display(Name = "Failed")]
        Failed,

        [Display(Name = "Rejected")]
        Rejected,

        [Display(Name = "Not accepted")]
        NotAccepted,

        [Display(Name = "Finished")]
        Finished
    }
}