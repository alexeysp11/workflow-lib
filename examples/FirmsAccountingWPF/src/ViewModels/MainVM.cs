using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VelocipedeUtils.Examples.FirmsAccounting.Views;
using VelocipedeUtils.Examples.FirmsAccounting.Commands;
using VelocipedeUtils.Examples.FirmsAccounting.Models.DbConnections;
using VelocipedeUtils.Examples.FirmsAccounting.Models.Data;

namespace VelocipedeUtils.Examples.FirmsAccounting.ViewModels
{
    public class MainVM
    {
        public MainWindow MainWindow { get; private set; } 

        public ICommand FindCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand GetAllCommand { get; private set; }
        public ICommand RedirectCommand { get; private set; }

        private IFirmsDbConnection FirmsDbConnection = new PgDbConnection();
        private IDocsDbConnection DocsDbConnection = new PgDbConnection();

        private List<FirmCity> FirmCityCollection = new List<FirmCity>();
        private List<DocsCalendarSum> DocsCollection = new List<DocsCalendarSum>();

        public MainVM(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;

            this.FindCommand = new FindCommand(this);
            this.ClearCommand = new ClearCommand(this);
            this.GetAllCommand = new GetAllCommand(this);
            this.RedirectCommand = new RedirectCommand(this);
        }

        #region Firms
        public void GetAllFirms()
        {
            try
            {
                FirmCityCollection = this.FirmsDbConnection.GetFirmCity();
                this.MainWindow.CityFirmDataGrid.ItemsSource = FirmCityCollection;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception: {e}", "Exception");
            }
        }

        public void FindFirm()
        {
            string firmName = this.MainWindow.FirmNameTextBox.Text;
            string postCity = this.MainWindow.PostalAddressCityTextBox.Text;
            string jurCity = this.MainWindow.LegalAddressCityTextBox.Text;

            try
            {
                FirmCityCollection = this.FirmsDbConnection.GetFirmCity(firmName, postCity, jurCity);
                this.MainWindow.CityFirmDataGrid.ItemsSource = FirmCityCollection;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception: {e}", "Exception");
            }
        }

        public void ClearFirm()
        {
            FirmCityCollection = new List<FirmCity>();
            this.MainWindow.CityFirmDataGrid.ItemsSource = FirmCityCollection;
        }
        #endregion  // Firms

        #region Docs
        public void GetAllDocs()
        {
            try
            {
                DocsCollection = this.DocsDbConnection.GetDocs();
                this.MainWindow.DocsDataGrid.ItemsSource = DocsCollection;
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception: {e}", "Exception");
            }
        }

        public void FindDoc()
        {
            string firmName = this.MainWindow.FirmNameTextBox.Text;
            string postCity = this.MainWindow.PostalAddressCityTextBox.Text;
            string jurCity = this.MainWindow.LegalAddressCityTextBox.Text;

            try
            {
                var firmList = this.FirmsDbConnection.GetFirmCity(firmName, postCity, jurCity);
                if (firmList.Count != 0)
                {
                    DocsCollection = this.DocsDbConnection.GetDocs(firmList.First().FirmId);
                    this.MainWindow.DocsDataGrid.ItemsSource = DocsCollection;
                }
                else
                {
                    System.Windows.MessageBox.Show("Nothing was found", "Information");
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception: {e}", "Exception");
            }
        }

        public void ClearDoc()
        {
            DocsCollection = new List<DocsCalendarSum>();
            this.MainWindow.DocsDataGrid.ItemsSource = DocsCollection;
        }
        #endregion  // Docs

        #region Redirection
        public void RedirectToFirms()
        {
            this.MainWindow.Title = this.MainWindow.FirmWindowTitle;

            // Enable CityFirmGrid
            this.MainWindow.CityFirmGrid.Visibility = Visibility.Visible;
            this.MainWindow.CityFirmGrid.IsEnabled = true;

            // Disable DocsGrid
            this.MainWindow.DocsGrid.Visibility = Visibility.Collapsed;
            this.MainWindow.DocsGrid.IsEnabled = false;
        }

        public void RedirectToDocs()
        {
            this.MainWindow.Title = this.MainWindow.DocWindowTitle;

            // Disable CityFirmGrid
            this.MainWindow.CityFirmGrid.Visibility = Visibility.Collapsed;
            this.MainWindow.CityFirmGrid.IsEnabled = false;

            // Enable DocsGrid
            this.MainWindow.DocsGrid.Visibility = Visibility.Visible;
            this.MainWindow.DocsGrid.IsEnabled = true;
        }
        #endregion  // Redirection
    }
}