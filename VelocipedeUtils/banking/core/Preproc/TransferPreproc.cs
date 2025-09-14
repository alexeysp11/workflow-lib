using Banking.Common.Enums; 
using Banking.Common.Models; 
using Banking.Core.Models; 
using Banking.Core.Repo; 

namespace Banking.Core.Preproc
{
    public class TransferPreproc : ICommonTransferPreproc, IEftposTransferPreproc
    {
        private IBankAccountRepo Repo = new CmrRepo(); 

        public bool DepositMoney(int bankAccountId, Money money, Currency currency)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).DepositMoney(money, currency); 
        }
        public bool WithdrawMoney(int bankAccountId, Money money, Currency currency)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).WithdrawMoney(money, currency); 
        }
        public bool TransferToBankAccount(int bankAccountId, Money money, Currency currency, string bankAccountNumber)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).SendToBankAccount(money, currency, bankAccountNumber); 
        }
        public bool TransferToPhoneNumber(int bankAccountId, Money money, Currency currency, string phoneNumber)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).SendToPhoneNumber(money, currency, phoneNumber); 
        }
        public bool TransferViaFps(int bankAccountId, Money money, Currency currency, string phoneNumber)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).SendViaFps(money, currency, phoneNumber); 
        }
        public bool TransferToEftpos(int bankAccountId, Money money, Currency currency, string eftposInfo)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 
            return GetBankAccount(bankAccountId).SendToEftpos(money, currency, eftposInfo); 
        }

        private BankAccount GetBankAccount(int bankAccountId)
        {
            var bas = Repo.GetBankAccounts(); 
            foreach (var ba in bas) if (ba.GetBankAccountId() == bankAccountId) return ba; 
            throw new System.Exception("Could not find bank account"); 
        } 
    }
}
