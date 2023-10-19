using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// send message response DTO.
    /// </summary>
    public class SendMsgResponseDTO
    {
        /// <summary>
        /// Message UID.
        /// </summary>
        public string MessageUid { get; set; }

        /// <summary>
        /// Status of the sending the message.
        /// </summary>
        public SendMsgStatus Status { get; set; }
    }
}