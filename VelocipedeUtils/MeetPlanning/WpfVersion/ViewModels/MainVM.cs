using System.Windows;
using System.Windows.Input;
using MeetPlanning.Services;
using MeetPlanning.WpfVersion.Views;
using MeetPlanning.WpfVersion.Commands;
using MeetPlanning.WpfVersion.Models.Languages;

namespace MeetPlanning.WpfVersion.ViewModels
{
    public class MainVM
    {
        public MainWindow MainWindow { get; private set; }

        public ICommand RedirectCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand HelpCommand { get; private set; }

        public IUserRepository UserRepository { get; private set; } = new UserRepository();

        public MainVM(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            
            this.RedirectCommand = new RedirectCommand(this);
            this.ExitCommand = new ExitCommand(this);
            this.HelpCommand = new HelpCommand(this);
        }

        #region Redirection
        public void RedirectToWelcomePage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.HidePagesMenuItem();

            this.MainWindow.WelcomePage.Visibility = Visibility.Visible;
            this.MainWindow.WelcomePage.IsEnabled = true;
        }

        public void RedirectToLoginPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.HidePagesMenuItem();

            this.MainWindow.LoginPage.Visibility = Visibility.Visible;
            this.MainWindow.LoginPage.IsEnabled = true;
        }

        public void RedirectToCreateAccountPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.HidePagesMenuItem();

            this.MainWindow.SignUpPage.Visibility = Visibility.Visible;
            this.MainWindow.SignUpPage.IsEnabled = true;
        }

        public void RedirectToMyAccountPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.ShowPagesMenuItem();

            this.MainWindow.MyAccountPage.Visibility = Visibility.Visible;
            this.MainWindow.MyAccountPage.IsEnabled = true;
        }

        public void RedirectToPartnersPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.ShowPagesMenuItem();

            this.MainWindow.PartnersPage.Visibility = Visibility.Visible;
            this.MainWindow.PartnersPage.IsEnabled = true;
        }

        public void RedirectToMeetingsPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.ShowPagesMenuItem();

            this.MainWindow.MeetingsPage.Visibility = Visibility.Visible;
            this.MainWindow.MeetingsPage.IsEnabled = true;
        }

        public void RedirectToUpcomingEventsPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.ShowPagesMenuItem();

            this.MainWindow.UpcomingEventsPage.Visibility = Visibility.Visible;
            this.MainWindow.UpcomingEventsPage.IsEnabled = true;
        }

        public void RedirectToHistoryPage()
        {
            this.DisableAllPages();
            this.CollapseAllPages();
            this.ShowPagesMenuItem();

            this.MainWindow.HistoryPage.Visibility = Visibility.Visible;
            this.MainWindow.HistoryPage.IsEnabled = true;
        }
        #endregion  // Redirection

        #region Show / hide elements
        private void DisableAllPages()
        {
            this.MainWindow.WelcomePage.IsEnabled = false;
            this.MainWindow.LoginPage.IsEnabled = false;
            this.MainWindow.SignUpPage.IsEnabled = false;

            this.MainWindow.MyAccountPage.IsEnabled = false;
            this.MainWindow.PartnersPage.IsEnabled = false;
            this.MainWindow.MeetingsPage.IsEnabled = false;
            this.MainWindow.UpcomingEventsPage.IsEnabled = false;
            this.MainWindow.HistoryPage.IsEnabled = false;
        }

        private void CollapseAllPages()
        {
            this.MainWindow.WelcomePage.Visibility = Visibility.Collapsed;
            this.MainWindow.LoginPage.Visibility = Visibility.Collapsed;
            this.MainWindow.SignUpPage.Visibility = Visibility.Collapsed;
            
            this.MainWindow.MyAccountPage.Visibility = Visibility.Collapsed;
            this.MainWindow.PartnersPage.Visibility = Visibility.Collapsed;
            this.MainWindow.MeetingsPage.Visibility = Visibility.Collapsed;
            this.MainWindow.UpcomingEventsPage.Visibility = Visibility.Collapsed;
            this.MainWindow.HistoryPage.Visibility = Visibility.Collapsed;
        }

        private void HidePagesMenuItem()
        {
            this.MainWindow.PagesMenuItem.Visibility = Visibility.Collapsed;
            this.MainWindow.PagesMenuItem.IsEnabled = false;
        }

        private void ShowPagesMenuItem()
        {
            this.MainWindow.PagesMenuItem.Visibility = Visibility.Visible;
            this.MainWindow.PagesMenuItem.IsEnabled = true;
        }
        #endregion  // Show / hide elements
    }
}