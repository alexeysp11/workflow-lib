using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Friendship change.
    /// </summary>
    public class FriendshipChange : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Friendship Friendship { get; set; }

        /// <summary>
        /// Friendship status.
        /// </summary>
        public FriendshipStatus Status { get; set; }
    }
}