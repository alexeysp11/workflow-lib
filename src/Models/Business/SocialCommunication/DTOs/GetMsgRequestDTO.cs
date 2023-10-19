using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class GetMsgRequestDTO
    {
        /// <summary>
        /// Recipient UID.
        /// </summary>
        public string RecipientUid { get; set; }

        /// <summary>
        /// Chatroom UID.
        /// </summary>
        public string ChatroomUid { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public GetMsgType Type { get; set; }

        /// <summary>
        /// Period.
        /// </summary>
        public Period Period { get; set; }
    }
}