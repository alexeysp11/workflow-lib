using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Comment.
    /// </summary>
    public class Comment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creation author.
        /// </summary>
        public UserAccount CreationAuthor { get; set; }
    }
}