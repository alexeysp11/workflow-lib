using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Warehousing
{
    /// <summary>
    /// Request for assembly and shipment of a certain number of goods.
    /// </summary>
    public class WarehouseOrder : WfBusinessEntity, IWfBusinessEntity, ITemporalBusinessEntity
    {
        /// <summary>
        /// Number of the warehouse order.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Warehouse.
        /// </summary>
        public Warehouse? Warehouse { get; set; }

        /// <summary>
        /// Warehouse order type.
        /// </summary>
        public WarehouseOrderType? WarehouseOrderType { get; set; }
        
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

    /// <summary>
    /// A specific task that must be completed in the warehouse (e.g., receiving goods, placing goods, assembling an order).
    /// May be associated with the movement of goods.
    /// </summary>
    public class WarehouseTask : WfBusinessEntity, IWfBusinessEntity, ITemporalBusinessEntity
    {
        /// <summary>
        /// Number of the warehouse order.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Warehouse.
        /// </summary>
        public Warehouse? Warehouse { get; set; }

        /// <summary>
        /// Warehouse order type.
        /// </summary>
        public WarehouseOrder? WarehouseOrder { get; set; }
        
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

    /// <summary>
    /// Warehouse order type.
    /// </summary>
    public enum WarehouseOrderType
    {
        None = 0,
        Assembly = 1,
        Shipment = 2,
        Placement = 3,
        Receipt = 4,
        Return = 5,
        StockTaking = 6
    }

    /// <summary>
    /// Physical location of the product in the warehouse.
    /// It can have characteristics (e.g. size, load capacity, temperature conditions).
    /// Allows you to effectively organize the placement and search of products.
    /// </summary>
    public class Location : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Number of the location.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Load capacity of the location.
        /// </summary>
        public int LoadCapacity { get; set; }

        /// <summary>
        /// Location type.
        /// </summary>
        public LocationType? LocationType { get; set; }

        /// <summary>
        /// Zone.
        /// </summary>
        public Zone? Zone { get; set; }
    }

    /// <summary>
    /// A group of locations united by some feature (e.g. receiving zone, shipping zone, storage zone).
    /// Allows you to group locations for ease of management, route optimization and safety.
    /// </summary>
    public class Zone : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Number of the location.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Zone type.
        /// </summary>
        public ZoneType? ZoneType { get; set; }
    }
    
    /// <summary>
    /// Definition of the functional purpose of the location (e.g. receiving location, storage location, picking location).
    /// </summary>
    public enum LocationType
    {
        None = 0,
        Receiving = 1,
        Storage = 2,
        Picking = 3
    }

    /// <summary>
    /// Definition of the functional purpose of the zone (e.g. receiving location, storage location, picking location).
    /// </summary>
    public enum ZoneType
    {
        None = 0,
        Receiving = 1,
        Storage = 2,
        Picking = 3
    }
}