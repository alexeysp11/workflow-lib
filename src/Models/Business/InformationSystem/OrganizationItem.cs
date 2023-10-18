using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public OrganizationItemType ItemType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool HardDelete { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Organization Organization { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public OrganizationItem ParentItem { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<OrganizationItem> SubItems { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserAccount> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }
    }
}