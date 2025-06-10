using System.Collections.Generic; 
using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Atm
{
    public class BaseAtm : IAtm
    {
        private string ServerAddress { get; set; } 
        private string AtmUid { get; set; } 

        public BaseAtm(string serverAddress, string atmUid)
        {
            ServerAddress = serverAddress; 
            AtmUid = atmUid; 
        }
        
        public bool InsertCard()
        {
            return true; 
        }
        public bool TakeBackCard()
        {
            return true; 
        }

        public bool EnterPin(string cardNumber, string pin)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "enterpin" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "pin", pin }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/pin/enter/", values));

            return true; 
        }
        public bool ChangePin(string cardNumber, string oldPin, string newPin)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "changepin" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "oldpin", oldPin },
                { "newpin", newPin }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/pin/change/", values));

            return true; 
        }
        
        public string CheckBalance(string cardNumber)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "checkbalance" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/balance/get/", values));

            return "Balance: "; 
        }

        public bool DepositMoney(string cardNumber, Money money, Currency currency)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "depositmoney" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/cash/deposit/", values));

            return true; 
        }
        public bool WithdrawMoney(string cardNumber, Money money, Currency currency)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "withdrawmoney" },
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/cash/withdraw/", values));

            return true; 
        }

        public bool TransferToBankAccount(string cardNumber, Money money, Currency currency, string bankAccountNumber)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "transfertobankaccount" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() },
                { "receiverbankaccountnumber", bankAccountNumber }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/transfer/tobankaccount/", values));

            return true; 
        }
        public bool TransferToPhoneNumber(string cardNumber, Money money, Currency currency, string phoneNumber)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "transfertophonenumber" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() },
                { "receiverphonenumber", phoneNumber.Replace("+", "") }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/transfer/tophonenumber/", values));

            return true; 
        }
        public bool TransferViaFps(string cardNumber, Money money, Currency currency, string phoneNumber)
        {
            var values = new Dictionary<string, string>
            {
                { "sourcename", "atm" },
                { "operationname", "transferviafps" },
                { "atmuid", AtmUid }, 
                { "cardnumber", cardNumber },
                { "amount", money.GetAmount() },
                { "currency", money.GetCurrency().ToLower() },
                { "receiverphonenumber", phoneNumber.Replace("+", "") }
            };
            System.Console.WriteLine(Banking.Common.BankingHttpClient.Post(ServerAddress + "atm/" + AtmUid + "/transfer/fps/", values));

            return true; 
        }
    }
}
