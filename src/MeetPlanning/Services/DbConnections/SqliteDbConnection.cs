using MeetPlanning.Services;

namespace MeetPlanning.Services.DbConnections
{
    public class SqliteDbConnection : IDbConnection
    {
        private string ConnString = "";

        public SqliteDbConnection()
        {
            
        }
        
        public SqliteDbConnection(string connString)
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