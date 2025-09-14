using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Core.Preproc
{
    public interface IEftposTransferPreproc
    {
        bool TransferToEftpos(int bankAccountId, Money money, Currency currency, string eftposInfo); 
    }
}
