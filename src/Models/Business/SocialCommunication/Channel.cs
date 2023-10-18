namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Channel in a chat app.
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// ID of a channel.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// UID of a channel.
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// Description of a message.
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Title of a message.
        /// </summary>
        public string? Title { get; set; }
        
        /// <summary>
        /// Timestamp when a message was created.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}