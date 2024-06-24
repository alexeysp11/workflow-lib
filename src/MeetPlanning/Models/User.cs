using System; 

namespace MeetPlanning.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }

        public User()
        {
            
        }

        public User(int userId, string name, DateTime birthDate, 
            string password, string nationality, string gender) 
        {
            this.UserId = userId;
            this.Name = name;
            this.BirthDate = birthDate;
            this.Password = password;
            this.Nationality = nationality;
            this.Gender = gender;
        }
    }
}