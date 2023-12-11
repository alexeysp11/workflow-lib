using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Organization item.
    /// </summary>
    public class OrganizationItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Type of the organization item.
        /// </summary>
        public OrganizationItemType ItemType { get; set; }
        
        /// <summary>
        /// Boolean variable that shows if the organization item is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Boolean variable that shows if the organization item could not be deleted automatically.
        /// </summary>
        public bool HardDelete { get; set; }
        
        /// <summary>
        /// Parent organization item.
        /// </summary>
        public OrganizationItem ParentItem { get; set; }
        
        /// <summary>
        /// Collection of child organization items.
        /// </summary>
        public ICollection<OrganizationItem> SubItems { get; set; }
        
        /// <summary>
        /// User that is related to the organization item (when the organization item is a job position).
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// Collection of users that are related to the organization item (when the organization item is department, group of users etc).
        /// </summary>
        public ICollection<UserAccount> Users { get; set; }

        /// <summary>
        /// Address of the organization item.
        /// </summary>
        public Address Address { get; set; }
    }
}