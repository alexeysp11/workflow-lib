using System;
using Xunit;
using FuzzyModules.Api; 

namespace Tests.FuzzyModules.Api 
{
    public class DefuzzificationTest
    {
        [Theory]
        [InlineData(new double[] { 0.5, 1.0, 1.1, 1.0, 0.5, 0.5, 0.0 })]
        [InlineData(new double[] { 0.5, 1.0, 5.8, 1.0, 0.5, 0.5, 0.0 })]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, -0.5, 0.5, 0.0 })]
        [InlineData(new double[] { -0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.0 })]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.0, 1.5 })]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.0, -1.5 })]
        public void Defuzzification_ElementsAreOutOfRange_GetException(double[] mfDegree)
        {
            Assert.Throws<Exception>(() => new Defuzzification(mfDegree));
        }

        [Theory]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.0, 1.0, 1.0, 1.0, 0.0, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.0, 1.0, 1.0, 1.0, 0.5, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, 0.0, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.5, 0.9, 0.9, 0.9, 0.5, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.5, 0.8, 0.8, 0.8, 0.5, 0.5, 0.0 }, 2)]
        [InlineData(new double[] { 0.5, 1.0, 1.0, 1.0, 0.5, 1.0, 0.0 }, 2.75)]
        [InlineData(new double[] { 0.5, 0.8, 0.8, 0.8, 0.5, 0.8, 0.0 }, 2.75)]
        public void MeanOfMaximum_MultipleInputs_OutputEqualsToExpected(double[] mfDegree, double expected)
        {
            var defuzz = new Defuzzification(mfDegree); 
            double defuzzValue = defuzz.MeanOfMaximum(); 
            
            Assert.Equal(expected, defuzzValue); 
        }
    }
}