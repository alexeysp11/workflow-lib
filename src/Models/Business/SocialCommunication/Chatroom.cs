using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Chatroom.
    /// </summary>
    public class Chatroom : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Title of a chatroom.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type of the chatroom.
        /// </summary>
        public ChatroomType Type { get; set; }
        
        /// <summary>
        /// Timestamp when a chatroom was created.
        /// </summary>
        public System.DateTime DateCreated { get; set; }
    }
}