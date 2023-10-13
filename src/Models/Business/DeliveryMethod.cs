namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class DeliveryMethod
    {
        /// <summary>
        /// ID of the delivery method.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// UID of the delivery method.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Name of the delivery method.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the delivery method.
        /// </summary>
        public string Description { get; set; }

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