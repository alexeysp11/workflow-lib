using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.SocialCommunication
{
    /// <summary>
    /// User/Friend.
    /// </summary>
    public class Friendship : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Requester ID.
        /// </summary>
        public long RequesterId { get; set; }
        
        /// <summary>
        /// Addressee ID.
        /// </summary>
        public long AddresseeId { get; set; }
        
        /// <summary>
        /// Is the friend request is accepted.
        /// </summary>
        public bool IsAccepted { get; set; }

        /// <summary>
        /// Friendship status.
        /// </summary>
        public FriendshipStatus FriendshipStatus { get; set; }

        /// <summary>
        /// Status changes.
        /// </summary>
        public ICollection<FriendshipChange> StatusChanges { get; set; }
    }
}