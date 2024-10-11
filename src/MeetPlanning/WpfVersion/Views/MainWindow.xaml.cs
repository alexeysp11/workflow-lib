using System.Windows;
using MeetPlanning.WpfVersion.Controllers;
using MeetPlanning.WpfVersion.ViewModels;

namespace MeetPlanning.WpfVersion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainVM mainVM = new MainVM(this);
            DataContext = mainVM;
            WpfController.SetMainVM(mainVM);

            WpfController.RedirectToWelcomePage();
        }
    }
}
