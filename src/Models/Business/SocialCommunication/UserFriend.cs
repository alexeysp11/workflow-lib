using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// User/Friend.
    /// </summary>
    public class UserFriend : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// User ID.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// Friend user ID.
        /// </summary>
        public long FriendUserId { get; set; }
        
        /// <summary>
        /// Is the friend request is accepted.
        /// </summary>
        public bool IsAccepted { get; set; }
        
        /// <summary>
        /// Date when the user sent the request.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}