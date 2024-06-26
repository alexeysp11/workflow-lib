using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    /// <summary>
    /// Delivery method
    /// </summary>
    public class DeliveryMethod : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Type of the delivery method.
        /// </summary>
        public DeliveryMethodType Type { get; set; }

        /// <summary>
        /// Price of the delivery method.
        /// </summary>
        public decimal Price { get; set; }
    }
}