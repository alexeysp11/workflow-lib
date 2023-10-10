using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is it a group by default for the new user
        /// </summary>
        /// <summary>
        /// 
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
        public List<OrganizationItem> OrganizationItems { get; set; }
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