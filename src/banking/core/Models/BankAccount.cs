using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Core.Models
{
    public class BankAccount
    {
        private int BankAccountId { get; }
        private string Number { get; }

        private Money MoneyUsd { get; set; }
        private Money MoneyEur { get; set; }

        public BankAccount()
        {
            BankAccountId = 323; 
            Number = "TESTACCOUNT-07523242534"; 

            MoneyUsd = new Money(180, 0, Currency.USD); 
            MoneyEur = new Money(80, 0, Currency.EUR); 
        }

        public BankAccount(int bankAccountId, string number, Money moneyUsd, Money moneyEur)
        {
            BankAccountId = bankAccountId; 
            Number = number; 

            MoneyUsd = moneyUsd; 
            MoneyEur = moneyEur; 
        }

        public int GetBankAccountId()
        {
            return BankAccountId; 
        }
        public string GetBalance()
        {
            return "Your balance is: " + MoneyUsd.GetString() + ", " + MoneyEur.GetString(); 
        }
        public bool DepositMoney(Money money, Currency currency)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Add(money.Integer, money.Fraction); 
            return true;
        }
        public bool WithdrawMoney(Money money, Currency currency)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Substract(money.Integer, money.Fraction); 
            return true;
        }

        public bool SendToBankAccount(Money money, Currency currency, string bankAccountNumber)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Substract(money.Integer, money.Fraction); 
            return true;
        }
        public bool SendToPhoneNumber(Money money, Currency currency, string phoneNumber)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Substract(money.Integer, money.Fraction); 
            return true;
        }
        public bool SendViaFps(Money money, Currency currency, string phoneNumber)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Substract(money.Integer, money.Fraction); 
            return true;
        }
        public bool SendToEftpos(Money money, Currency currency, string phoneNumber)
        {
            // Add currency rate if input currency is not EUR or USD
            (currency == Currency.EUR ? MoneyEur : MoneyUsd).Substract(money.Integer, money.Fraction); 
            return true;
        }
    }
}
