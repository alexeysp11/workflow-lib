using Banking.Common.Enums; 
using Banking.Common.Models; 
using Banking.Core.Preproc; 

namespace Banking.Core
{
    public class CoreRouter
    {
        private CardPreproc CardPreproc { get; set; }
        private BankAccountPreproc BankAccountPreproc { get; set; }
        private ICommonTransferPreproc CommonTransferPreproc { get; set; }
        private IEftposTransferPreproc EftposTransferPreproc { get; set; }

        public CoreRouter()
        {
            CardPreproc = new CardPreproc(); 
            BankAccountPreproc = new BankAccountPreproc(); 
            CommonTransferPreproc = new TransferPreproc(); 
            EftposTransferPreproc = new TransferPreproc(); 
        }

        #region ATM 
        public bool EnterPin(string cardNumber, string pin)
        {
            return CardPreproc.CheckPin(cardNumber, pin); 
        }
        public bool ChangePin(string cardNumber, string oldPin, string newPin)
        {
            return CardPreproc.ChangePin(cardNumber, oldPin, newPin); 
        }
        
        public string CheckBalance(string cardNumber)
        {
            return BankAccountPreproc.CheckBalance(CardPreproc.GetBankAccountId(cardNumber)); 
        }

        public bool DepositMoney(string cardNumber, Money money, Currency currency)
        {
            return CommonTransferPreproc.DepositMoney(CardPreproc.GetBankAccountId(cardNumber), money, currency); 
        }
        public bool WithdrawMoney(string cardNumber, Money money, Currency currency)
        {
            return CommonTransferPreproc.WithdrawMoney(CardPreproc.GetBankAccountId(cardNumber), money, currency); 
        }

        public bool TransferToBankAccount(string cardNumber, Money money, Currency currency, string bankAccountNumber)
        {
            return CommonTransferPreproc.TransferToBankAccount(CardPreproc.GetBankAccountId(cardNumber), money, currency, bankAccountNumber); 
        }
        public bool TransferToPhoneNumber(string cardNumber, Money money, Currency currency, string phoneNumber)
        {
            return CommonTransferPreproc.TransferToPhoneNumber(CardPreproc.GetBankAccountId(cardNumber), money, currency, phoneNumber); 
        }
        public bool TransferViaFps(string cardNumber, Money money, Currency currency, string phoneNumber)
        {
            return CommonTransferPreproc.TransferViaFps(CardPreproc.GetBankAccountId(cardNumber), money, currency, phoneNumber); 
        }
        #endregion  // ATM 
        
        #region EFTPOS

        public bool TransferToEftpos(string cardNumber, Money money, Currency currency, string eftposInfo)
        {
            return EftposTransferPreproc.TransferToEftpos(CardPreproc.GetBankAccountId(cardNumber), money, currency, eftposInfo); 
        }
        #endregion  // EFTPOS
    }
}
