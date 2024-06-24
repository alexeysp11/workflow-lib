namespace FuzzyModules.Api.Membership
{
    public interface IOutputVariable 
    {
        void ApplyImplication(double ruleValue); 
        void Aggregate(); 
    }
}