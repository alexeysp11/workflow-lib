using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Warehouse item.
    /// </summary>
    public class WarehouseItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Warehouse.
        /// </summary>
        public Warehouse? Warehouse { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Warehouse item status.
        /// </summary>
        public WarehouseItemStatus WarehouseItemStatus { get; set; }
    }
}