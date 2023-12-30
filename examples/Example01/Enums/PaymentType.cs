using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Example01.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum PaymentType
    {
        [Display(Name = "Card")]
        Card,

        [Display(Name = "QR code")]
        QrCode
    }
}