using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.RiskManagement
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
        /// Creation author.
        /// </summary>
        public Employee? AuthorCreated { get; set; }

        /// <summary>
        /// Change author.
        /// </summary>
        public Employee? AuthorChanged { get; set; }

        /// <summary>
        /// Resolving date.
        /// </summary>
        public System.DateTime? DateResolved { get; set; }

        /// <summary>
        /// Resolving author.
        /// </summary>
        public Employee? AuthorResolved { get; set; }

        /// <summary>
        /// Resolving comment.
        /// </summary>
        public string? CommentResolved { get; set; }

        /// <summary>
        /// Status of the risk.
        /// </summary>
        public RiskStatus Status { get; set; }
    }
}