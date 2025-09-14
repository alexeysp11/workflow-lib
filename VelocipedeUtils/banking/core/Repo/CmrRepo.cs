using System.Collections.Generic; 
using Banking.Common.Enums; 
using Banking.Common.Models; 
using Banking.Core.Models; 

namespace Banking.Core.Repo
{
    public class CmrRepo : ICardRepo, IBankAccountRepo, ITransactionRepo
    {
        private Customer Customer { get; set; }
        private List<BankAccount> BankAccounts { get; set; }
        private List<Card> Cards { get; set; }
        private List<PhoneNumber> PhoneNumbers { get; set; }
        private List<Transaction> Transactions { get; set; }
        private List<Notification> Notifications { get; set; }
        private List<Device> Devices { get; set; }

        public CmrRepo()
        {
            int bankAccountId = 323; 
            BankAccounts = new List<BankAccount>() { new BankAccount(bankAccountId, "TESTACCOUNT-07523242534", new Money(180, 0, Currency.USD), new Money(80, 0, Currency.EUR)) }; 
            Cards = new List<Card>() { new Card(34, "5345-5732-2248", CardType.Visa, bankAccountId, new System.DateTime(2020,10,23), new System.DateTime(2025,10,23), "5544") }; 
        }

        public List<Card> GetCards()
        {
            return Cards; 
        }
        public List<BankAccount> GetBankAccounts()
        {
            return BankAccounts; 
        }
        public List<Transaction> GetTransactions()
        {
            return Transactions; 
        }
    }
}
