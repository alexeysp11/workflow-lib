using MeetPlanning.WpfVersion.ViewModels; 

namespace MeetPlanning.WpfVersion.Controllers
{
    public static class WpfController
    {
        private static MainVM MainVM = null; 

        public static void SetMainVM(MainVM mainVM)
        {
            MainVM = mainVM; 
        }

        public static void RedirectToWelcomePage()
        {
            MainVM.RedirectToWelcomePage(); 
        }

        public static void RedirectToLoginPage()
        {
            MainVM.RedirectToLoginPage(); 
        }

        public static void RedirectToCreateAccountPage()
        {
            MainVM.RedirectToCreateAccountPage(); 
        }

        public static void RedirectToMyAccountPage()
        {
            MainVM.UserRepository.IsAuthenticated = true; 
            MainVM.RedirectToMyAccountPage(); 
        }
    }
}