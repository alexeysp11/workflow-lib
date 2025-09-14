using System.Collections.Generic;
using VelocipedeUtils.Examples.BookList.Models;
using Security.Models;

namespace VelocipedeUtils.Examples.BookList.Services
{
    /// <summary>
    /// Class that allows users to interact with database 
    /// </summary>
    public class UserRepository : IUserRepository 
    {
        #region Members
        /// <summary>
        /// Instance of database helper for interacting with SQLite DB  
        /// </summary>
        private IDbHelper DbHelper;
        /// <summary>
        /// Instance of the current user. 
        /// </summary>
        private User UserObj = null;
        #endregion  // Members

        #region Private fields
        /// <summary>
        /// Field that sores the user's password (delete it when the user logged out)
        /// </summary>
        private string Password;
        #endregion  // Private fields

        #region Constructors
        /// <summary>
        /// Constructor that initilizes the user by default. 
        /// </summary>
        public UserRepository()
        {
            DbHelper = new SqliteDbHelper();
            DbHelper.CreateTables();
        }

        /// <summary>
        /// Constructor that initilizes the user by default. 
        /// </summary>
        public UserRepository(IDbHelper dbHelper)
        {
            DbHelper = dbHelper;
            DbHelper.CreateTables();
        }
        #endregion  // Constructors

