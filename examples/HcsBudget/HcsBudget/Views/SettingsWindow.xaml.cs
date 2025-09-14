using System.Collections.Generic;
using System.Windows;
using VelocipedeUtils.Examples.HcsBudget.ViewModels;

namespace VelocipedeUtils.Examples.HcsBudget.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainVM MainVM { get; set; }

        private string InitUser { get; set; }
        private string InitLanguage { get; set; }
        private string InitCurrency { get; set; }
        private string InitDatabase { get; set; }

        public SettingsWindow()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                this.MainVM = ((MainVM)(this.DataContext));
                Participants.DataContext = this.MainVM;
                LoadUserSettings();
                LoadParticipants();
                SaveInitialValues();
            };
        }

        private void DefaultBtn_Clicked(object sender, System.EventArgs e)
        {
            SetDefaultValues();
        }

        private void SaveBtn_Clicked(object sender, System.EventArgs e)
        {
            SaveAll();
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                // Also compare a list of participants
                if (InitUser == cbUser.Text && 
                    InitLanguage == cbLanguage.Text && 
                    InitCurrency == cbCurrency.Text &&
                    InitDatabase == cbDatabase.Text)
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

        private void cbUser_DropDownClosed(object sender, System.EventArgs e)
        {
            SetValuesForSelectedUser();
        }

        private void LoadParticipants()
        {
            List<string> participants = this.MainVM.LoadParticipants();
            this.Participants.tvParticipants.ItemsSource = participants;
        }

        private void SaveInitialValues()
        {
            try
            {
                InitUser = cbUser.Text;
                InitLanguage = cbLanguage.Text;
                InitCurrency = cbCurrency.Text;
                InitDatabase = cbDatabase.Text;
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
            UpdateUserSettings();
            LoadUserSettings();
            SaveInitialValues();
        }

        private void LoadUserSettings()
        {
            this.MainVM.LoadUserSettings();
            SetValuesForSelectedUser();
        }

        private void SetDefaultValues()
        {
            cbUser.Text = "Guest";
            cbLanguage.Text = "English";
            cbCurrency.Text = "USD";
            cbDatabase.Text = "Application";
        }

        private void UpdateUserSettings()
        {
            try
            {
                foreach (var user in this.MainVM.Users)
                {
                    if (user.Name == cbUser.Text)
                    {
                        this.MainVM.UpdateUserSettings(user.UserId, cbLanguage.Text, 
                            cbCurrency.Text, cbDatabase.Text);
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        private void SetValuesForSelectedUser()
        {
            try
            {
                foreach (var user in this.MainVM.Users)
                {
                    if (user.Name == cbUser.Text)
                    {
                        if (user.Name == "Administrator")
                        {
                            string msg = "Unable to connect to database: access is restricted.\nALL OPTIONS WILL BE SET TO DEFAULT.";
                            System.Windows.MessageBox.Show(msg, "Error");
                            SetDefaultValues();
                            break;
                        }
                        cbLanguage.Text = user.Language;
                        cbCurrency.Text = user.CurrAbbreviation;
                        cbDatabase.Text = user.Database;
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
    }
}
