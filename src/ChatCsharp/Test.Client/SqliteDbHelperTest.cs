using NUnit.Framework;
using Chat.Client.Database; 
using Chat.Client.Xml; 

namespace Test.Client
{
    public class SqliteDbHelperTest
    {
        #region Members
        private UserModel TestUser = null; 
        #endregion  // Members

        #region Properties
        /// <summary>
        /// Name of a user
        /// </summary>
        private string Name = "TestUser"; 
        /// <summary>
        /// Email of a user
        /// </summary>
        private string Email = "fake_email@email.com"; 
        /// <summary>
        /// Password of a user
        /// </summary>
        private string Password = "some_password"; 
        /// <summary>
        /// Absolute path to the testing database 
        /// </summary>
        private string TestAbsolutePathToDb; 
        /// <summary>
        /// Path to the XML file that contains absolute path to the test database 
        /// </summary>
        private string PathToXmlFile = "../../../TestLocalDB/DatabasePath.xml"; 
        #endregion  // Properties
        
        [SetUp]
        public void Setup()
        {
            DatabasePath pathObj = XmlHelper.FromXmlFile<DatabasePath>(this.PathToXmlFile);
            this.TestAbsolutePathToDb = pathObj.AbsolutePath; 
            SqliteDbHelper.Instance.AbsolutePathToDb = this.TestAbsolutePathToDb; 
            TestUser = new UserModel(Name, Email, Password); 

            if (System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                System.IO.File.Delete(this.TestAbsolutePathToDb); 
            }
        }

        #region Initialization testing
        [Test]
        public void InitializeUserModel_GetInstance_InstanceIsNotNull()
        {
            Assert.IsNotNull(SqliteDbHelper.Instance); 
        }

        [Test]
        public void InitializeUserModel_GetAbsolutePathToDb_AbsolutePathToDbIsSame()
        {
            Assert.That(TestAbsolutePathToDb, Is.EqualTo(SqliteDbHelper.Instance.AbsolutePathToDb)); 
        }
        #endregion  // Initialization testing

        #region Path testing 
        [Test]
        public void GetPathToDbFromXmlFile_PassPathToXmlFile_AbsolutePathIsTheSame()
        {
            SqliteDbHelper.Instance.GetPathToDbFromXmlFile(this.PathToXmlFile); 
            Assert.That(TestAbsolutePathToDb, Is.EqualTo(SqliteDbHelper.Instance.AbsolutePathToDb)); 
        }
        #endregion  // Path testing 

        #region Create methods testing 
        [Test]
        public void CreateUserTable_NonExistingFile_TableIsCreated()
        {
            // Arrange 
            bool isCreatedBefore = System.IO.File.Exists(SqliteDbHelper.Instance.AbsolutePathToDb); 
            
            // Act
            SqliteDbHelper.Instance.CreateUserTable(); 
            bool isCreatedAfter = System.IO.File.Exists(SqliteDbHelper.Instance.AbsolutePathToDb); 

            // Assert 
            Assert.IsFalse(isCreatedBefore);
            Assert.IsTrue(isCreatedAfter);
        }

        [Test]
        public void CreateUserTable_ExistingFile_TableIsCreated()
        {
            // Arrange 
            bool isCreatedBefore = System.IO.File.Exists(SqliteDbHelper.Instance.AbsolutePathToDb); 
            SqliteDbHelper.Instance.CreateUserTable(); 
            bool isCreatedAfter = System.IO.File.Exists(SqliteDbHelper.Instance.AbsolutePathToDb); 

            // Act
            SqliteDbHelper.Instance.CreateUserTable(); 
            bool isCreatedFinally = System.IO.File.Exists(SqliteDbHelper.Instance.AbsolutePathToDb); 

            // Assert 
            Assert.IsFalse(isCreatedBefore);
            Assert.IsTrue(isCreatedAfter);
            Assert.IsTrue(isCreatedFinally);
        }
        #endregion  // Create method testing 

        #region Insert methods testing 
        [Test]
        public void InsertDataIntoUserTable_InsertTestUser_DataInserted()
        {
            // Arrange 
            SqliteDbHelper.Instance.CreateUserTable(); 

            // Act
            SqliteDbHelper.Instance.InsertDataIntoUserTable(TestUser); 
            bool isAuthenticated = SqliteDbHelper.Instance.IsAuthenticated(TestUser); 

            // Assert 
            Assert.IsTrue(isAuthenticated);
        }
        
