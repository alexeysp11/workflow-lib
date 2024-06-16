using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.SocialCommunication
{
    /// <summary>
    /// Comment.
    /// </summary>
    public class Comment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Text.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Creation author.
        /// </summary>
        public UserAccount AuthorCreated { get; set; }
    }
}