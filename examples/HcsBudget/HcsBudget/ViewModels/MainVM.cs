using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VelocipedeUtils.Examples.HcsBudget.Views;
using VelocipedeUtils.Examples.HcsBudget.Commands;
using VelocipedeUtils.Examples.HcsBudget.Models;
using VelocipedeUtils.Examples.HcsBudget.Models.DbConnections;

namespace VelocipedeUtils.Examples.HcsBudget.ViewModels
{
    public class MainVM
    {
        public MainWindow MainWindow { get; private set; }

        public ICommand InputCommand { get; private set; }
        public ICommand OutputCommand { get; private set; }
        public ICommand NavigateCommand { get; private set; }

        private IHcsDbConnection HcsDbConnection { get; set; }
        private IStateDbConnection StateDbConnection { get; set; }

        public List<Month> MonthsCollection { get; private set; }
        public List<Hcs> HcsCollection { get; private set; }
        public List<User> Users { get; private set; } 
        public List<ReportRow> FinalReport { get; private set; } 

        private Hcs selectedHcs;
        public Hcs SelectedHcs 
        {
            get { return selectedHcs; } 
            set
            {
                selectedHcs = value;
                if (selectedHcs == null)
                {
                    this.MainWindow.DataIn.ClearAllFields();
                    this.MainWindow.DataIn.DisableAllBtn();
                }
                else
                {
                    this.MainWindow.DataIn.EnableAllBtn();
                }
            }
        }

        public MainVM(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;

            this.InputCommand = new InputCommand(this);
            this.OutputCommand = new OutputCommand(this);
            this.NavigateCommand = new NavigateCommand(this);

            this.HcsDbConnection = new DbConnection();
            this.StateDbConnection = new DbConnection();
        }

