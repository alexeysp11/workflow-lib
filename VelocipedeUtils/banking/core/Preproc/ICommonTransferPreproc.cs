using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Core.Preproc
{
    public interface ICommonTransferPreproc
    {
        bool DepositMoney(int bankAccountId, Money money, Currency currency); 
        bool WithdrawMoney(int bankAccountId, Money money, Currency currency); 
        bool TransferToBankAccount(int bankAccountId, Money money, Currency currency, string bankAccountNumber); 
        bool TransferToPhoneNumber(int bankAccountId, Money money, Currency currency, string phoneNumber); 
        bool TransferViaFps(int bankAccountId, Money money, Currency currency, string phoneNumber); 
    }
}
