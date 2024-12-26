using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Atm
{
    public interface IAtm
    {
        bool InsertCard(); 
        bool TakeBackCard(); 

        bool EnterPin(string cardNumber, string pin); 
        bool ChangePin(string cardNumber, string oldPin, string newPin); 

        string CheckBalance(string cardNumber); 

        bool DepositMoney(string cardNumber, Money money, Currency currency); 
        bool WithdrawMoney(string cardNumber, Money money, Currency currency); 

        bool TransferToBankAccount(string cardNumber, Money money, Currency currency, string bankAccountNumber); 
        bool TransferToPhoneNumber(string cardNumber, Money money, Currency currency, string phoneNumber); 
        bool TransferViaFps(string cardNumber, Money money, Currency currency, string phoneNumber); 
    }
}
