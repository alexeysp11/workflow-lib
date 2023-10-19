using Cims.WorkflowLib.Models.ErrorHandling;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class SetMsgStatusResponseDTO
    {
        /// <summary>
        /// Message UID.
        /// </summary>
        public string MessageUid { get; set; }

        /// <summary>
        /// Is successful.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Thrown exception.
        /// </summary>
        public WorkflowException WorkflowException { get; set; }
    }
}