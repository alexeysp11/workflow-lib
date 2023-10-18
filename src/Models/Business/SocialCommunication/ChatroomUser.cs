using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Chatroom/User.
    /// </summary>
    public class ChatroomUser : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Chatroom ID.
        /// </summary>
        public long ChatroomId { get; set; }

        /// <summary>
        /// Title of a chatroom, that is displayed for the user specifically.
        /// </summary>
        public string ChatroomTitle { get; set; }
        
        /// <summary>
        /// User ID.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// Is the user admin of the channel.
        /// </summary>
        public bool IsAdmin { get; set; }
        
        /// <summary>
        /// Date created.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}