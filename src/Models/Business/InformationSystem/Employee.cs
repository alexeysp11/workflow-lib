using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    public class Employee
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
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorkPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<OrganizationItem> OrganizationItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReplacementMode ReplacementMode { get; set; }
    }
}