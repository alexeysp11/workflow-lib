using System.Text.Json.Serialization; 

namespace Banking.Core.Models
{
    /// <summary>
    /// Class that represents financial operation which should be processed 
    /// </summary>
    public class FinOperation
    {
        // sourcename
        [JsonPropertyName("sourcename")]
        public string SourceName { get; set; }
        // operationname
        [JsonPropertyName("operationname")]
        public string OperationName { get; set; }
        
        // atmuid
        [JsonPropertyName("atmuid")]
        public string AmtUid { get; set; }
        
        // eftposuid
        [JsonPropertyName("eftposuid")]
        public string EftposUid { get; set; }
        // eftposinfo
        [JsonPropertyName("eftposinfo")]
        public string EftposInfo { get; set; }
        
        // cardnumber
        [JsonPropertyName("cardnumber")]
        public string CardNumber { get; set; }
        
        // pin
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
        // oldpin
        [JsonPropertyName("oldpin")]
        public string OldPin { get; set; }
        // newpin
        [JsonPropertyName("newpin")]
        public string NewPin { get; set; }
        
        // amount
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        // currency
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        // receiverbankaccountnumber
        [JsonPropertyName("receiverbankaccountnumber")]
        public string ReceiverBankAccountNumber { get; set; }
        // receiverphonenumber
        [JsonPropertyName("receiverphonenumber")]
        public string ReceiverPhoneNumber { get; set; }
    }
}