using FuzzyModules.Api.Membership; 

namespace FuzzyModules.Api
{
    public class LinguisticVariable
    {
        public double StartPoint { get; private set; } 
        public double EndPoint { get; private set; } 
        public double Step { get; private set; } 

        public double[] MfDegree { get; private set; } 

        public LinguisticVariable(double start, double end, double step)
        {
            if (start >= end)
            {
                throw new System.Exception("Error while initializing LinguisticVariable: start point should be greater than end point"); 
            }
            if (step <= 0)
            {
                throw new System.Exception("Error while initializing LinguisticVariable: step should be greater than 0"); 
            }

            StartPoint = start; 
            EndPoint = end; 
            Step = step; 

            int size = (int)((EndPoint - StartPoint) / Step); 
            MfDegree = new double[size]; 
        }

        public void AggregateTerms(double[] mfDegree)
        {
            if (MfDegree.Length != mfDegree.Length)
            {
                throw new System.Exception("Error while applying aggregation: sizes of arrays are not the same"); 
            }

            for (int i = 0; i < MfDegree.Length; i++)
            {
                MfDegree[i] = (mfDegree[i] > MfDegree[i]) ? mfDegree[i]: MfDegree[i]; 
            }
        }

        public void PrintMfDegrees()
        {
            System.Console.WriteLine("PrintMfDegrees:");
            for (int i = 0; i < MfDegree.Length; i++)
            {
                System.Console.Write($"{MfDegree[i]} "); 
            }
            System.Console.WriteLine("");
        }

        public double Defuzzify(string method)
        {
            double output = 0; 
            if (method == "MeOM")
            {
                var defuzz = new Defuzzification(MfDegree);
                output = defuzz.MeanOfMaximum(); 
            }
            else if (method == "FOM")
            {
                var defuzz = new Defuzzification(MfDegree);
                output = defuzz.FirstOfMaximum(); 
            }
            else if (method == "LOM")
            {
                var defuzz = new Defuzzification(MfDegree);
                output = defuzz.LastOfMaximum(); 
            }
            else if (method == "Centroid")
            {
                var defuzz = new Defuzzification(MfDegree);
                output = defuzz.Centroid(); 
            }
            else if (method == "Bisector")
            {
                var defuzz = new Defuzzification(MfDegree);
                output = defuzz.Bisector(); 
            }
            else
            {
                throw new System.Exception("Error while defuzzification: incorrect defuzzification method");
            }
            return output; 
        }
    }
}
