using Cims.WorkflowLib.Models.Business.SocialCommunication;
using Cims.WorkflowLib.Models.ErrorHandling;

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

        /// <summary>
        /// Thrown exception.
        /// </summary>
        public WorkflowException WorkflowException { get; set; }
    }
}