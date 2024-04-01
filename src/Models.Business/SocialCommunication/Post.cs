using System.Collections.Generic;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Post.
    /// </summary>
    public class Post : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Content text.
        /// </summary>
        public string ContentText { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}