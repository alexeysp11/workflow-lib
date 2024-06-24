using System.Collections.Generic;
using System.Windows;
using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        private MainVM MainVM { get; set; }

        public FindWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = (MainVM)(this.DataContext); 
                LoadYears(); 
                LoadParticipants(); 
                LoadServices(); 
            }; 
        }
        
        private void tvParticipantsFrom_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var menuItem = tvParticipantsFrom.SelectedItem as string;
            if (menuItem != null)
            {
                foreach (var item in this.tvParticipantsTo.Items)
                {
                    if (item == menuItem) 
                    {
                        return; 
                    }
                }
                this.tvParticipantsTo.Items.Add(menuItem);
            }
        }

        private void tvParticipantsTo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            tvParticipantsTo.Items.Remove(tvParticipantsTo.SelectedItem);
        }
        
        private void tvServicesFrom_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var menuItem = tvServicesFrom.SelectedItem as string;
            if (menuItem != null)
            {
                foreach (var item in this.tvServicesTo.Items)
                {
                    if (item == menuItem) 
                    {
                        return; 
                    }
                }
                this.tvServicesTo.Items.Add(menuItem);
            }
        }

        private void tvServicesTo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            tvServicesTo.Items.Remove(tvServicesTo.SelectedItem);
        }
        
        private void FindBtn_Clicked(object sender, System.EventArgs e)
        {
            System.Windows.MessageBox.Show("FindBtn_Clicked");
        }

        private void ClearBtn_Clicked(object sender, System.EventArgs e)
        {
            System.Windows.MessageBox.Show("ClearBtn_Clicked");
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void LoadYears()
        {
            List<int> years = this.MainVM.SelectDistinctYears(); 
            foreach (int year in years)
            {
                cbYearFrom.Items.Add(year.ToString());
                cbYearTo.Items.Add(year.ToString());

                cbYearFrom.SelectedIndex = 0; 
                cbYearTo.SelectedIndex = 0; 
            }
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants(); 
            this.tvParticipantsFrom.ItemsSource = participants; 
        }

        private void LoadServices()
        {
            List<string> hcs = this.MainVM.LoadHcs(); 
            this.tvServicesFrom.ItemsSource = hcs; 
        }
    }
}
