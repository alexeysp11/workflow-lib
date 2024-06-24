using System;
using Xunit;
using FuzzyModules.Api; 
using FuzzyModules.Api.Membership; 

namespace Tests.FuzzyModules.Api.Membership 
{
    public class TrapezoidalTest
    {
        [Fact]
        public void Trapezoidal_NullLinguisticVariable_GetException()
        {
            double[] nodes = new double[] { 0.0, 2.0, 4.0, 6.0 }; 
            
            Assert.Throws<Exception>(() => new Trapezoidal(null, nodes));
        }

        [Theory]
        [InlineData(new double[] { 0.0, 2.0, 4.0, 6.0, 7.8 })]
        [InlineData(new double[] { 2.0, 2.0, 4.0 })]
        public void Trapezoidal_IncorrectNumOfNodes_GetException(double[] nodes)
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 

            Assert.Throws<Exception>(() => new Trapezoidal(lingVar, nodes));
        }

        [Theory]
        [InlineData(new double[] { 0.0, 2.0, 4.0, 2.0 })]
        [InlineData(new double[] { 3.0, 2.0, 4.0, 4.0 })]
        [InlineData(new double[] { 0.0, 0.0, 4.0, 3.0 })]
        public void Trapezoidal_IncorrectOrderOfArguments_GetException(double[] nodes)
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 

            Assert.Throws<Exception>(() => new Trapezoidal(lingVar, nodes)); 
        }

        [Theory]
        [InlineData(new double[] { 0.0, 2.0, 2.0, 2.0 })]
        [InlineData(new double[] { 0.0, 0.0, 0.0, 4.0 })]
        public void Trapezoidal_IncorrectInitOfNodes_GetException(double[] nodes)
        {
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 

            Assert.Throws<Exception>(() => new Trapezoidal(lingVar, nodes)); 
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetMembershipDegree_InputOutOfRange_GetException(double input)
        {
            // Given
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 0.0, 2.0, 4.0, 6.0 }; 
            
            // When
            Trapezoidal trapezoidal = new Trapezoidal(lingVar, nodes); 

            // Then
            Assert.Throws<Exception>(() => trapezoidal.GetMembershipDegree(input)); 
        }

        [Theory]
        [InlineData(0, 0.0)]
        [InlineData(1, 0.5)]
        [InlineData(2, 1.0)]
        [InlineData(3, 1.0)]
        [InlineData(4, 1.0)]
        [InlineData(5, 0.5)]
        [InlineData(6, 0.0)]
        public void GetMembershipDegree_PassCorrectArgs_ActualEqualsToExpected(double input, double expected)
        {
            // Given
            LinguisticVariable lingVar = new LinguisticVariable(0, 10, 1); 
            double[] nodes = new double[] { 0.0, 2.0, 4.0, 6.0 }; 
            
            // When
            Trapezoidal trapezoidal = new Trapezoidal(lingVar, nodes); 
            double actual = trapezoidal.GetMembershipDegree(input); 
            
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
            double[] nodes = new double[] { 0.0, 2.0, 4.0, 6.0 }; 
            
            // When
            Trapezoidal trapezoidal = new Trapezoidal(lingVar, nodes); 

            // Then
            Assert.Throws<Exception>(() => trapezoidal.ApplyImplication(ruleValue)); 
        }
    }
}
