using System;
using Xunit;
using FuzzyModules.Api; 
using FuzzyModules.Api.Membership; 

namespace Tests.FuzzyModules.Api.Membership 
{
    public class TriangularTest
    {
        [Fact]
        public void Triangular_NullLinguisticVariable_GetException()
        {
            double[] nodes = new double[] { 0.0, 2.0, 4.0 }; 
            
            Assert.Throws<Exception>(() => new Triangular(null, nodes));
        }

        [Theory]
        [InlineData(new double[] { 0.0, 2.0, 0.0 })]
        [InlineData(new double[] { 4.0, 2.0, 4.0 })]
        [InlineData(new double[] { 4.0, 2.0, 0.0 })]
        public void Triangular_IncorrectOrderOfArguments_GetException(double[] nodes)
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 

            Assert.Throws<Exception>(() => new Triangular(lingVar, nodes)); 
        }

        [Theory]
        [InlineData(new double[] { 0.0, 2.0 })]
        [InlineData(new double[] { 0.0, 2.0, 4.0, 5.0 })]
        public void Triangular_IncorrectNumOfNodes_GetException(double[] nodes)
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            
            Assert.Throws<Exception>(() => new Triangular(lingVar, nodes)); 
        }

        [Fact]
        public void Triangular_IncorrectInitOfNodes_GetException()
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 2.0, 2.0, 2.0 }; 
            
            Assert.Throws<Exception>(() => new Triangular(lingVar, nodes)); 
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetMembershipDegree_InputOutOfRange_GetException(double input)
        {
            // Given
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 2.0, 4.0, 6.0 }; 
            
            // When
            Triangular triangular = new Triangular(lingVar, nodes); 

            // Then
            Assert.Throws<Exception>(() => triangular.GetMembershipDegree(input)); 
        }

        [Theory]
        [InlineData(0, 0.0)]
        [InlineData(1, 0.0)]
        [InlineData(2, 0.0)]
        [InlineData(3, 0.5)]
        [InlineData(4, 1.0)]
        [InlineData(5, 0.5)]
        [InlineData(6, 0.0)]
        [InlineData(7, 0.0)]
        public void GetMembershipDegree_PassCorrectArgs_ActualEqualsToExpected(double input, double expected)
        {
            // Given
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 2.0, 4.0, 6.0 }; 
            
            // When
            Triangular triangular = new Triangular(lingVar, nodes); 
            double actual = triangular.GetMembershipDegree(input); 
            
            // Then
            Assert.Equal(expected, actual); 
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.3)]
        [InlineData(1.1)]
        public void ApplyImplication_ValueOutOfRange_GetException(double ruleValue)
        {
            // Given
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 2.0, 4.0, 6.0 }; 
            
            // When
            Triangular triangular = new Triangular(lingVar, nodes); 

            // Then
            Assert.Throws<Exception>(() => triangular.ApplyImplication(ruleValue)); 
        }
    }
}