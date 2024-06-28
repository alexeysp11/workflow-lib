using System;
using Xunit;
using WorkflowLib.Examples.BookList.Services; 

namespace Tests.BookList.Services
{
    public class UserRepositoryTests
    {
        #region Members
        /// <summary>
        /// Instance of database helper. 
        /// </summary>
        private IDbHelper DbHelper; 
        /// <summary>
        /// Instance of UserRepository class. 
        /// </summary>
        private IUserRepository _UserRepository; 
        #endregion  // Members

        #region Configurational settings
        /// <summary>
        /// Private field for storing absolute path to the database. 
        /// </summary>
        private readonly string pathToDb = "C:\\Users\\User\\Desktop\\projects\\AspNetCore\\BookList\\Databases\\TestDB.sqlite3"; 
        #endregion  // Configurational settings

        #region Create 
        [Fact]
        public void Initialized_CheckIfDatabaseExists_DatabaseExists()
        {
            // Arrange. 
            DbHelper = new SqliteDbHelper(pathToDb); 
            _UserRepository = new UserRepository(DbHelper);

            // Act. 
            bool exists = System.IO.File.Exists(pathToDb); 

            // Assert. 
            Assert.True(exists); 
        }

        [Fact]
        public void CreateUser_Invoke_UserExistsInDatabase()
        {
            //Given
            DbHelper = new SqliteDbHelper(pathToDb); 
            _UserRepository = new UserRepository(DbHelper);
            
            string fullname = "Mark"; 
            string country = "USA"; 
            string city = "Portland"; 
            string password = "TestPassword"; 
            
            //When
            _UserRepository.CreateUser(fullname, country, city, password); 
            bool exists = _UserRepository.DoesExist(fullname, password);
            
            //Then
            Assert.True(exists); 
        }
        #endregion  // Create 
    }
}
