using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Atm
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverAddress = "http://localhost:8081/banking/"; 
            string atmUid = "v1"; 
            string cardNumber = "5345-5732-2248", oldPin = "5544", newPin = "2343"; 

            Money moneyDepositUsd = new Money(27, 0, Currency.USD); 
            Money moneyDepositEur = new Money(53, 99, Currency.EUR); 
            Money moneyWithdrawalUsd = new Money(18, 65, Currency.USD); 
            Money moneyWithdrawalEur = new Money(52, 39, Currency.EUR); 

            string bankAccountNumber = "TESTACCOUNT-7298635673"; 
            string phoneNumber = "+1-7832-892364"; 
            Money moneyTbaUsd = new Money(23, 90, Currency.USD); 
            Money moneyTbaEur = new Money(9, 0, Currency.EUR); 
            Money moneyTpnUsd = new Money(4, 63, Currency.USD); 
            Money moneyTpnEur = new Money(1, 34, Currency.EUR); 
            Money moneyFpsUsd = new Money(8, 52, Currency.USD); 
            Money moneyFpsEur = new Money(3, 31, Currency.EUR); 
            
            IAtm atm = new BaseAtm(serverAddress, atmUid); 

            System.Console.WriteLine("ATM imitation\n".ToUpper());
            try
            {
                bool isInserted = atm.InsertCard(); 
                System.Console.WriteLine(isInserted ? "Card inserted" : "Card is not inserted");
                if (!isInserted) return; 

                bool isPinCorrect = atm.EnterPin(cardNumber, oldPin); 
                System.Console.WriteLine("Enter PIN: **** - " + (isPinCorrect ? "OK" : "Incorrect PIN")); 
                if (!isPinCorrect) throw new System.Exception("Incorrect PIN"); 

                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("Deposit: " + moneyDepositUsd.GetString() + " and " + moneyDepositEur.GetString()); 
                atm.DepositMoney(cardNumber, moneyDepositUsd, Currency.USD); 
                atm.DepositMoney(cardNumber, moneyDepositEur, Currency.EUR); 
                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("Withdraw: " + moneyWithdrawalUsd.GetString() + " and " + moneyWithdrawalEur.GetString()); 
                atm.WithdrawMoney(cardNumber, moneyWithdrawalUsd, Currency.USD); 
                atm.WithdrawMoney(cardNumber, moneyWithdrawalEur, Currency.EUR); 
                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("Transfer to bank account '" + bankAccountNumber.ToString() + "': " + moneyTbaUsd.GetString() + " and " + moneyTbaEur.GetString()); 
                atm.TransferToBankAccount(cardNumber, moneyTbaUsd, Currency.USD, bankAccountNumber); 
                atm.TransferToBankAccount(cardNumber, moneyTbaEur, Currency.EUR, bankAccountNumber); 
                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("Transfer to phone number '" + phoneNumber.ToString() + "': " + moneyTpnUsd.GetString() + " and " + moneyTpnEur.GetString()); 
                atm.TransferToPhoneNumber(cardNumber, moneyTpnUsd, Currency.USD, phoneNumber); 
                atm.TransferToPhoneNumber(cardNumber, moneyTpnEur, Currency.EUR, phoneNumber); 
                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("Transfer to phone number '" + phoneNumber.ToString() + "' via FPS: " + moneyFpsUsd.GetString() + " and " + moneyFpsEur.GetString()); 
                atm.TransferViaFps(cardNumber, moneyFpsUsd, Currency.USD, phoneNumber); 
                atm.TransferViaFps(cardNumber, moneyFpsEur, Currency.EUR, phoneNumber); 
                System.Console.WriteLine(atm.CheckBalance(cardNumber)); 

                System.Console.WriteLine("New PIN: **** - " + (atm.ChangePin(cardNumber, oldPin, newPin) ? "OK" : "Unable to change PIN"));
                System.Console.WriteLine("Confirm PIN: **** - " + (atm.EnterPin(cardNumber, newPin) ? "OK" : "Incorrect PIN"));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString()); 
            }
            System.Console.WriteLine(atm.TakeBackCard() ? "Card is taken back" : "Card is still in the ATM");
        }
    }
}
