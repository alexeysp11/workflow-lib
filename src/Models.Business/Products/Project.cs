using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.RiskManagement;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Project.
    /// </summary>
    public class Project : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
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
        public Contract? Contract { get; set; }

        /// <summary>
        /// Location of the project.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Customer.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// Guarantee period in months.
        /// </summary>
        public int GuaranteePeriodInMonths { get; set; }        

        /// <summary>
        /// Project manager.
        /// </summary>
        public Employee? Manager { get; set; }
        
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

        /// <summary>
        /// Actual start date.
        /// </summary>
        public System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        public System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? DateEndExpected { get; set; }
    }
}