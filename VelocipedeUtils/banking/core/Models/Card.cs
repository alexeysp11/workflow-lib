using Banking.Common.Enums; 
using Banking.Common.Models; 

namespace Banking.Core.Models
{
    public class Card
    {
        private int CardId { get; }  
        private string Number { get; } 
        private CardType CardType { get; } 

        private int BankAccountId { get; } 

        private System.DateTime DateOfIssue { get; } 
        private System.DateTime DateOfExpiring { get; } 

        private string Pin { get; set; }

        public Card(int cardId, string number, CardType cardType, int bankAccountId, System.DateTime dateOfIssue, System.DateTime dateOfExpiring, string pin)
        {
            CardId = cardId; 
            Number = number; 
            CardType = cardType; 
            BankAccountId = bankAccountId; 
            DateOfIssue = dateOfIssue; 
            DateOfExpiring = dateOfExpiring; 
            Pin = pin; 
        }

        public int GetBankAccountId()
        {
            return BankAccountId; 
        }
        public string GetNumber()
        {
            return Number; 
        }

        public bool IsPinValid(string pin)
        {
            CheckPinFormat(pin); 
            return Pin.Equals(pin); 
        }
        public bool ChangePin(string oldPin, string newPin)
        {
            CheckPinFormat(oldPin); 
            CheckPinFormat(newPin); 
            Pin = newPin; 
            return true; 
        }

        private void CheckPinFormat(string pin)
        {
            // Check if pin contains 4 digits
            if (pin.Length != 4) throw new System.Exception("Length of PIN should be equal to 4"); 
            foreach (char ch in pin) if (!System.Char.IsDigit(ch)) throw new System.Exception("PIN should contain only digits"); 
        }
    }
}
