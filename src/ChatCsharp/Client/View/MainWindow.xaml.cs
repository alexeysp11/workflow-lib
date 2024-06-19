using System.Windows;
using Chat.Client.ViewModel;
using Chat.Client.Exceptions;

namespace Chat.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        static MainWindow()
        {
            Instance = new MainWindow();
        }

        /// <summary>
        /// Private constructor of MainWindow
        /// </summary>
        private MainWindow()
        {
            try
            {
                InitializeComponent();
                DataContext = new MainVM(this); 
            }
            catch (System.Exception e)
            {
                ExceptionViewer.WatchExceptionMessageBox(e); 
            }
        }
    }
}
