using Banking.Common.Enums; 
using Banking.Common.Models; 
using System.Collections.Generic;

namespace Banking.Eftpos
{
    public class BaseEftpos : IEftpos
    {
        private string ServerAddress { get; set; } 
        private string EftposUid { get; set; } 
        private string EftposInfo { get; set; } 

        public BaseEftpos(string serverAddress, string eftposUid, string eftposInfo) 
        {
            ServerAddress = serverAddress; 
            EftposUid = eftposUid; 
            EftposInfo = eftposInfo; 
        } 
        
        /// <summary>
        /// Start payment: tap, swipe or insert card to make a payment 
        /// </summary>
        public bool StartPayment()
        {
            return true; 
        }

        public bool FinishPayment()
        {
            return true; 
        }

        public bool EnterPin(string cardNumber, string pin)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "eftpos" },
                { "operationname", "enterpin" },
                { "eftposuid", EftposUid },
                { "cardnumber", cardNumber },
                { "pin", pin },
                { "eftposinfo", EftposInfo }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "eftpos/" + EftposUid + "/pin/enter/", values));

            return true; 
        }

        public bool TransferToEftpos(string cardNumber, Money money, Currency currency)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "eftpos" },
                { "operationname", "transfertoeftpos" },
                { "eftposuid", EftposUid },
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() },
                { "eftposinfo", EftposInfo }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "eftpos/" + EftposUid + "/transfer/", values));

            return true; 
        }
    }
}
