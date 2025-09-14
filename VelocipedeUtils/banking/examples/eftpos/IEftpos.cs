using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Eftpos
{
    public interface IEftpos
    {
        bool StartPayment(); 
        bool FinishPayment(); 
        bool EnterPin(string cardNumber, string pin); 
        bool TransferToEftpos(string cardNumber, Money money, Currency currency); 
    }
}
