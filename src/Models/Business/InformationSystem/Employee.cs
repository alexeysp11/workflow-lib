using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Customers;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
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
        public string Description { get; set; }
        
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
        public string ICQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime BirthDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EmployDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Company> Companies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<OrganizationItem> OrganizationItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReplacementMode ReplacementMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthProviderType AuthProviderType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Locale { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}