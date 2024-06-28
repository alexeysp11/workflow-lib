using System.Collections.Generic; 
using Microsoft.Data.Sqlite; 
using WorkflowLib.Examples.BookList.Models; 

namespace WorkflowLib.Examples.BookList.Services
{
    /// <summary>
    /// Allows to interact with the database. 
    /// </summary>
    public class SqliteDbHelper : IDbHelper
    {
        #region Configuration settings
        /// <summary>
        /// Private field for storing path to the database 
        /// </summary>
        private string AbsolutePathToDb;
        #endregion  // Configuration settings

        #region Constructors
        /// <summary>
        /// Default constructor for SqliteDbHelper
        /// </summary>
        public SqliteDbHelper()
        {
            AbsolutePathToDb = "C:\\Users\\User\\Desktop\\projects\\AspNetCore\\BookList\\Databases\\DB.sqlite3"; 
        }

        /// <summary>
        /// Constuctor for initializing path to the database 
        /// </summary>
        /// <param name="absolutePathToDb">Absolute path to the database</param>
        public SqliteDbHelper(string absolutePathToDb)
        {
            AbsolutePathToDb = absolutePathToDb; 
        }
        #endregion  // Constructors
        
        #region Create methods
        /// <summary>
        /// Method for creating tables in this application 
        /// </summary>
        public void CreateTables()
        {
            // Get request for creating tables in the database.
            string script = System.IO.File.ReadAllText("C:\\Users\\User\\Desktop\\projects\\AspNetCore\\BookList\\BookList.Services\\Source\\CreateTables.sql");

            var connectionStringBuilder = new SqliteConnectionStringBuilder(); 
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open(); 
                    if (System.IO.File.Exists(connectionStringBuilder.DataSource))
                    {
                        var tableCmd = connection.CreateCommand(); 
                        tableCmd.CommandText = script; 
                        tableCmd.ExecuteNonQuery(); 
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
        }
        #endregion  // Create methods

        #region Insert methods 
        /// <summary>
        /// Allows to insert data using insert request 
        /// </summary>
        /// <param name="request">String representation of a request</param>
        public void Insert(string request)
        {
            if (request == string.Empty)
            {
                throw new System.Exception("Request cannot be empty"); 
            }

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insertCmd = connection.CreateCommand(); 
                        insertCmd.CommandText = request;            // SQL command. 
                        insertCmd.ExecuteNonQuery();                // Execute SQL command. 
                        transaction.Commit();                       // Commit changes. 
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Allows to insert data using with foreign key 
        /// </summary>
        /// <param name="insertRequest">String representation of an insert request</param>
        /// <param name="checkRequest">String representation of a check request</param>
        public void Insert(string insertRequest, string checkRequest)
        {
            if (insertRequest == string.Empty || checkRequest == string.Empty)
            {
                throw new System.Exception("Request cannot be empty"); 
            }

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    bool exists = false; 

                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = checkRequest; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) != 0)
                            {
                                exists = true; 
                            }
                        }
                    }

                    if (!exists)
                    {
                        using (var transaction = connection.BeginTransaction())
                        {
                            var insertCmd = connection.CreateCommand(); 
                            insertCmd.CommandText = insertRequest; 
                            insertCmd.ExecuteNonQuery(); 
                            transaction.Commit(); 
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
        #endregion  // Insert methods 

        #region Update methods 
        /// <summary>
        /// Allows to update a table 
        /// </summary>
        /// <param name="request">String representation of an insert request</param>
        public void Update(string request)
        {
            if (request == string.Empty)
            {
                throw new System.Exception("Request cannot be empty. "); 
            }

            try
            {
                Insert(request); 
            }
            catch (System.Exception e)
            {
                throw e; 
            }
        }
        #endregion  // Update methods 

        #region Read methods
        /// <summary>
        /// Checks if an element exists in the database. 
        /// </summary>
        /// <param name="readRequest">Request for reading data</param>
        /// <returns></returns>
        public bool DoesExist(string readRequest)
        {
            if (readRequest == string.Empty)
            {
                throw new System.Exception("Request cannot be empty"); 
            }

            bool exists = false; 
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = readRequest; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) != 0)
                            {
                                exists = true; 
                            }
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
            return exists; 
        }

        /// <summary>
        /// Gets fullname, country and city of the user with SQL request  
        /// </summary>
        /// <param name="fullname">String value of the user's fullname</param>
        /// <param name="country">Output string value of the country</param>
        /// <param name="city">Output string value of the city</param>
        /// <param name="password">String value of the user's password</param>
        public void GetInfoAboutUser(string fullname, out string country, 
            out string city, string password)
        {
            string readRequest = $@"SELECT Users.Fullname, Countries.CountryName, Cities.CityName
                FROM Users
                INNER JOIN Cities ON Users.CityIdFK = Cities.CityId
                INNER JOIN Countries ON Cities.CountryIdFK = Countries.CountryId
                WHERE Users.Fullname = '{fullname}' AND Users.Password = '{password}';"; 

            country = string.Empty; 
            city = string.Empty; 

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = readRequest; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            country = reader.GetString(1); 
                            city = reader.GetString(2);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
        }

        public int GetBookId(string bookName)
        {
            int bookId = 0; 
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = $"SELECT BookId FROM Books WHERE BookName LIKE '{bookName}'"; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookId = reader.GetInt32(0);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
            return bookId; 
        }

        /// <summary>
        /// Allows to get all books for a specific user. 
        /// </summary>
        /// <param name="readRequest">String value of SQL request for reading data from DB</param>
        /// <returns>List of instances of Book class</returns>
        public List<Book> GetBooksFromDb(string readRequest)
        {
            List<Book> books = new List<Book>(); 

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = readRequest; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bookId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string author = reader.GetString(2);
                            string description = reader.GetString(3); 

                            books.Add(new Book(bookId, name, author, description)); 
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
            return books; 
        }
        #endregion  // Read methods
    }
}
