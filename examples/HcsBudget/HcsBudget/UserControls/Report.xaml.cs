using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();

            Loaded += (o, e) => GetYears(); 
        }

        private void DefaultBtn_Clicked(object sender, System.EventArgs e)
        {
            SetDefaultValues(); 
        }

        public void GetYears()
        {
            MainVM mainVM = (MainVM)(this.DataContext); 
            mainVM.InsertCurrentDateIntoDb(); 
            List<int> years = mainVM.SelectDistinctYears(); 
            foreach (int year in years)
            {
                cbYearFrom.Items.Add(year.ToString());
                cbYearTo.Items.Add(year.ToString());
                SetDefaultValues(); 
            }
        }

        private void SetDefaultValues()
        {
            cbMonthFrom.SelectedIndex = 0; 
            cbMonthTo.SelectedIndex = 11; 

            cbYearFrom.SelectedIndex = 0; 
            cbYearTo.SelectedIndex = 0; 
        }
    }
}
