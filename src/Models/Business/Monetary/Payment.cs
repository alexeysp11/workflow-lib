namespace Cims.WorkflowLib.Models.Business.Monetary
{
    public class Payment
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public float Amount { get; set; }
        public string Payer { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
    }
}