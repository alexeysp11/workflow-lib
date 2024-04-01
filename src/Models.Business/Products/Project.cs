using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Project.
    /// </summary>
    public class Project : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Boolean variable that shows if the project is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Contract ID.
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        /// Contract.
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// Location of the project.
        /// </summary>
        public Address Location { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Start date of the project.
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the project (expected).
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// Actual end date of the project.
        /// </summary>
        public System.DateTime? ActualEndDate { get; set; }

        /// <summary>
        /// Guarantee period in months.
        /// </summary>
        public int GuaranteePeriodInMonths { get; set; }        

        /// <summary>
        /// Project manager.
        /// </summary>
        public Employee Manager { get; set; }
        
        /// <summary>
        /// Risks of the project.
        /// </summary>
        public ICollection<Risk> Risks { get; set; }
        
        /// <summary>
        /// Project phases.
        /// </summary>
        public ICollection<ProjectPhase> ProjectPhases { get; set; }
        
        /// <summary>
        /// Complete percent.
        /// </summary>
        public int CompletePercent { get; set; }
    }
}