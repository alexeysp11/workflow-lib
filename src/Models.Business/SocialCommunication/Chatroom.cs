using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.SocialCommunication
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
        /// Photo of the user.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Photo URL of the user.
        /// </summary>
        public string PhotoUrl { get; set; }
        
        /// <summary>
        /// Timestamp when a chatroom was created.
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        
        /// <summary>
        /// Timestamp when a chatroom was deleted.
        /// </summary>
        public System.DateTime DateDeleted { get; set; }
    }
}