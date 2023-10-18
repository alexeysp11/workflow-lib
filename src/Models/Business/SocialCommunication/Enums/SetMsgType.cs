using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public enum SetMsgStatus
    {
        [Display(Name = "Read")]
        Read,

        [Display(Name = "Delete For Sender")]
        DeleteForSender,

        [Display(Name = "Delete For Everybody")]
        DeleteForEverybody
    }
}