using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.RiskManagement
{
    /// <summary>
    /// Risk.
    /// </summary>
    public class Risk : WfBusinessEntity, IWfBusinessEntity
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