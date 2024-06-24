using System;
using Xunit;
using FuzzyModules.Api; 

namespace Tests.FuzzyModules.Api 
{
    public class LinguisticVariableTest
    {
        [Theory]
        [InlineData(9, 7, 1)]
        [InlineData(7, 7, 1)]
        [InlineData(7, 9, 0)]
        [InlineData(7, 9, -1)]
        public void LinguisticVariable_WrongInitParameters_GetException(double start, 
            double end, double step)
        {
            Assert.Throws<Exception>(() => new LinguisticVariable(start, end, step));
        }
        
        [Fact]
        public void AggregateTerms_ArraySizesAreNotTheSame_GetException()
        {
            double start = 0; 
            double end = 10; 
            double step = 1; 

            double[] mfDegree = new double[] { 0.5, 1.0, 1.1, 1.0, 0.5, 0.5 }; 
            
            var lingVar = new LinguisticVariable(start, end, step); 
            Assert.Throws<Exception>(() => lingVar.AggregateTerms(mfDegree));
        }

        [Fact]
        public void AggregateTerms_CorrectArrays_OutputIsEqualToFirst()
        {
            // Given
            double start = 0; 
            double end = 6; 
            double step = 1; 

            double[] mfDegree = new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 0.5 }; 
            
            // When
            var lingVar = new LinguisticVariable(start, end, step); 
            lingVar.AggregateTerms(mfDegree); 
            
            // Then
            Assert.Equal(mfDegree, lingVar.MfDegree); 
        }

        [Fact]
        public void AggregateTerms_InvokeTwice_OutputIsEqualToExpected()
        {
            // Given
            double start = 0; 
            double end = 6; 
            double step = 1; 

            double[] mfDegree01 = new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 0.5 }; 
            double[] mfDegree02 = new double[] { 0.8, 0.6, 0.3, 0.5, 0.8, 1.0 }; 
            double[] expectedMf = new double[] { 0.8, 1.0, 1.0, 1.0, 0.8, 1.0 }; 
            
            // When
            var lingVar = new LinguisticVariable(start, end, step); 
            lingVar.AggregateTerms(mfDegree01); 
            lingVar.AggregateTerms(mfDegree02); 

            // Then
            Assert.Equal(expectedMf, lingVar.MfDegree); 
        }
    }
}