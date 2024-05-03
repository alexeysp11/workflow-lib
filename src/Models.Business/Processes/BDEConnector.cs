using System.ComponentModel.DataAnnotations.Schema;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Allows you to connect business diagram elements.
    /// </summary>
    public class BDEConnector : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Start business diagram element.
        /// </summary>
        public BusinessDiagramElement? StartElement { get; set; }

        /// <summary>
        /// End business diagram element.
        /// </summary>
        [NotMapped]
        public BusinessDiagramElement? EndElement { get; set; }
    }
}