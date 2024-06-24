using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.Models
{
    public class ReportRow
    {
        public string ParticipantName { get; private set; }
        public string Qty { get; private set; }
        public string PriceUsd { get; private set; }
        
        public ReportRow(string participantName, string qty, string priceUsd)
        {
            ParticipantName = participantName; 
            Qty = qty; 
            PriceUsd = priceUsd; 
        }
    }
}