using System.Windows;
using System.Windows.Controls;
using MeetPlanning.WpfVersion.Controllers;

namespace MeetPlanning.WpfVersion.UserControls
{
    public partial class SignUpPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the SignUpPage.
        /// </summary>
        public SignUpPage()
        {
            InitializeComponent();
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToWelcomePage();
        }

        public void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            WpfController.RedirectToLoginPage();
        }
    }
}