using System.Collections.Generic; 

namespace WorkflowLib.Examples.BookList.Models
{
    public class User
    {
        public string Fullname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public List<Book> Books { get; set; } 
    }
}