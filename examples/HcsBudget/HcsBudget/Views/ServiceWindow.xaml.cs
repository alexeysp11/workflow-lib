using System.Collections.Generic;
using System.Windows;
using WorkflowLib.Examples.HcsBudget.ViewModels;

namespace WorkflowLib.Examples.HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private MainVM MainVM { get; set; }

        private string InitName { get; set; }
        private float InitQuantity { get; set; }
        private float InitPrice { get; set; }
        private List<string> InitParticipants { get; set; }

        public ServiceWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = ((MainVM)(this.DataContext));
                LoadParticipants();
                SaveInitialValues();
            };
        }

        private void tvParticipantsFrom_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string menuItem = tvParticipantsFrom.SelectedItem as string;
                if (menuItem != null)
                {
                    foreach (string item in this.tvParticipantsTo.Items)
                    {
                        if (item == menuItem) 
                        {
                            return;
                        }
                    }
                    this.tvParticipantsTo.Items.Add(menuItem);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void tvParticipantsTo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            tvParticipantsTo.Items.Remove(tvParticipantsTo.SelectedItem);
        }

        private void SaveBtn_Clicked(object sender, System.EventArgs e)
        {
            SaveAll();
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                float qty = float.Parse(this.ServiceInput.tbQuantity.Text);
                float price = float.Parse(this.ServiceInput.tbPrice.Text);
                bool areParticipantsChanged = AreParticipantsChanged();
                
                if (InitName == this.ServiceInput.tbService.Text && 
                    AreEqual(InitQuantity, qty, 0.009f) && 
                    AreEqual(InitPrice, price, 0.009f) && 
                    !areParticipantsChanged)
                {
                    this.Close();
                }
                else
                {
                    AskToSaveOnCancel();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void LoadParticipants()
        {
            this.tvParticipantsFrom.ItemsSource = this.MainVM.LoadParticipants();
        }

        private void SaveInitialValues()
        {
            try
            {
                InitName = this.ServiceInput.tbService.Text;
                InitQuantity = float.Parse(this.ServiceInput.tbQuantity.Text);
                InitPrice = float.Parse(this.ServiceInput.tbPrice.Text);
                
                InitParticipants = new List<string>();
                foreach (var item in this.tvParticipantsTo.Items)
                {
                    InitParticipants.Add(item.ToString());
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        private void AskToSaveOnCancel()
        {
            string msg = "Do you want to save changes?";
            var result = System.Windows.MessageBox.Show(msg, "Close window", System.Windows.MessageBoxButton.YesNoCancel);
            if (result == System.Windows.MessageBoxResult.Yes)
            {
                SaveAll();
                this.Close();
            }
            else if (result == System.Windows.MessageBoxResult.No)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void SaveAll()
        {
            SaveInitialValues();
            LoadValueToDataIn();
        }

        private bool AreParticipantsChanged()
        {
            bool result = false;
            var participants = this.tvParticipantsTo.Items;
            int length = System.Math.Max(participants.Count, InitParticipants.Count);
            for (int i = 0; i < length; i++)
            {
                try
                {
                    if (InitParticipants[i] != participants[i])
                    {
                        result = true;
                        break;
                    }
                }
                catch (System.Exception)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void LoadValueToDataIn()
        {
            try
            {
                var dataIn = this.MainVM.MainWindow.DataIn;
                dataIn.ServiceInput.tbService.Text = ServiceInput.tbService.Text;
                dataIn.ServiceInput.tbQuantity.Text = (System.Convert.ToSingle(ServiceInput.tbQuantity.Text)).ToString();
                dataIn.ServiceInput.tbPrice.Text = (System.Convert.ToSingle(ServiceInput.tbPrice.Text)).ToString();
                int i = 0;
                foreach (var item in tvParticipantsTo.Items)
                {
                    if (i == 0)
                    {
                        dataIn.tbParticipants.Text = item.ToString();
                    }
                    else
                    {
                        dataIn.tbParticipants.Text += "," + item.ToString();
                    }
                    i += 1;
                }
                if (tvParticipantsTo.Items.Count == 0)
                {
                    dataIn.tbParticipants.Text = string.Empty;
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        private bool AreEqual(float float1, float float2, float difference)
        {
            return System.Math.Abs(float1 - float2) <= difference;
        }
    }
}
