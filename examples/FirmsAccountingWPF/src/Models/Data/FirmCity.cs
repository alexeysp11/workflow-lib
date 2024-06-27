namespace WorkflowLib.Examples.FirmsAccounting.Models.Data
{
    public class FirmCity
    {
        public int FirmId { get; set; }
        public string FirmName { get; set; }
        public string PostalAddressCity { get; set; }
        public string JurAddressCity { get; set; }

        public FirmCity(int firmId, string firmName, string postalAddressCity, 
            string jurAddressCity)
        {
            FirmId = firmId; 
            FirmName = firmName; 
            PostalAddressCity = postalAddressCity; 
            JurAddressCity = jurAddressCity; 
        }
    }
}