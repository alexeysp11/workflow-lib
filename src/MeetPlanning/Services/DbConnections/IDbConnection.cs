using MeetPlanning.Services; 

namespace MeetPlanning.Services.DbConnections
{
    public interface IDbConnection
    {
        void CreateAccount(string username, string birthDate, 
            string nationality, string gender, string password); 
        void LogIn(); 
        void Synchronize(); 
    }
}