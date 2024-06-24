namespace MeetPlanning.WpfVersion.Models.Languages
{
    public class Russian : ILanguage
    {
        public string GetHelpLabel()
        {
            return "Помощь"; 
        }

        #region Buttons 
        public string GetLoginBtnLabel()
        {
            return "Войти"; 
        }

        public string GetCreateAccountBtnLabel()
        {
            return "Регистрация"; 
        }

        public string GetFindBtnLabel()
        {
            return "Найти"; 
        }

        public string GetClearBtnLabel()
        {
            return "Очистить"; 
        }

        public string GetShowAllBtnLabel()
        {
            return "Все записи"; 
        }
        #endregion  // Buttons 
    }
}