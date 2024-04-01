using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Like.
    /// </summary>
    public class Like : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Like type.
        /// </summary>
        public LikeType LikeType { get; set; }
        
        /// <summary>
        /// Liker ID.
        /// </summary>
        public long LikerId { get; set; }
        
        /// <summary>
        /// Likee ID.
        /// </summary>
        public long LikeeId { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// Post ID.
        /// </summary>
        public long PostId { get; set; }
        
        /// <summary>
        /// Liker.
        /// </summary>
        public UserAccount Liker { get; set; }
        
        /// <summary>
        /// Likee.
        /// </summary>
        public UserAccount Likee { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        public MessageWF MessageWF { get; set; }

        /// <summary>
        /// Post.
        /// </summary>
        public Post Post { get; set; }
    }
}