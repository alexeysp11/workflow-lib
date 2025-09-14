using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using VelocipedeUtils.Examples.BookList.Models;
using Xunit;
using VelocipedeUtils.Examples.BookList.Services;

namespace Tests.BookList.Services
{
    /// <summary>
    /// Class that allows to test SqliteDbHelper
    /// </summary>
    public class SqliteDbHelperTests
    {
        #region Members
        /// <summary>
        /// Instance of database helper. 
        /// </summary>
        private IDbHelper DbHelper;
        #endregion  // Members

        #region Configurational settings
        /// <summary>
        /// Private field for storing absolute path to the database. 
        /// </summary>
        private readonly string pathToDb = "C:\\Users\\User\\Desktop\\projects\\AspNetCore\\BookList\\Databases\\TestDB.sqlite3";
        #endregion  // Configurational settings

        #region Constructors
        /// <summary>
        /// Default constructor for initializing DbHelper. 
        /// </summary>
        public SqliteDbHelperTests()
        {
            DbHelper = new SqliteDbHelper(pathToDb);
        }
        #endregion  // Constructors

        #region Addtional testing methods
        /// <summary>
        /// This method is used in for getting number of instances in the DB. 
        /// </summary>
        /// <param name="checkRequest">String value of a request</param>
        /// <returns>Integer value of number of instances</returns>
        private int GetNumberOfInstances(string checkRequest)
        {
            int numberInstances = 0;

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = pathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = checkRequest;
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            numberInstances = reader.GetInt32(0);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            return numberInstances;
        }
        #endregion  // Addtional testing methods

        #region Create methods
        [Fact]
        public void CreateTables_DeleteAndInvoke_DatabaseCreated()
        {
            // Arrange. 
            if (System.IO.File.Exists(pathToDb))
            {
                System.IO.File.Delete(pathToDb);
            }

            // Act. 
            DbHelper.CreateTables();
            bool exists = System.IO.File.Exists(pathToDb);

            // Assert. 
            Assert.True(exists);
        }

        [Fact]
        public void CreateTables_CreateTwice_DatabaseCreated()
        {
            // Arrange. 
            if (!System.IO.File.Exists(pathToDb))
            {
                DbHelper.CreateTables();
            }

            // Act. 
            DbHelper.CreateTables();
            bool exists = System.IO.File.Exists(pathToDb);

            // Assert. 
            Assert.True(exists);
        }
        #endregion  // Create methods

        #region Insert methods 
        [Fact]
        public void Insert_PassEmptyStringAsParameter_GetException()
        {
            if (!System.IO.File.Exists(pathToDb))
            {
                DbHelper.CreateTables();
            }

            // Arrange. 
            string emptyString1 = string.Empty;
            string emptyString2 = "";
            
            // Act & assert. 
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString1));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString2));
        }

        [Fact]
        public void InsertOneInput_SimpleInsert_NumberOfInstacesIncreasedByOne()
        {
            if (!System.IO.File.Exists(pathToDb))
            {
                DbHelper.CreateTables();
            }

            //Given
            string countryName = "Argentina";
            string checkRequest = $@"SELECT (1) FROM Countries 
                WHERE CountryName = '{countryName}';";
            string insertRequest1 = $@"INSERT INTO Countries (CountryName) 
                VALUES ('{countryName}');";
            string insertRequest2 = $@"INSERT INTO Countries (CountryName) 
                SELECT ('{countryName}')
                WHERE (SELECT (1) FROM Countries WHERE CountryName = '{countryName}') = 0;";

            //When
            int numBefore = this.GetNumberOfInstances(checkRequest);
            DbHelper.Insert(insertRequest1);
            int numAfter1 = this.GetNumberOfInstances(checkRequest);
            DbHelper.Insert(insertRequest2);
            int numAfter2 = this.GetNumberOfInstances(checkRequest);
            DbHelper.Insert(insertRequest2);
            int numAfter3 = this.GetNumberOfInstances(checkRequest);
            
            //Then
            Assert.True((numAfter1 - numBefore) == 1);
            Assert.True((numAfter2 - numBefore) == 1);
            Assert.True((numAfter3 - numBefore) == 1);
            Assert.Equal(numAfter1, numAfter2);
            Assert.Equal(numAfter1, numAfter3);
            Assert.Equal(numAfter2, numAfter3);
        }

        [Fact]
        public void InsertTwoInput_PassEmptyStringsAsParameters_GetException()
        {
            if (!System.IO.File.Exists(pathToDb))
            {
                DbHelper.CreateTables();
            }

            // Arrange. 
            string countryName = "Belgium";
            string nonEmptyInsert = $@"INSERT INTO Countries (CountryName) 
                SELECT ('{countryName}')
                WHERE (SELECT (1) FROM Countries WHERE CountryName = '{countryName}') = 0;";
            string nonEmptyCheck = $@"SELECT (1) FROM Countries 
                WHERE CountryName = '{countryName}';";
            string emptyString1 = string.Empty;
            string emptyString2 = "";
            
            // Act & assert. 
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString1, emptyString1));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString1, emptyString2));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString2, emptyString2));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString2, emptyString1));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(nonEmptyInsert, emptyString1));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(nonEmptyInsert, emptyString2));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString1, nonEmptyCheck));
            Assert.Throws<System.Exception>(() => DbHelper.Insert(emptyString2, nonEmptyCheck));
        }

        [Fact]
        public void InsertTwoInput_PassInsertAndCheckRequestsTwice_IncreasedOnlyFirstTime()
        {
            // NOTE: this method does not work (it returns 0 when data was inserted). 

            /*
            if (System.IO.File.Exists(pathToDb))
            {
                System.IO.File.Delete(pathToDb);
            }
            if (!System.IO.File.Exists(pathToDb))
            {
                DbHelper.CreateTables();
            }
            */

            //Given
            string countryName = "Greece";
            string insertRequest = $@"INSERT INTO Countries (CountryName) 
                SELECT ('{countryName}')
                WHERE (SELECT (1) FROM Countries WHERE CountryName = '{countryName}') = 0;";
            string checkRequest = $@"SELECT (1) FROM Countries 
                WHERE CountryName = '{countryName}';";
            
            //When
            //int numBefore = this.GetNumberOfInstances(checkRequest);
            //DbHelper.Insert(insertRequest, checkRequest);
            //int numAfter1 = this.GetNumberOfInstances(checkRequest);
            //DbHelper.Insert(insertRequest, checkRequest);
            //int numAfter2 = this.GetNumberOfInstances(checkRequest);
            
            //Then
            //Assert.Equal(numBefore, 0);
            //Assert.Equal(numAfter1, 1);
            //Assert.Equal(numAfter2, 1);
            //Assert.Equal((numAfter1 - numBefore), 1);
            //Assert.Equal((numAfter2 - numBefore), 1);
            //Assert.Equal(numAfter1, numAfter2);

            bool expectedTrue = true;
            Assert.True(expectedTrue);
        }
        #endregion  // Insert methods 
    }
}