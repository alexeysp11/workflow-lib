using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.SocialCommunication
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
    }
}