        [Test]
        public void InsertDataIntoUserTable_InsertTwice_GetArgumentException()
        {
            // Arrange 
            SqliteDbHelper.Instance.CreateUserTable(); 

            // Act 
            SqliteDbHelper.Instance.InsertDataIntoUserTable(TestUser); 

            // Assert 
            Assert.Catch<System.ArgumentException>(() =>
                SqliteDbHelper.Instance.InsertDataIntoUserTable(TestUser)
            );
        }
        
        [Test]
        public void InsertDataIntoUserTable_InsertNull_GetArgumentNullException()
        {
            // Arrange 
            SqliteDbHelper.Instance.CreateUserTable(); 

            // Assert 
            Assert.Catch<System.ArgumentNullException>(() =>
                SqliteDbHelper.Instance.InsertDataIntoUserTable(null)
            );
        }
        
        [Test]
        public void InsertDataIntoUserTable_InsertIntoNonExistingFile_GotExceptionNotCreatedNotInserted()
        {
            // Arrange 
            bool isExistBefore = System.IO.File.Exists(this.TestAbsolutePathToDb); 
            if (System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                System.IO.File.Delete(this.TestAbsolutePathToDb); 
            }
            bool isExistAfter = System.IO.File.Exists(this.TestAbsolutePathToDb); 

            // Act 
            Assert.Catch<System.Exception>(() =>
                SqliteDbHelper.Instance.InsertDataIntoUserTable(TestUser)
            );
            if (!System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                SqliteDbHelper.Instance.CreateUserTable(); 
            }
            bool isInserted = SqliteDbHelper.Instance.IsAuthenticated(TestUser); 

            // Assert 
            Assert.IsFalse(isExistBefore); 
            Assert.IsFalse(isExistAfter); 
            Assert.IsFalse(isInserted); 
        }
        #endregion  // Insert methods testing 

        #region Authentication methods testing 
        [Test]
        public void IsAuthenticated_PassNull_GotArgumentNullException()
        {
            // Arrange 
            if (!System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                SqliteDbHelper.Instance.CreateUserTable(); 
            }
            bool isExistBefore = System.IO.File.Exists(this.TestAbsolutePathToDb); 

            // Assert
            Assert.IsTrue(isExistBefore); 
            Assert.Catch<System.ArgumentNullException>(() =>
                SqliteDbHelper.Instance.IsAuthenticated(null)
            );
        }

        [Test]
        public void IsAuthenticated_NonExistingFile_GotException()
        {
            // Arrange 
            bool isExistBefore = System.IO.File.Exists(this.TestAbsolutePathToDb); 
            if (System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                System.IO.File.Delete(this.TestAbsolutePathToDb); 
            }
            bool isExistAfter = System.IO.File.Exists(this.TestAbsolutePathToDb); 
            
            // Assert 
            Assert.IsFalse(isExistBefore); 
            Assert.IsFalse(isExistAfter); 
            Assert.Catch<System.Exception>(() =>
                SqliteDbHelper.Instance.IsAuthenticated(TestUser)
            );
        }

        [Test]
        public void IsAuthenticated_PassExistedUser_UserExists()
        {
            // Arrange 
            if (!System.IO.File.Exists(this.TestAbsolutePathToDb))
            {
                SqliteDbHelper.Instance.CreateUserTable(); 
            }
            bool ExistsAfterCreated = System.IO.File.Exists(this.TestAbsolutePathToDb); 
            
            // Act 
            bool isAuthenticatedBeforeInsertion = SqliteDbHelper.Instance.IsAuthenticated(TestUser); 
            SqliteDbHelper.Instance.InsertDataIntoUserTable(TestUser); 
            bool isAuthenticatedAfterInsertion = SqliteDbHelper.Instance.IsAuthenticated(TestUser); 
            bool isExistAfterGetting = System.IO.File.Exists(this.TestAbsolutePathToDb); 
            
            // Assert 
            Assert.IsTrue(ExistsAfterCreated); 
            Assert.IsFalse(isAuthenticatedBeforeInsertion); 
            Assert.IsTrue(isAuthenticatedAfterInsertion); 
            Assert.IsTrue(isExistAfterGetting); 
        }
        #endregion  // Authentication methods testing 
    }
}