        #region Personal information
        /// <summary>
        /// Creates the user if does not exist in the DB (SQL requests are used)
        /// </summary>
        /// <param name="fullname">String value of fullname of the user</param>
        /// <param name="country">String value of country of the user</param>
        /// <param name="city">String value of city of the user</param>
        /// <param name="password">String value of password of the user</param>
        public void CreateUser(string fullname, string country, string city, 
            string password)
        {
            try
            {
                EncryptPassword(ref password);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            // Requests for country information. 
            string insertCounty = $@"INSERT INTO Countries (CountryName) 
                SELECT ('{country}')
                WHERE (SELECT COUNT(1) FROM Countries WHERE CountryName = '{country}') = 0;";

            // Requests for city information. 
            string insertCity = $@"INSERT INTO Cities (CityName, CountryIdFK) 
                VALUES (
                    '{city}', 
                    (SELECT CountryId FROM Countries WHERE CountryName = '{country}')
                );";  
            string checkCity = $@"SELECT COUNT (1) FROM Cities 
                WHERE CityName = '{city}';";

            // Requests for user information. 
            string insertUser = $@"INSERT INTO Users (Fullname, CityIdFK, Password) 
                VALUES (
                    '{fullname}', 
                    (SELECT CityId FROM Cities WHERE CityName = '{city}'), 
                    '{password}'
                );";  
            string checkUser = $@"SELECT COUNT (1) FROM Users 
                WHERE Fullname = '{fullname}' AND Password = '{password}';";
            
            try
            {
                // Insert all data into database. 
                DbHelper.Insert(insertCounty);
                DbHelper.Insert(insertCity, checkCity);
                DbHelper.Insert(insertUser, checkUser);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Allows to get current active user using SQL request. 
        /// </summary>
        /// <param name="fullname">String value of fullname of the user</param>
        /// <param name="password">String value of password of the user</param>
        /// <returns>Instance of User class</returns>
        public bool DoesExist(string fullname, string password)
        {
            // Get if input strings are correct. 
            bool isFullnameCorrect = (fullname != null && fullname != string.Empty);
            bool isPasswordCorrect = (password != null && password != string.Empty);
            if (!isFullnameCorrect || !isPasswordCorrect)
            {
                throw new System.Exception("Unable to athenticate user in the repository (string cannot be empty or null).");
            }

            try
            {
                EncryptPassword(ref password);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            string checkUser = $@"SELECT COUNT (1) FROM Users 
                WHERE Fullname = '{fullname}' AND Password = '{password}';";
            
            bool exists = false;
            try
            {
                exists = DbHelper.DoesExist(checkUser);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return exists;
        }

        /// <summary>
        /// Assigns an instance of the user
        /// </summary>
        /// <param name="fullname">String value of the user's fullname</param>
        public void AuthenticateUser(string fullname, string password)
        {
            // Get if input strings are correct. 
            bool isFullnameCorrect = (fullname != null && fullname != string.Empty);
            bool isPasswordCorrect = (password != null && password != string.Empty);
            if (!isFullnameCorrect || !isPasswordCorrect)
            {
                throw new System.Exception("Unable to athenticate user in the repository (string cannot be empty or null).");
            }

            // Encrypt password and get if the user exists in the DB. 
            try
            {
                if ( !DoesExist(fullname, password) )
                {
                    throw new System.Exception($"Unable to athenticate user in the repository (user {fullname} does not exist in the DB).");
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

            // Get data about the user from DB. 
            string country = string.Empty;
            string city = string.Empty;
            EncryptPassword(ref password);
            DbHelper.GetInfoAboutUser(fullname, out country, out city, password);

            // Create an instance of the user. 
            UserObj = new User()
            {
                Fullname = fullname, Country = country, City = city 
            };
            UserObj.Books = new List<Book>();

            // Store password. 
            Password = password;
        }

        /// <summary>
        /// Sets an instance of the user equal to null. 
        /// </summary>
        public void LogOutUser()
        {
            Password = string.Empty;
            UserObj = null;
        }

        /// <summary>
        /// Allows to get current active user. 
        /// </summary>
        /// <returns>Instance of User class</returns>
        public User GetUser()
        {
            return UserObj;
        }
        #endregion  // Personal information

        #region Books 
        /// <summary>
        /// Allows to add new book into database. 
        /// </summary>
        /// <param name="name">String value of book's name</param>
        /// <param name="author">String value of book's author</param>
        /// <param name="description">String value of book's description</param>
        public void AddNewBook(string name, string author, string description)
        {
            if (DbHelper == null)
            {
                throw new System.Exception("Database helper is not assigned.");
            }
            if (UserObj == null)
            {
                throw new System.Exception("Non authenticated user cannot add new book.");
            }
            if (UserObj.Books == null)
            {
                throw new System.Exception("List of books is not assigned.");
            }

            // Request for author's information. 
            string insertAuthor = $@"INSERT INTO Authors (AuthorName)
                SELECT ('{author}')
                WHERE (SELECT COUNT(1) FROM Authors WHERE AuthorName = '{author}') = 0;";
            
            // Requests for book's information. 
            string insertBook = $@"INSERT INTO Books (BookName, AuthorIdFK, Description) 
                VALUES (
                    '{name}', 
                    (SELECT AuthorId FROM Authors WHERE AuthorName = '{author}'), 
                    '{description}'
                );";  
            string checkBook = $@"SELECT COUNT (1) FROM Books 
                WHERE BookName = '{name}';";
            
            // Requests for information about users and books. 
            string insertUserBook = $@"INSERT INTO UsersBooks (UserIdFK, BookIdFK) 
                VALUES (
                    (SELECT UserId FROM Users WHERE Fullname = '{UserObj.Fullname}' AND Password = '{Password}'), 
                    (SELECT BookId FROM Books WHERE BookName = '{name}' 
                        AND AuthorIdFK = (SELECT AuthorId 
                            FROM Authors WHERE AuthorName = '{author}')
                    ) 
                );";  
            string checkUserBook = $@"SELECT COUNT (1) FROM UsersBooks 
                WHERE UserIdFK = (
                    SELECT UserId 
                    FROM Users 
                    WHERE Fullname = '{UserObj.Fullname}' AND Password = '{Password}')
                AND BookIdFK = (
                    SELECT BookId 
                    FROM Books 
                    WHERE BookName = '{name}' 
                        AND AuthorIdFK = (SELECT AuthorId FROM Authors WHERE AuthorName = '{author}')
                );";
            
            try
            {
                // Insert all data into database. 
                DbHelper.Insert(insertAuthor);
                DbHelper.Insert(insertBook, checkBook);
                DbHelper.Insert(insertUserBook, checkUserBook);
                int bookId = DbHelper.GetBookId(name);

                // Add a book into list of books. 
                UserObj.Books.Add(new Book(bookId, name, author, description));
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Allows to get all favorite books of the user 
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> GetBookList()
        {
            List<Book> books;
            try
            {
                books = UserObj.Books;
                if (books == null)
                {
                    throw new System.Exception("Unable to get list of books.");
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return books;
        }

        /// <summary>
        /// Allows to initialze list of books inside UserObj 
        /// </summary>
        public void GetBooksFromDb()
        {
            string request = $@"SELECT Books.BookId, Books.BookName, Authors.AuthorName, Books.Description 
                FROM UsersBooks 
                INNER JOIN Books ON UsersBooks.BookIdFK = Books.BookId
                INNER JOIN Authors ON Books.AuthorIdFK = Authors.AuthorId
                WHERE UserIdFK = (
                    SELECT UserId 
                    FROM Users 
                    WHERE Fullname = '{UserObj.Fullname}' AND Password = '{Password}');";
            UserObj.Books = DbHelper.GetBooksFromDb(request);
        }

        public void EditBook()
        {
            // Edit a specified book inside a list and database. 
        }

        public void DeleteBook()
        {
            // Delete a specified book from the list and database.  
        }
        #endregion  // Books

        #region Security
        /// <summary>
        /// Allows to encrypt password 
        /// </summary>
        /// <param name="password">Reference to the string value of password</param>
        /// <returns></returns>
        private void EncryptPassword(ref string password)
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            try
            {
                password = cipher.Monoalphabetic(password);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        #endregion  // Security
    }
}