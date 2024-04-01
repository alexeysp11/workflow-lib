using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// Payment type.
    /// </summary>
    public enum PaymentType
    {
        [Display(Name = "Card")]
        Card,

        [Display(Name = "QR code")]
        QrCode
    }
}