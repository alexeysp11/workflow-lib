using System.Windows;
using System.Windows.Controls;

namespace WorkflowLib.Examples.HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for DataIn.xaml
    /// </summary>
    public partial class DataIn : UserControl
    {
        public DataIn()
        {
            InitializeComponent();
        }

        public void ClearAllFields()
        {
            ServiceInput.tbService.Text = string.Empty; 
            ServiceInput.tbQuantity.Text = string.Empty; 
            ServiceInput.tbPrice.Text = string.Empty; 
            tbParticipants.Text = string.Empty; 
        }

        public void EnableAllBtn()
        {
            btnServiceDetails.IsEnabled = true; 
            btnAdd.IsEnabled = true; 
            btnEdit.IsEnabled = true; 
            btnDelete.IsEnabled = true; 
        }

        public void DisableAllBtn()
        {
            btnServiceDetails.IsEnabled = false; 
            btnAdd.IsEnabled = false; 
            btnEdit.IsEnabled = false; 
            btnDelete.IsEnabled = false; 
        }
    }
}
