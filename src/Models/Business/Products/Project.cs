using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class Project
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
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Location { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContractId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Company Company { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ActualEndDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int GuaranteePeriodInMonths { get; private set; }        

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Manager { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Employee> Employees { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contract Contract { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Risk> Risks { get; private set; }
    }
}