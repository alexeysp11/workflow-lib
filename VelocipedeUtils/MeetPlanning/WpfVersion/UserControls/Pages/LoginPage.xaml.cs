using System.Windows;
using System.Windows.Controls;
using MeetPlanning.WpfVersion.Controllers;

namespace MeetPlanning.WpfVersion.UserControls
{
    public partial class LoginPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the LoginPage.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToWelcomePage();
        }

        public void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToMyAccountPage();
        }
    }
}