using Banking.Common.Models; 
using Banking.Core.Models; 
using Banking.Core.Repo; 

namespace Banking.Core.Preproc
{
    public class CardPreproc
    {
        private ICardRepo Repo = new CmrRepo(); 

        public bool CheckPin(string cardNumber, string pin)
        {
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(pin)) throw new System.Exception("Card number and PIN could not be empty"); 
            return GetCard(cardNumber).IsPinValid(pin); 
        }
        public bool ChangePin(string cardNumber, string oldPin, string newPin)
        {
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(oldPin) || string.IsNullOrEmpty(newPin)) throw new System.Exception("Card number and PIN could not be empty"); 
            return GetCard(cardNumber).ChangePin(oldPin, newPin); 
        }

        public int GetBankAccountId(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) throw new System.Exception("Card number could not be empty"); 
            return GetCard(cardNumber).GetBankAccountId();
        }

        private Card GetCard(string cardNumber)
        {
            var cards = Repo.GetCards(); 
            foreach (var card in cards) if (card.GetNumber().Equals(cardNumber)) return card; 
            throw new System.Exception("Card number not found"); 
        }
    }
}
