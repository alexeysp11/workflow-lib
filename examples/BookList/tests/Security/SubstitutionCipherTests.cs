using NUnit.Framework;
using Security.Models; 

namespace Tests.Security.Models
{
    /// <summary>
    /// Allows to test methods of SubstitutionCipher class. 
    /// </summary>
    public class SubstitutionCipherTests
    {
        #region Members
        /// <summary>
        /// Private field for storing an instance of SubstitutionCipher class. 
        /// </summary>
        private SubstitutionCipher cipher; 
        #endregion  // Members

        [SetUp]
        public void Setup()
        {
            cipher = new SubstitutionCipher(); 
        }

        [Test]
        public void Monoalphabetic_StringPassed_OutputIsNotEqualToInput()
        {
            // Assign. 
            string input = "TestingString"; 

            // Act. 
            string output = cipher.Monoalphabetic(input); 

            // Assert. 
            Assert.AreNotEqual(output, input);
        }

        [Test]
        public void Monoalphabetic_StringPassed_OutputIsEqualToExpected()
        {
            // Assign. 
            string input = "TestingString"; 
            string expected = "GrfgvatFgevat"; 

            // Act. 
            string output = cipher.Monoalphabetic(input); 

            // Assert. 
            Assert.AreEqual(output, expected);
        }

        [Test]
        public void Monoalphabetic_StringPassed_InputIsEqualToDecoded()
        {
            // Assign. 
            string input = "TestingString"; 

            // Act. 
            string encoded = cipher.Monoalphabetic(input); 
            string decoded = cipher.Monoalphabetic(encoded); 

            // Assert. 
            Assert.AreEqual(input, decoded);
        }

        [Test]
        public void Monoalphabetic_SameStringPassedTwice_SameOutput()
        {
            // Assign. 
            string input = "StringForTestingMonoalphabetic"; 

            // Act. 
            string output1 = cipher.Monoalphabetic(input); 
            string output2 = cipher.Monoalphabetic(input); 

            // Assert. 
            Assert.AreEqual(output1, output2);
        }

        [Test]
        public void Monoalphabetic_TwoSameStringsPassed_SameOutput()
        {
            // Assign. 
            string input1 = "StringForTestingMonoalphabetic"; 
            string input2 = "StringForTestingMonoalphabetic"; 

            // Act. 
            string output1 = cipher.Monoalphabetic(input1); 
            string output2 = cipher.Monoalphabetic(input2); 

            // Assert. 
            Assert.AreEqual(output1, output2);
        }
        
        [Test]
        public void Monoalphabetic_DifferentStringsPassed_DifferentOutput()
        {
            // Assign. 
            string input1 = "StringForTestingMonoalphabetic"; 
            string input2 = "DiffernetStringForTesting"; 
            string input3 = "AnotherString"; 

            // Act. 
            string output1 = cipher.Monoalphabetic(input1); 
            string output2 = cipher.Monoalphabetic(input2); 
            string output3 = cipher.Monoalphabetic(input3); 

            // Assert. 
            Assert.AreNotEqual(output1, output2);
            Assert.AreNotEqual(output1, output3);
            Assert.AreNotEqual(output2, output3);
        }
    }
}