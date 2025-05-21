using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Warehousing
{
    /// <summary>
    /// Warehouse.
    /// </summary>
    public class Warehouse : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Organization item related to the warehouse.
        /// </summary>
        public OrganizationItem OrganizationItem { get; set; }

        /// <summary>
        /// Warehouse items that are stored or related to the warehouse.
        /// </summary>
        public ICollection<WarehouseItem> WarehouseItems { get; set; }

        /// <summary>
        /// Address of the warehouse.
        /// </summary>
        public string? Address { get; set; }
    }
}