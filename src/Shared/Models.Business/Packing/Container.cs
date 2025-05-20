using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;

namespace WorkflowLib.Shared.Models.Business.Packing
{
    /// <summary>
    /// A physical container in which a product is stored or moved (e.g. a box, pallet, barrel).
    /// Can contain multiple units or batches of a product.
    /// </summary>
    public class Container : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Serial shipping container code.
        /// </summary>
        public string Sscc { get; set; }

        /// <summary>
        /// Description of the type of packaging (e.g. box, pallet, crate).
        /// </summary>
        public PackType? PackType { get; set; }
    }
    
    /// <summary>
    /// A small movable container, often used to store and move individual items or small batches within a warehouse. 
    /// May be of standardized size and used in conveyor systems.
    /// </summary>
    public class Tray : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Code of the tray.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of the type of packaging (e.g. box, pallet, crate).
        /// </summary>
        public PackType? PackType { get; set; }
    }
    
    /// <summary>
    /// A group of identical inventory items produced at the same time or to the same specification
    /// (e.g. a batch of products with the same production date).
    /// Simplifies product management, especially when tracking expiration dates or other production-related characteristics.
    /// </summary>
    public class Lot : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Code of the lot.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of the type of packaging (e.g. box, pallet, crate).
        /// </summary>
        public PackType? PackType { get; set; }
    }

    /// <summary>
    /// Description of the type of packaging (e.g. box, pallet, crate).
    /// Includes dimensions, weight, material, and other characteristics.
    /// </summary>
    public class PackType : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Code of the pack type.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Weight of the pack type.
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Weight unit.
        /// </summary>
        public WeightUnit? WeightUnit { get; set; }

        /// <summary>
        /// Pack type material.
        /// </summary>
        public PackTypeMaterial? PackTypeMaterial { get; set; }
    }

    /// <summary>
    /// Pack type material.
    /// </summary>
    public class PackTypeMaterial : WfBusinessEntity, IWfBusinessEntity
    {
    }

    /// <summary>
    /// Weight unit.
    /// </summary>
    public class WeightUnit : WfBusinessEntity, IWfBusinessEntity
    {
    }
}