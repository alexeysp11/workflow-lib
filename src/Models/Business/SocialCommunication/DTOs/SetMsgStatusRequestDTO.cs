using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class SetMsgStatusRequestDTO
    {
        /// <summary>
        /// Message UID.
        /// </summary>
        public string MessageUid { get; set; }

        /// <summary>
        /// Sender UID.
        /// </summary>
        public string SenderUid { get; set; }

        /// <summary>
        /// Recipient UID.
        /// </summary>
        public string RecipientUid { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public SetMsgStatus Status { get; set; }
    }
}