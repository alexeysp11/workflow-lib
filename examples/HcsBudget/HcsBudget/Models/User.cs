namespace WorkflowLib.Examples.HcsBudget.Models
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Language { get; private set; }
        public string Currency { get; private set; }
        public string CurrAbbreviation { get; private set; }
        public string Database { get; private set; }
        public bool IsProtected { get; private set; }
        public string Password { get; private set; }

        public User(int userId, string name, string language, string currency, 
            string currAbbreviation, string database, bool isProtected, 
            string password)
        {
            UserId = userId; 
            Name = name; 
            Language = language; 
            Currency = currency; 
            CurrAbbreviation = currAbbreviation; 
            Database = database; 
            IsProtected = isProtected; 
            Password = password; 
        }
    }
}