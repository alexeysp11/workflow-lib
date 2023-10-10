using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Price
    {
        public Price() {}
        public Price(float netPrice)
        {
            NetPrice = netPrice;
        }

        public float ListPrice { get; set; }
        public List<Tax> Taxes { get; set; }
        public float Discount { get; set; }
        public float NetPrice { get; }
    }
}