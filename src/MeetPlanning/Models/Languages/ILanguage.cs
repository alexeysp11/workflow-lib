namespace MeetPlanning.WpfVersion.Models.Languages
{
    public interface ILanguage
    {
        string GetHelpLabel(); 

        string GetLoginBtnLabel(); 
        string GetCreateAccountBtnLabel(); 

        string GetFindBtnLabel(); 
        string GetClearBtnLabel(); 
        string GetShowAllBtnLabel(); 
    }
}