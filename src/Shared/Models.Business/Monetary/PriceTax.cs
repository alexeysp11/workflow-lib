namespace WorkflowLib.Shared.Models.Business.Monetary
{
    public class PriceTax
    {
        /// <summary>
        /// Tax.
        /// </summary>
        public Tax? Tax { get; set; }

        /// <summary>
        /// Price.
        /// </summary>
        public Price? Price { get; set; }
    }
}