using MeetPlanning.Services; 

namespace MeetPlanning.Services.DbConnections
{
    public class PgDbConnection : IDbConnection
    {
        private string ConnString = ""; 

        public PgDbConnection()
        {
            
        }

        public PgDbConnection(string connString)
        {
            ConnString = connString; 
        }

        public void CreateAccount(string username, string birthDate, 
            string nationality, string gender, string password)
        {

        }

        public void LogIn()
        {

        }

        public void Synchronize()
        {

        }
    }
}