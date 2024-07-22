namespace WorkflowLib.Shared.FuzzyModules.API.Membership
{
    public interface IOutputVariable 
    {
        void ApplyImplication(double ruleValue);
        void Aggregate();
    }
}