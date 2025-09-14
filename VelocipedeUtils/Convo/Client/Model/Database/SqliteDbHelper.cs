using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Chat.Client.Xml;

namespace Chat.Client.Database
{
    /// <summary>
    /// Allows to use SQLite database 
    /// </summary>
    public class SqliteDbHelper
    {
        public static SqliteDbHelper Instance { get; private set; } 

        #region Properties
        /// <summary>
        /// Request for creating the User table 
        /// </summary>
        private string CreateUserTableRequest = @"CREATE TABLE IF NOT EXISTS Users(
            Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
            Name TEXT,
            Email TEXT,
            Password TEXT)";

        private string absolutePathToDb;
        public string AbsolutePathToDb
        {
            get { return absolutePathToDb; }
            set { absolutePathToDb = value; }
        }
        #endregion  // Properties

        #region Constructors
        static SqliteDbHelper()
        {
            Instance = new SqliteDbHelper();
        }

        private SqliteDbHelper() { }
        #endregion  // Constructors

        #region Getting path
        /// <summary>
        /// Method that is used for getting absolute path of the database from XML file
        /// </summary>
        /// <param name="path">String value of a path to the database</param>
        public void GetPathToDbFromXmlFile(string path="Client/Model/LocalDB/DatabasePath.xml")
        {
            try
            {
                DatabasePath pathObj = XmlHelper.FromXmlFile<DatabasePath>(path);
                this.AbsolutePathToDb = pathObj.AbsolutePath;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion  // Getting path

        #region Methods for User table
        public void CreateUserTable()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = this.AbsolutePathToDb;
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    if (System.IO.File.Exists(connectionStringBuilder.DataSource))
                    {
                        var tableCmd = connection.CreateCommand();
                        tableCmd.CommandText = CreateUserTableRequest;
                        tableCmd.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void InsertDataIntoUserTable(UserModel user)
        {
            if (user == null)
            {
                throw new System.ArgumentNullException(nameof(user), "User should not be null");
            }

            try
            {
                if (!System.IO.File.Exists(this.AbsolutePathToDb))
                {
                    throw new System.Exception($"Exception while inserting data into database. File {this.AbsolutePathToDb} does not exist");
                }
                if (this.IsAuthenticated(user))
                {
                    throw new System.ArgumentException($"User {user.Name} already exists in the database");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
            string insertRequest = $@"INSERT INTO Users (Name, Email, Password)
                VALUES ('{user.Name}', '{user.Email}', '{user.Password}')";

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = this.AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = insertRequest;      // SQL command. 
                        insertCmd.ExecuteNonQuery();                // Execute SQL command. 
                        transaction.Commit();                       // Commit changes. 
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Allows to make request to the database and get if user exists in database 
        /// </summary>
        /// <param name="user">Instance of UserModel that consists all fields of user</param>
        /// <returns>
        /// True if user with such name and password exists in the database. 
        /// False if user with such name and password does not exist in the database
        /// </returns>
        public bool IsAuthenticated(UserModel user)
        {
            if (user == null)
            {
                throw new System.ArgumentNullException(nameof(user), "User should not be null");
            }
            if (!System.IO.File.Exists(this.AbsolutePathToDb))
            {
                throw new System.Exception($"Exception while getting data from database. File {this.AbsolutePathToDb} does not exist");
            }

            string request = $@"SELECT Name, Password FROM Users";

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = this.AbsolutePathToDb;
            
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = request;
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == user.Name && reader.GetString(1) == user.Password)
                            {
                                return true;
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }
        #endregion  // Methods for User table
    }
}