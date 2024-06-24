using System.Collections.Generic; 

namespace FuzzyModules.Api
{
    public class Defuzzification
    {
        private double[] MfDegree; 

        public Defuzzification(double[] mfDegree)
        {
            for (int i = 0; i < mfDegree.Length; i++)
            {
                if (mfDegree[i] > 1 || mfDegree[i] < 0)
                {
                    throw new System.Exception($"Error while defuzzification: all values of the membership function should range from 0 to 1 ({i}-th element is equal to {mfDegree[i]})"); 
                }
            }
            MfDegree = mfDegree; 
        }

        public double MeanOfMaximum()
        {
            double max = FindMaxValue(); 

            List<int> indexesMax = new List<int>(); 
            for (int i = 0; i < MfDegree.Length; i++)
            {
                if (MfDegree[i] == max)
                {
                    indexesMax.Add(i); 
                }
            }

            double sum = 0; 
            foreach (int index in indexesMax)
            {
                sum += index; 
            }

            return sum / indexesMax.Count; 
        }

        public double FirstOfMaximum()
        {
            throw new System.NotImplementedException(); 
        }

        public double LastOfMaximum()
        {
            throw new System.NotImplementedException(); 
        }

        public double Centroid()
        {
            throw new System.NotImplementedException();
        }

        public double Bisector()
        {
            throw new System.NotImplementedException();
        }

        private double FindMaxValue()
        {
            double max = 0; 
            for (int i = 0; i < MfDegree.Length; i++)
            {
                if (max < MfDegree[i])
                {
                    max = MfDegree[i]; 
                }
            }
            return max; 
        }
    }
}