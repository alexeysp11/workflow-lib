using NUnit.Framework;
using Chat.Client.Database; 

namespace Test.Client
{
    /// <summary>
    /// Test intended for getting if UserModel is initialized correctly  
    /// </summary>
    public class UserModelTest
    {
        #region Members
        /// <summary>
        /// Instance of a class UserModel that is going to be tested 
        /// </summary>
        UserModel User = null; 
        #endregion  // Members

        #region Properties
        /// <summary>
        /// Name of a user
        /// </summary>
        string Name = "User"; 
        /// <summary>
        /// Email of a user
        /// </summary>
        string Email = "fake_email@email.com"; 
        /// <summary>
        /// Password of a user
        /// </summary>
        string Password = "some_password"; 
        #endregion  // Properties

        [SetUp]
        public void Setup()
        {
            User = new UserModel(Name, Email, Password); 
        }
        
        [Test]
        public void InitializeUserModel_PassParametersIntoConstructor_InstanceIsNotNull()
        {
            Assert.IsNotNull(User); 
        }

        [Test]
        public void InitializeUserModel_PassParametersIntoConstructor_GetSameValuesFromPublicProperties()
        {
            Assert.That(Name, Is.EqualTo(User.Name)); 
            Assert.That(Email, Is.EqualTo(User.Email)); 
            Assert.That(Password, Is.EqualTo(User.Password)); 
        }
    }
}