using System.Windows;

namespace VelocipedeUtils.Examples.HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void CloseBtn_Clicked(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
