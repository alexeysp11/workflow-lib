using System.Collections.Generic;
using VelocipedeUtils.Shared.Models.Business;

namespace VelocipedeUtils.Shared.Models.Business.SocialCommunication
{
    /// <summary>
    /// Post.
    /// </summary>
    public class Post : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Content text.
        /// </summary>
        public string? ContentText { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}