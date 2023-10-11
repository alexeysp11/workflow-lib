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
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContractId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ActualEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int GuaranteePeriodInMonths { get; set; }        

        /// <summary>
        /// 
        /// </summary>
        public Employee Manager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Contract Contract { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Risk> Risks { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProjectPhase> ProjectPhases { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int CompletePercent { get; set; }
    }
}