using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class UserGroup : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Is it a group by default for the new user
        /// </summary>
        public bool IsGroupByDefault { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount Users { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<OrganizationItem> OrganizationItems { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount CreationAuthor { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreationDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount ChangeAuthor { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime ChangeDate { get; set; }
    }
}