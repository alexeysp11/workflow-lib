using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Channel in a chat app.
    /// </summary>
    public class Channel : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Title of a channel.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Photo of a channel.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Photo URL of a channel.
        /// </summary>
        public string PhotoUrl { get; set; }
        
        /// <summary>
        /// Timestamp when a channel was created.
        /// </summary>
        public System.DateTime DateCreated { get; set; }
    }
}