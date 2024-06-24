using System.Windows;
using System.Windows.Controls;
using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Months.xaml
    /// </summary>
    public partial class Months : UserControl
    {
        private MainVM MainVM { get; set; }

        public Months()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                string selectedMonth = (e.NewValue).ToString(); 
                foreach (var month in this.MainVM.MonthsCollection)
                {
                    if (month.Label == selectedMonth)
                    {
                        this.MainVM.SelectHcs(month.PeriodId); 
                        this.MainVM.SelectedHcs = new WorkflowLib.Examples.HcsBudget.Models.Hcs(month.PeriodId); 
                        break; 
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }
    }
}
