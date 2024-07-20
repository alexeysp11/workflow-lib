using System;
using System.Collections.Generic;
using Xunit;
using WorkflowLib.Examples.BookList.Models;

namespace Tests.BookList.Models
{
    public class UserTests
    {
        [Fact]
        public void Initilize_SetProperties_GetSameValues()
        {
            // Arrange. 
            string fullname = "DefaultUser";
            string country = "SomeCountry";
            string city = "SomeCity";

            // Act. 
            User user = new User() 
            {
                Fullname = fullname, Country = country, City = city
            };

            // Assert. 
            Assert.Equal(user.Fullname, fullname);
            Assert.Equal(user.Country, country);
            Assert.Equal(user.City, city);
        }

        [Fact]
        public void Initilize_ChangeProperties_GetChangedValues()
        {
            // Arrange. 
            string fullname = "DefaultUser";
            string country = "SomeCountry";
            string city = "SomeCity";

            User user = new User() 
            {
                Fullname = "fullname", Country = "country", City = "city"
            };

            // Act. 
            user.Fullname = fullname;
            user.Country = country;
            user.City = city;

            // Assert. 
            Assert.Equal(user.Fullname, fullname);
            Assert.Equal(user.Country, country);
            Assert.Equal(user.City, city);
        }

        [Fact]
        public void Initilize_SetEmptyList_GetNotNullEmptyList()
        {
            // Arrange. 
            int expectedCount = 0;
            User user = new User() 
            {
                Fullname = "fullname", Country = "country", City = "city"
            };

            // Act. 
            user.Books = new List<Book>();  

            // Assert. 
            Assert.True(user.Books != null);
            Assert.Equal(user.Books.Count, expectedCount);
        }

        [Fact]
        public void Initilize_SetNotEmptyList_GetSameValuesFromNotNullNotEmptyList()
        {
            // Arrange. 
            int bookId = 1;
            string bookName = "Name of a book";
            string author = "Some author";
            string description = "Some description for the book";
            User user = new User() 
            {
                Fullname = "fullname", Country = "country", City = "city"
            };

            // Act. 
            user.Books = new List<Book>() 
            {
                new Book(bookId, bookName, author, description) 
            };

            // Assert. 
            Assert.Equal(user.Books[0].BookId, bookId);
            Assert.True(user.Books != null);
            Assert.True(user.Books.Count > 0);
            Assert.Equal(user.Books[0].Name, bookName);
            Assert.Equal(user.Books[0].Author, author);
            Assert.Equal(user.Books[0].Desciption, description);
        }

        [Fact]
        public void Initilize_ChangeValuesInNotEmptyList_GetChangedValuesFromNotNullNotEmptyList()
        {
            // Arrange. 
            int bookId = 1;
            string bookName = "Name of a book";
            string author = "Some author";
            string description = "Some description for the book";
            User user = new User() 
            {
                Fullname = "fullname", Country = "country", City = "city"
            };

            // Act. 
            user.Books = new List<Book>() 
            {
                new Book(bookId, "bookName", "author", "description") 
            };
            user.Books[0].BookId = bookId;
            user.Books[0].Name = bookName;
            user.Books[0].Author = author;
            user.Books[0].Desciption = description;

            // Assert. 
            Assert.Equal(user.Books[0].BookId, bookId);
            Assert.True(user.Books != null);
            Assert.True(user.Books.Count > 0);
            Assert.Equal(user.Books[0].Name, bookName);
            Assert.Equal(user.Books[0].Author, author);
            Assert.Equal(user.Books[0].Desciption, description);
        }
    }
}
