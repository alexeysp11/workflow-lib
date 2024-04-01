using System.Collections.Generic;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// User group.
    /// </summary>
    public class UserGroup : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Is it a group by default for the new user
        /// </summary>
        public bool IsGroupByDefault { get; set; }
        
        /// <summary>
        /// Boolean variable that shows if the user group is system.
        /// </summary>
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// Users of the user group.
        /// </summary>
        public ICollection<UserAccount> Users { get; set; }
        
        /// <summary>
        /// User that created the user group.
        /// </summary>
        public UserAccount CreationAuthor { get; set; }
        
        /// <summary>
        /// Timestamp when the user group was created.
        /// </summary>
        public System.DateTime CreationDate { get; set; }
        
        /// <summary>
        /// User that changed the user group.
        /// </summary>
        public UserAccount ChangeAuthor { get; set; }
        
        /// <summary>
        /// Timestamp when the user group was changed.
        /// </summary>
        public System.DateTime ChangeDate { get; set; }
    }
}