namespace WorkflowLib.Shared.Models.Business.Products
{
    /// <summary>
    /// Interface that represents a business entity which is expirable.
    /// </summary>
    public interface IExpirableProduct : IWfBusinessEntity
    {
        /// <summary>
        /// Production date.
        /// </summary>
        System.DateTime? DateProduction { get; set; }
        
        /// <summary>
        /// Packaging date.
        /// </summary>
        System.DateTime? DatePackaging { get; set; }
        
        /// <summary>
        /// Expiration date.
        /// </summary>
        System.DateTime? DateExpiration { get; set; }
    }
}