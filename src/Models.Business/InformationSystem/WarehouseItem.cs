using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Warehouse item.
    /// </summary>
    public class WarehouseItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Warehouse.
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Warehouse item status.
        /// </summary>
        public WarehouseItemStatus WarehouseItemStatus { get; set; }
    }
}