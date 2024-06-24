namespace FuzzyModules.Api.Membership
{
    public class Trapezoidal : IInputVarable, IOutputVariable
    {
        private LinguisticVariable LingVar; 

        private double SupportStart; 
        private double CoreStart; 
        private double CoreEnd; 
        private double SupportEnd; 

        private double RuleValue = 1; 

        public Trapezoidal(LinguisticVariable lingVar, double[] nodes)
        {
            if (lingVar == null)
            {
                throw new System.Exception("Error while initializing Trapezoidal: LinguisticVariable should not be null"); 
            }
            if (nodes.Length != 4)
            {
                throw new System.Exception("Error while initializing Trapezoidal: number of nodes should be equal to 4 for trapezoidal membership function"); 
            }
            if (nodes[0] > nodes[1] || nodes[1] > nodes[2] || nodes[2] > nodes[3])
            {
                throw new System.Exception("Error while initializing Trapezoidal: next element cannot be less than previous one"); 
            }
            else if (nodes[0] == nodes[2] || nodes[1] == nodes[3])
            {
                throw new System.Exception($"Error while initializing Trapezoidal: nodes ({nodes[0]} and {nodes[2]} or {nodes[1]} and {nodes[3]}) should not be the same"); 
            }

            LingVar = lingVar; 

            SupportStart = nodes[0]; 
            CoreStart = nodes[1]; 
            CoreEnd = nodes[2]; 
            SupportEnd = nodes[3]; 
        }

        public double GetMembershipDegree(double input)
        {
            if (input < LingVar.StartPoint || input > LingVar.EndPoint)
            {
                throw new System.Exception("Error while getting membership degree: value is out of bounds"); 
            }

            double output = 0; 
            if (input >= CoreStart && input <= CoreEnd)
            {
                output = 1; 
            }
            else
            {
                output = GetProperFraction(input); 
            }
            return output; 
        }
        
        public void ApplyImplication(double ruleValue)
        {
            if (ruleValue < 0 || ruleValue > 1)
            {
                throw new System.Exception("Error while aplying implication: value cannot be greater than 1"); 
            }
            RuleValue = ruleValue; 
        }

        public void Aggregate()
        {
            double[] mfDegree = GetMfDegree(); 
            LingVar.AggregateTerms(mfDegree); 
        }

        private double GetProperFraction(double input)
        {
            double output = 0; 
            if (input > SupportStart && input < CoreStart)
            {
                output = (1 - 0)/(CoreStart - SupportStart)*(input - SupportStart); 
            }
            if (input > CoreEnd && input < SupportEnd)
            {
                output = (0 - 1)/(SupportEnd - CoreEnd)*(input - CoreEnd) + 1; 
            }
            
            if (output < 0 || output > 1)
            {
                throw new System.Exception($"Value {output} is not a proper fraction"); 
            }
            return output; 
        }

        private double[] GetMfDegree()
        {
            int size = (int)((LingVar.EndPoint - LingVar.StartPoint) / LingVar.Step); 
            double[] mfDegree = new double[size]; 
            
            int i = 0; 
            for (double x = LingVar.StartPoint; x <= LingVar.EndPoint; x = x + LingVar.Step)
            {
                mfDegree[i] = GetMembershipDegree(x); 
                i++; 
            }
            return mfDegree; 
        }
    }
}