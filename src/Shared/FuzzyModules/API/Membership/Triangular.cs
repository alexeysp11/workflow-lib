namespace FuzzyModules.Api.Membership
{
    public class Triangular : IInputVarable, IOutputVariable
    {
        private LinguisticVariable LingVar; 

        private double StartVertex; 
        private double UpperVertex; 
        private double EndVertex; 

        private double RuleValue = 1; 

        public Triangular(LinguisticVariable lingVar, double[] nodes)
        {
            if (lingVar == null)
            {
                throw new System.Exception("Error while initializing Triangular: LinguisticVariable should not be null"); 
            }
            if (nodes.Length != 3)
            {
                throw new System.Exception("Error while initializing Triangular: number of nodes should be equal to 3 for triangular membership function"); 
            }
            if (nodes[0] > nodes[1] || nodes[1] > nodes[2])
            {
                throw new System.Exception("Error while initializing Triangular: incorrect order of nodes"); 
            }
            else if (nodes[0] == nodes[2])
            {
                throw new System.Exception($"Error while initializing Triangular: nodes ({nodes[0]} and {nodes[2]}) should not be the same"); 
            }

            LingVar = lingVar; 

            StartVertex = nodes[0]; 
            UpperVertex = nodes[1]; 
            EndVertex = nodes[2]; 
        }

        public double GetMembershipDegree(double input)
        {
            if (input < LingVar.StartPoint || input > LingVar.EndPoint)
            {
                throw new System.Exception("Error while getting membership degree: value is out of bounds"); 
            }

            double output = 0; 
            if (input == UpperVertex)
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
            if (input > StartVertex && input < UpperVertex)
            {
                output = (1 - 0)/(UpperVertex - StartVertex)*(input - StartVertex); 
            }
            if (input > UpperVertex && input < EndVertex)
            {
                output = (0 - 1)/(EndVertex - UpperVertex)*(input - UpperVertex) + 1; 
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
            for (double x = LingVar.StartPoint; x < LingVar.EndPoint; x = x + LingVar.Step)
            {
                mfDegree[i] = GetMembershipDegree(x); 
                i++; 
            }
            return mfDegree; 
        }
    }
}