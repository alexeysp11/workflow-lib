using System.Windows;
using System.Windows.Controls;
using MeetPlanning.WpfVersion.Controllers;

namespace MeetPlanning.WpfVersion.UserControls
{
    public partial class WelcomePage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the WelcomePage.
        /// </summary>
        public WelcomePage()
        {
            InitializeComponent();
        }

        public void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToLoginPage();
        }

        public void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToCreateAccountPage();
        }
    }
}