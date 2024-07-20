using System;
using Xunit;
using WorkflowLib.Examples.BookList.Models;

namespace Tests.BookList.Models
{
    public class BookTests
    {
        [Fact]
        public void Initilize_UseParameterizedConstructor_ValuesTheSame()
        {
            //Given
            int bookId = 1;
            string name = "Default name";
            string author = "Default author";
            string description = "Default description";
            
            //When
            Book book = new Book(bookId, name, author, description);
            
            //Then
            Assert.Equal(book.BookId, bookId);
            Assert.True(book != null);
            Assert.Equal(book.Name, name);
            Assert.Equal(book.Author, author);
            Assert.Equal(book.Desciption, description);
        }

        [Fact]
        public void Initilize_UseDefaultConstructor_ValuesTheSame()
        {
            //Given
            int bookId = 1;
            string name = "Default name";
            string author = "Default author";
            string description = "Default description";
            
            //When
            Book book = new Book();
            book.BookId = bookId;
            book.Name = name;
            book.Author = author;
            book.Desciption = description;  
            
            //Then
            Assert.Equal(book.BookId, bookId);
            Assert.True(book != null);
            Assert.Equal(book.Name, name);
            Assert.Equal(book.Author, author);
            Assert.Equal(book.Desciption, description);
        }
    }
}