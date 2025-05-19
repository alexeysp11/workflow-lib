using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.SocialCommunication
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