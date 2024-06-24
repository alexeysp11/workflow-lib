using System; 
using MeetPlanning.Models; 

namespace MeetPlanning.Services
{
    public class UserRepository : IUserRepository
    {
        public bool IsAuthenticated { get; set; }
        
        public void CreateUser(string name, DateTime birthDate, string password, 
            string nationality, string gender)
        {
            // Call DbConnection. 
        }

        public User GetUser(string username, string password)
        {
            // Call DbConnection. 
            return new User(); 
        }
    }
}
