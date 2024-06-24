using System; 
using MeetPlanning.Models; 

namespace MeetPlanning.Services
{
    public interface IUserRepository
    {
        bool IsAuthenticated { get; set; }

        void CreateUser(string name, DateTime birthDate, string password, 
            string nationality, string gender); 
        User GetUser(string username, string password); 
    }
}
