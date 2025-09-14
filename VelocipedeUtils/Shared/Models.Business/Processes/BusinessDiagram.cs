using System.Collections.Generic;
using VelocipedeUtils.Shared.Models.Business;

namespace VelocipedeUtils.Shared.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram
    /// </summary>
    public class BusinessDiagram : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Collection of business diagram elements.
        /// </summary>
        public ICollection<BusinessDiagramElement> Elements { get; set; }
    }
}