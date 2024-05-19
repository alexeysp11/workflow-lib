using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.InformationSystem;
using WorkflowLib.Models.Business.Monetary;
using WorkflowLib.Models.Business.Responsibilities;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Employment contract.
    /// </summary>
    public class EmploymentContract : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// Contract ID.
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        /// Contract.
        /// </summary>
        public Contract? Contract { get; set; }

        /// <summary>
        /// Employment contract type.
        /// </summary>
        public EmploymentContractType EmploymentContractType { get; set; }

        /// <summary>
        /// Expired employment contract.
        /// </summary>
        public EmploymentContract? ExpiredEmploymentContract { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public Employee? Employee { get; set; }

        /// <summary>
        /// Pay rate.
        /// </summary>
        public PayRate? PayRate { get; set; }

        /// <summary>
        /// Employee responsibilities.
        /// </summary>
        public ICollection<EmployeeResponsibility> EmployeeResponsibilities { get; set; }

        /// <summary>
        /// Employer responsibilities.
        /// </summary>
        public ICollection<EmployerResponsibility> EmployerResponsibilities { get; set; }
        
        /// <summary>
        /// Employee benifits.
        /// </summary>
        public ICollection<EmployeeBenefit> EmployeeBenifits { get; set; }
        
        /// <summary>
        /// Schedule.
        /// </summary>
        public Schedule? Schedule { get; set; }

        /// <summary>
        /// Non-compete clause.
        /// </summary>
        public NonCompeteClause? NonCompeteClause { get; set; }

        /// <summary>
        /// Status of the employment contract.
        /// </summary>
        public EmploymentContractStatus Status { get; set; }

        /// <summary>
        /// Internal termination reasons.
        /// </summary>
        public ICollection<EmploymentTerminationReason> InternalTerminationReasons { get; set; }

        /// <summary>
        /// Official termination reasons.
        /// </summary>
        public EmploymentTerminationReason? OfficialTerminationReason { get; set; }
        
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