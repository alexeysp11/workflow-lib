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
        /// Liker.
        /// </summary>
        public UserAccount Liker { get; set; }
        
        /// <summary>
        /// Likee.
        /// </summary>
        public UserAccount? Likee { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        public MessageWF? MessageWF { get; set; }

        /// <summary>
        /// Post.
        /// </summary>
        public Post? Post { get; set; }
        
        /// <summary>
        /// Like type.
        /// </summary>
        public LikeType LikeType { get; set; }
    }
}