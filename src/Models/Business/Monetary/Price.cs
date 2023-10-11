using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Price
    {
        /// <summary>
        /// 
        /// </summary>
        public Price() {}
        /// <summary>
        /// 
        /// </summary>
        public Price(decimal netPrice)
        {
            NetPrice = netPrice;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Tax> Taxes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal NetPrice { get; }
    }
}