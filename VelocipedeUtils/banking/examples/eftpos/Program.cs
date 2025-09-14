using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Eftpos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinished = false; 
            string serverAddress = "http://localhost:8081/banking/"; 
            string cardNumber = "5345-5732-2248", pin = "5544"; 
            string eftposUid = "v1", eftposInfo = "TEST-EFTPOS INFO. ADDRESS: 58, TEST STR., SKU: 094"; 
            Money moneyEftposUsd = new Money(23, 90, Currency.USD); 

            IEftpos eftpos = new BaseEftpos(serverAddress, eftposUid, eftposInfo); 

            System.Console.WriteLine("EFTPOS imitation\n".ToUpper());
            try
            {
                // Start payment: tap, swipe or insert card to make a payment 
                bool isStarted = eftpos.StartPayment(); 
                System.Console.WriteLine(isStarted ? "Payment started" : "Failed to start payment");
                if (!isStarted) return; 
                
                // Enter PIN to check if it is valid 
                bool isPinCorrect = eftpos.EnterPin(cardNumber, pin); 
                System.Console.WriteLine("Enter PIN: **** - " + (isPinCorrect ? "OK" : "Incorrect PIN")); 
                if (!isPinCorrect) throw new System.Exception("Incorrect PIN"); 

                // Get result of a payment 
                System.Console.WriteLine("Transfer EFTPOS (" + eftposInfo + "): " + moneyEftposUsd.GetString()); 
                isFinished = eftpos.TransferToEftpos(cardNumber, moneyEftposUsd, Currency.USD); 
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString()); 
            }
            finally
            {
                System.Console.WriteLine(isFinished ? "Payment finished" : "Failed to finish payment");
                eftpos.FinishPayment(); 
            }
        }
    }
}
