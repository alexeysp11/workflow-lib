namespace MeetPlanning.WpfVersion.Models.Languages
{
    public class English : ILanguage
    {
        public string GetHelpLabel()
        {
            return "Help"; 
        }

        #region Buttons 
        public string GetLoginBtnLabel()
        {
            return "Login"; 
        }

        public string GetCreateAccountBtnLabel()
        {
            return "Create account"; 
        }

        public string GetFindBtnLabel()
        {
            return "Find"; 
        }

        public string GetClearBtnLabel()
        {
            return "Clear"; 
        }

        public string GetShowAllBtnLabel()
        {
            return "ShowAll"; 
        }
        #endregion  // Buttons 
    }
}