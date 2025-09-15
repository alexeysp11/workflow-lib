using System.Collections.Generic; 
using Banking.Core.Models; 

namespace Banking.Core.Repo
{
    public interface IBankAccountRepo
    {
        List<BankAccount> GetBankAccounts();
    }
}
