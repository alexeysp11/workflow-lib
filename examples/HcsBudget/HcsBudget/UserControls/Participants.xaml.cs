using System.Windows;
using System.Windows.Controls;
using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.UserControls
{
    /// <summary>
    /// Interaction logic for Participants.xaml
    /// </summary>
    public partial class Participants : UserControl
    {
        private MainVM MainVM { get; set; }

        private string CurrentParticipant { get; set; } = null; 
        
        public Participants()
        {
            InitializeComponent();

            Loaded += (o, e) => this.MainVM = ((MainVM)(this.DataContext));
        }

        private void LoadParticipants()
        {
            tvParticipants.ItemsSource = this.MainVM.LoadParticipants(); 
        }

        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                CurrentParticipant = (e.NewValue).ToString(); 
                tbParticipants.Text = CurrentParticipant; 
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception"); 
            }
        }

        private void AddBtn_Clicked(object sender, System.EventArgs e)
        {
            if (tbParticipants.Text != string.Empty)
            {
                this.MainVM.AddParticipant(tbParticipants.Text); 
                LoadParticipants(); 
            }
            else
            {
                string msg = "Unable to add participant.\nYou need to write a new name into TextBox."; 
                System.Windows.MessageBox.Show(msg, "Error"); 
            }
        }

        private void EditBtn_Clicked(object sender, System.EventArgs e)
        {
            if (CurrentParticipant != null && tbParticipants.Text != string.Empty)
            {
                this.MainVM.EditParticipant(CurrentParticipant, tbParticipants.Text); 
                LoadParticipants(); 
            }
            else
            {
                string msg = "Unable to edit participant.\nYou need to select a participant in ListBox and write a new name into TextBox."; 
                System.Windows.MessageBox.Show(msg, "Error"); 
            }
        }

        private void DeleteBtn_Clicked(object sender, System.EventArgs e)
        {
            if (CurrentParticipant == tbParticipants.Text)
            {
                this.MainVM.DeleteParticipant(CurrentParticipant); 
                LoadParticipants(); 
            }
            else
            {
                string msg = "Unable to delete participant.\nNames in ListBox and TextBox should be the same."; 
                System.Windows.MessageBox.Show(msg, "Error"); 
            }
        }
    }
}
