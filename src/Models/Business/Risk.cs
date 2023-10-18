using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// Risk.
    /// </summary>
    public class Risk : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Risk severity.
        /// </summary>
        public RiskSeverity Severity { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// Creation author.
        /// </summary>
        public Employee CreationAuthor { get; set; }

        /// <summary>
        /// Change date.
        /// </summary>
        public System.DateTime ChangeDate { get; set; }

        /// <summary>
        /// Change author.
        /// </summary>
        public Employee ChangeAuthor { get; set; }

        /// <summary>
        /// Resolving date.
        /// </summary>
        public System.DateTime ResolvingDate { get; set; }

        /// <summary>
        /// Resolving author.
        /// </summary>
        public Employee ResolvingAuthor { get; set; }

        /// <summary>
        /// Resolving comment.
        /// </summary>
        public string ResolvingComment { get; set; }

        /// <summary>
        /// Status of the risk.
        /// </summary>
        public RiskStatus Status { get; set; }
    }
}