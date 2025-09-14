using System.Windows;
using VelocipedeUtils.Examples.HcsBudget.ViewModels;

namespace VelocipedeUtils.Examples.HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                MainVM mainVm = new MainVM(this);
                
                DataContext = mainVm;
                this.Months.DataContext = mainVm;
                this.DataIn.DataContext = mainVm;
                this.DataOut.DataContext = mainVm;
                this.Report.DataContext = mainVm;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
    }
}
