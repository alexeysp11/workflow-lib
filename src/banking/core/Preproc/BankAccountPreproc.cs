using Banking.Core.Models; 
using Banking.Core.Repo; 

namespace Banking.Core.Preproc
{
    public class BankAccountPreproc
    {
        private IBankAccountRepo Repo = new CmrRepo(); 

        public string CheckBalance(int bankAccountId)
        {
            if (bankAccountId < 0) throw new System.Exception("Bank account could not be negative"); 

            var bas = Repo.GetBankAccounts(); 
            foreach (var ba in bas) if (ba.GetBankAccountId() == bankAccountId) return ba.GetBalance(); 
            throw new System.Exception("Could not find bank account"); 
        }
    }
}
