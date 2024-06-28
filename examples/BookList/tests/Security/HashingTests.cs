using NUnit.Framework;
using Security.Models; 

namespace Tests.Security.Models
{
    /// <summary>
    /// Allows to test methods of Hashing class. 
    /// </summary>
    public class HashingTests 
    {
        #region Members
        /// <summary>
        /// Private field for storing an instance of Hashing class. 
        /// </summary>
        private Hashing hashing; 
        #endregion  // Members

        #region Values for authentication
        /// <summary>
        /// Username for authentication tesitng using hash function. 
        /// </summary>
        private string username = "TestUser"; 
        /// <summary>
        /// Password for authentication tesitng using hash function
        /// </summary>
        private string password = "TestPassword"; 
        #endregion  // Values for authentication

        [SetUp]
        public void Setup()
        {
            hashing = new Hashing(); 
        }

        [Test]
        public void HashFunc_SameUsernameSamePasswordMultipleTimes_SameOutput()
        {
            // Assign. 
            string sameUsername = username; 
            string samePassword = password; 

            // Act. 
            string output1 = hashing.HashFunc(username, password); 
            string output2 = hashing.HashFunc(username, password); 
            string output3 = hashing.HashFunc(sameUsername, samePassword); 
            string output4 = hashing.HashFunc(username, samePassword); 
            string output5 = hashing.HashFunc(sameUsername, password); 

            // Assert. 
            Assert.AreEqual(output1, output2);
            Assert.AreEqual(output1, output3);
            Assert.AreEqual(output1, output4);
            Assert.AreEqual(output1, output5);
            Assert.AreEqual(output2, output3);
            Assert.AreEqual(output2, output4);
            Assert.AreEqual(output2, output5);
            Assert.AreEqual(output3, output4);
            Assert.AreEqual(output3, output5);
            Assert.AreEqual(output4, output5);
        }

        [Test]
        public void HashFunc_SameUsernameDifferentPassword_DifferentOutput()
        {
            // Assign. 
            string wrongPassword1 = "StringForTestingHashFunc1"; 
            string wrongPassword2 = $"{password}SomeAddition"; 

            // Act. 
            string output1 = hashing.HashFunc(username, username); 
            string output2 = hashing.HashFunc(username, wrongPassword1); 
            string output3 = hashing.HashFunc(username, wrongPassword2); 

            // Assert. 
            Assert.AreNotEqual(output1, output2);
            Assert.AreNotEqual(output1, output3);
            Assert.AreNotEqual(output2, output3);
        }
    }
}