using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.SocialCommunication
{
    /// <summary>
    /// Like.
    /// </summary>
    public class Like : WfBusinessEntity, IWfBusinessEntity
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