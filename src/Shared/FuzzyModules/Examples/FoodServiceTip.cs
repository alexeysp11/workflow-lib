using System; 
using FuzzyModules.Api; 
using FuzzyModules.Api.Membership; 

namespace FuzzyModules.Examples
{
    public class FoodServiceTip
    {
        #region Linguistic terms 
        private IInputVarable serivcePoor; 
        private IInputVarable serviceGood; 
        private IInputVarable serviceExcellent; 
        
        private IInputVarable foodRancid; 
        private IInputVarable foodDelicious; 
        
        private IOutputVariable tipCheap; 
        private IOutputVariable tipAverage; 
        private IOutputVariable tipGererous; 
        #endregion  // Linguistic terms 

        #region Linguistic variables 
        private LinguisticVariable service; 
        private LinguisticVariable food; 
        private LinguisticVariable tip; 
        #endregion  // Linguistic variables 

        #region Private fields 
        private double inputService; 
        private double inputFood; 

        private double serivcePoorMfDegree; 
        private double serviceGoodMfDegree; 
        private double serviceExcellentMfDegree; 
        private double foodRancidMfDegree; 
        private double foodDeliciousMfDegree; 

        private double outputTip; 
        #endregion  // Private fields 
        
        public void Run()
        {
            System.Console.WriteLine("Tipping problem (Mamdani algorithm)");

            DefineLinguisticVariables(); 
            DefineTerms(); 
            
            SetInputs(); 
            GetMembershipDegrees(); 
            DefineRuleBase(); 
            
            ApplyAggregation(); 
            GetCrispValues(); 

            System.Console.ReadLine();
        }

        private void DefineLinguisticVariables()
        {
            service = new LinguisticVariable(0, 10, 1); 
            food = new LinguisticVariable(0, 10, 1); 
            tip = new LinguisticVariable(0, 10, 1); 
        }

        private void DefineTerms()
        {
            serivcePoor = new Trapezoidal(service, new double[] {0, 0, 2, 4}); 
            serviceGood = new Trapezoidal(service, new double[] {2, 4, 6, 8}); 
            serviceExcellent = new Trapezoidal(service, new double[] {6, 8, 10, 10}); 

            foodRancid = new Trapezoidal(food, new double[] {0, 0, 2, 4}); 
            foodDelicious = new Trapezoidal(food, new double[] {6, 8, 10, 10}); 

            tipCheap = new Triangular(tip, new double[] {0, 2, 4}); 
            tipAverage = new Triangular(tip, new double[] {3, 5, 7}); 
            tipGererous = new Triangular(tip, new double[] {6, 7, 10}); 
        }

        private void SetInputs()
        {
            inputService = 3; 
            inputFood = 8; 

            System.Console.WriteLine($"inputService: {inputService}");
            System.Console.WriteLine($"inputFood: {inputFood}");
        }

        private void GetMembershipDegrees()
        {
            serivcePoorMfDegree = serivcePoor.GetMembershipDegree(inputService); 
            serviceGoodMfDegree = serviceGood.GetMembershipDegree(inputService); 
            serviceExcellentMfDegree = serviceExcellent.GetMembershipDegree(inputService); 

            foodRancidMfDegree = foodRancid.GetMembershipDegree(inputFood); 
            foodDeliciousMfDegree = foodDelicious.GetMembershipDegree(inputFood); 
        }

        private void DefineRuleBase()
        {
            double activeRule1 = Math.Max(serivcePoorMfDegree, foodRancidMfDegree); 
            double activeRule2 = serviceGoodMfDegree; 
            double activeRule3 = Math.Max(serviceExcellentMfDegree, foodDeliciousMfDegree);

            tipCheap.ApplyImplication(activeRule1); 
            tipAverage.ApplyImplication(activeRule2); 
            tipGererous.ApplyImplication(activeRule3); 
        }

        private void ApplyAggregation()
        {
            tipCheap.Aggregate(); 
            tipAverage.Aggregate(); 
            tipGererous.Aggregate(); 
        }

        private void GetCrispValues()
        {
            double crispTip = tip.Defuzzify("MeOM"); 
            System.Console.WriteLine($"Tip: {crispTip}");
        }
    }
}