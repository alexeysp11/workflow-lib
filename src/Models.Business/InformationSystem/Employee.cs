using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Employee.
    /// </summary>
    public class Employee : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// First name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of the employee.
        /// </summary>
        public string? MiddleName { get; set; }
        
        /// <summary>
        /// Last name of the employee.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Full name of the employee.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Mobile phone of the employee.
        /// </summary>
        public string? MobilePhone { get; set; }

        /// <summary>
        /// Work phone of the employee.
        /// </summary>
        public string? WorkPhone { get; set; }

        /// <summary>
        /// Skype username of the employee.
        /// </summary>
        public string? Skype { get; set; }

        /// <summary>
        /// ICQ of the employee.
        /// </summary>
        public string? ICQ { get; set; }

        /// <summary>
        /// Bith date of the employee.
        /// </summary>
        public System.DateTime BirthDate { get; set; }

        /// <summary>
        /// Employment date.
        /// </summary>
        public System.DateTime EmployDate { get; set; }

        /// <summary>
        /// User accounts related to the employee.
        /// </summary>
        public ICollection<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// Companies related to the employee.
        /// </summary>
        public ICollection<Company> Companies { get; set; }

        /// <summary>
        /// Replacement mode.
        /// </summary>
        public ReplacementMode ReplacementMode { get; set; }

        /// <summary>
        /// Authentication provider type.
        /// </summary>
        public AuthProviderType AuthProviderType { get; set; }
        
        /// <summary>
        /// Locale.
        /// </summary>
        public string? Locale { get; set; }
        
        /// <summary>
        /// Skills of the employee.
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
                
        /// <summary>
        /// Contracts.
        /// </summary>
        public ICollection<Contract> Contracts { get; private set; }
    }
}