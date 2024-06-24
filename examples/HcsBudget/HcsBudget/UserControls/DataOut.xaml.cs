using System.Data;
using System.Windows;
using System.Windows.Controls;
using WorkflowLib.Examples.HcsBudget.ViewModels;
using WorkflowLib.Examples.HcsBudget.Models;

namespace WorkflowLib.Examples.HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for DataOut.xaml
    /// </summary>
    public partial class DataOut : UserControl
    {
        private MainVM MainVM { get; set; }

        public DataOut()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DataIn dataIn = this.MainVM.MainWindow.DataIn; 

                Hcs selectedHcs = (Hcs)(dg.SelectedItem);
                this.MainVM.SelectedHcs = selectedHcs;

                if (selectedHcs != null)
                {
                    dataIn.ServiceInput.tbService.Text = selectedHcs.Name.ToString(); 
                    dataIn.ServiceInput.tbQuantity.Text = selectedHcs.Qty.ToString(); 
                    dataIn.ServiceInput.tbPrice.Text = selectedHcs.PriceUsd.ToString(); 
                    dataIn.tbParticipants.Text = selectedHcs.ParticipantName.ToString(); 
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }
    }
}
