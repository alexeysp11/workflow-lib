using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Channel/User.
    /// </summary>
    public class ChannelUser : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Channel ID.
        /// </summary>
        public long ChannelId { get; set; }
        
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