namespace VelocipedeUtils.Examples.BookList.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; } 
        public string Desciption { get; set; }

        public Book() { }

        public Book(int bookId, string name, string author, string description)
        {
            BookId = bookId;
            Name = name;
            Author = author;
            Desciption = description;
        }
    }
}