        #region Data output
        public void ReloadData()
        {
            try
            {
                InsertCurrentDateIntoDb();
                InsertNextDateIntoDb();
                InsertPrevDateIntoDb();
                MonthsCollection = this.HcsDbConnection.GetMonths();

                List<string> monthNames = new List<string>();
                foreach (Month month in MonthsCollection)
                {
                    monthNames.Add(month.Label);
                }
                this.MainWindow.Months.tvMonths.ItemsSource = monthNames;
                SelectedHcs = null;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void SelectHcs(int periodId)
        {
            try
            {
                HcsCollection = this.HcsDbConnection.GetHcs(periodId);
                this.MainWindow.DataOut.dgrHCS.ItemsSource = HcsCollection;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public List<int> SelectDistinctYears()
        {
            List<int> result = new List<int>();
            try
            {
                this.HcsDbConnection.GetDistinctYears(ref result);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
            return result;
        }

        public List<string> LoadParticipants()
        {
            List<string> result = new List<string>();
            try
            {
                result = this.HcsDbConnection.SelectAllParticipants();
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
            return result;
        }

        public List<string> LoadHcs()
        {
            List<string> result = new List<string>();
            try
            {
                result = this.HcsDbConnection.SelectAllHcs();
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
            return result;
        }

        public void CalculateReport()
        {
            int monthFrom = 1;
            int yearFrom = 2021;
            int monthTo = 12;
            int yearTo = 2021;

            this.FinalReport = this.HcsDbConnection.GetReport(monthFrom, yearFrom, 
                monthTo, yearTo);
            OpenReportWindow();
        }

        public void ExportReport()
        {
            System.Windows.MessageBox.Show("ExportReport");
        }

        public void ClearReport()
        {
            System.Windows.MessageBox.Show("ClearReport");
        }

        public void LoadUserSettings()
        {
            try
            {
                Users = this.HcsDbConnection.SelectUserSettings();
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
        #endregion  // Data output

        #region Data input
        public void InsertCurrentDateIntoDb()
        {
            try
            {
                System.DateTime today = System.DateTime.UtcNow.Date;
                this.HcsDbConnection.InsertDate(today.Month, today.Year);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void InsertNextDateIntoDb()
        {
            try
            {
                System.DateTime today = System.DateTime.UtcNow.Date;
                int year = today.Year;
                int month = today.Month;
                if (month == 12)
                {
                    month = 1;
                    year += 1;
                }
                this.HcsDbConnection.InsertDate(month, year);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void InsertPrevDateIntoDb()
        {
            try
            {
                System.DateTime today = System.DateTime.UtcNow.Date;
                int year = today.Year;
                int month = today.Month;
                if (month == 1)
                {
                    month = 12;
                    year -= 1;
                }
                this.HcsDbConnection.InsertDate(month, year);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void AddParticipant(string name)
        {
            try
            {
                this.HcsDbConnection.InsertParticipant(name);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void EditParticipant(string oldName, string newName)
        {
            try
            {
                this.HcsDbConnection.UpdateParticipant(oldName, newName);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void DeleteParticipant(string name)
        {
            try
            {
                this.HcsDbConnection.DeleteParticipant(name);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void UpdateUserSettings(int userId, string language, 
            string currency, string database)
        {
            try
            {
                this.HcsDbConnection.UpdateUserSettings(userId, language, currency, database);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void AddService()
        {
            try
            {
                List<string> newParticipantsList = new List<string>();
                string participants = this.MainWindow.DataIn.tbParticipants.Text;
                foreach (var item in participants.Split(',').ToList())
                {
                    if (item != string.Empty)
                    {
                        newParticipantsList.Add(item);
                    }
                }

                var dataIn = this.MainWindow.DataIn;
                this.HcsDbConnection.InsertHcs(this.SelectedHcs.PeriodId,
                    dataIn.ServiceInput.tbService.Text, 
                    System.Convert.ToSingle(dataIn.ServiceInput.tbQuantity.Text), 
                    System.Convert.ToSingle(dataIn.ServiceInput.tbPrice.Text), 
                    newParticipantsList
                );
                SelectHcs(this.SelectedHcs.PeriodId);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void EditService()
        {
            try
            {
                List<string> newParticipantsList = new List<string>();
                string participants = this.MainWindow.DataIn.tbParticipants.Text;
                foreach (var item in participants.Split(',').ToList())
                {
                    if (item != string.Empty)
                    {
                        newParticipantsList.Add(item);
                    }
                }

                List<string> oldParticipantsList = new List<string>();
                participants = this.SelectedHcs.ParticipantName;
                foreach (var item in participants.Split(',').ToList())
                {
                    if (item != string.Empty)
                    {
                        oldParticipantsList.Add(item);
                    }
                }

                var dataIn = this.MainWindow.DataIn;
                this.HcsDbConnection.UpdateHcs(this.SelectedHcs.HcsId,
                    dataIn.ServiceInput.tbService.Text, 
                    System.Convert.ToSingle(dataIn.ServiceInput.tbQuantity.Text), 
                    System.Convert.ToSingle(dataIn.ServiceInput.tbPrice.Text), 
                    oldParticipantsList,
                    newParticipantsList
                );
                SelectHcs(this.SelectedHcs.PeriodId);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }

        public void DeleteService()
        {
            try
            {
                this.HcsDbConnection.DeleteHcs(this.SelectedHcs.HcsId);
                SelectHcs(this.SelectedHcs.PeriodId);
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
        #endregion  // Data input

        #region Navigation
        public void OpenReportWindow()
        {
            var win = new ReportWindow();
            win.DataContext = this;
            win.Show();

            string sFrom = $"{this.MainWindow.Report.cbMonthFrom.Text.ToUpper()} {this.MainWindow.Report.cbYearFrom.Text}";
            string sTo = $"{this.MainWindow.Report.cbMonthTo.Text.ToUpper()} {this.MainWindow.Report.cbYearTo.Text}";
            win.lblReportName.Content = $"FROM {sFrom} TO {sTo}";

            win.dgrReport.ItemsSource = this.FinalReport;
        }

        public void OpenSettingsWindow()
        {
            var win = new SettingsWindow();
            win.DataContext = this;
            win.Show();
        }

        public void OpenFindWindow()
        {
            var win = new FindWindow();
            win.DataContext = this;
            win.Show();
        }

        public void OpenServiceWindow()
        {
            var win = new ServiceWindow();
            win.DataContext = this;

            var siFrom = this.MainWindow.DataIn.ServiceInput;
            win.ServiceInput.tbService.Text = siFrom.tbService.Text;
            try
            {
                win.ServiceInput.tbQuantity.Text = (System.Convert.ToSingle(siFrom.tbQuantity.Text)).ToString();
                win.ServiceInput.tbPrice.Text = (System.Convert.ToSingle(siFrom.tbPrice.Text)).ToString();
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
                return;
            }
            string participants = this.MainWindow.DataIn.tbParticipants.Text;
            foreach (var item in participants.Split(',').ToList())
            {
                if (item != string.Empty)
                {
                    win.tvParticipantsTo.Items.Add(item);
                }
            }
            win.Show();
        }

        public void OpenUserDocs(string filename)
        {
            string msg = "Do you want to open documentation in your browser?";
            if (System.Windows.MessageBox.Show(msg, "User Docs", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                try 
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = $"docs\\{filename}.html";
                    process.Start();
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Exception");
                }
            }
        }

        public void OpenGitHubAcount()
        {
            try 
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/alexeysp11/VelocipedeUtils.Examples.HcsBudget",
                    UseShellExecute = true
                });
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Exception");
            }
        }
        #endregion  // Navigation
    }
}