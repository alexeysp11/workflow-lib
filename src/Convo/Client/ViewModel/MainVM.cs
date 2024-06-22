using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Chat.Client.Commands;
using Chat.Client.View;
using Chat.Client.Database;
using Chat.Network.Client;

namespace Chat.Client.ViewModel
{
    public class MainVM
    {
        #region Properties 
        public MainWindow ActiveWindow { get; private set; } = null; 

        public UserModel ActiveUser { get; private set; } = null; 
        private IProtocolClient NetworkClient = null; 

        private readonly DispatcherTimer GetMsgTimer = null;
        
        public DispMsgVM DispMsgVM { get; private set; }
        
        public ICommand RedirectCommand { get; private set; }
        public ICommand AuthCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand SendMsgCommand { get; private set; }
        #endregion  // Properties 

        #region Constructor
        /// <summary>
        /// Public constructor of MainVM
        /// </summary>
        /// <param name="mainWindow">Instance of MainWindow (for convinient way to access UI elements)</param>
        public MainVM(MainWindow mainWindow)
        {
            ActiveWindow = mainWindow; 

            this.DispMsgVM = new DispMsgVM(this); 

            this.RedirectCommand = new RedirectCommand(this); 
            this.AuthCommand = new AuthCommand(this); 
            this.ExitCommand = new ExitCommand(this); 
            this.SendMsgCommand = new SendMsgCommand(this); 

            GetMsgTimer = new DispatcherTimer();

            // Try to create a table for users inside DB. 
            try
            {
                DatabasePath path = new DatabasePath(); 
                SqliteDbHelper.Instance.AbsolutePathToDb = path.AbsolutePath; 
                SqliteDbHelper.Instance.CreateUserTable(); 
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Failed to create database:\n{e}"); 
            }
            
            this.SetNumAvailableCharsInMsg(); 
            this.GoToWelcomePage(); 
        }
        #endregion  // Constructor

        #region Methods for going to an other page
        public void GoToWelcomePage()
        {
            // Welcome page
            ActiveWindow.Welcome.Visibility = Visibility.Visible; 
            ActiveWindow.Welcome.IsEnabled = true; 

            // Registration page
            ActiveWindow.Registration.Visibility = Visibility.Collapsed; 
            ActiveWindow.Registration.IsEnabled = false; 

            // Login page
            ActiveWindow.Login.Visibility = Visibility.Collapsed; 
            ActiveWindow.Login.IsEnabled = false; 

            // UserPage page
            ActiveWindow.UserPage.Visibility = Visibility.Collapsed; 
            ActiveWindow.UserPage.IsEnabled = false; 
        }

        public void GoToRegisterPage()
        {
            // Welcome page
            ActiveWindow.Welcome.Visibility = Visibility.Collapsed; 
            ActiveWindow.Welcome.IsEnabled = false; 

            // Registration page
            ActiveWindow.Registration.Visibility = Visibility.Visible; 
            ActiveWindow.Registration.IsEnabled = true; 

            // Login page
            ActiveWindow.Login.Visibility = Visibility.Collapsed; 
            ActiveWindow.Login.IsEnabled = false; 

            // UserPage page
            ActiveWindow.UserPage.Visibility = Visibility.Collapsed; 
            ActiveWindow.UserPage.IsEnabled = false; 
        }

        public void GoToLoginPage()
        {
            // Welcome page
            ActiveWindow.Welcome.Visibility = Visibility.Collapsed; 
            ActiveWindow.Welcome.IsEnabled = false; 

            // Registration page
            ActiveWindow.Registration.Visibility = Visibility.Collapsed; 
            ActiveWindow.Registration.IsEnabled = false; 
            this.ClearRegistrationFields(); 

            // Login page
            ActiveWindow.Login.Visibility = Visibility.Visible; 
            ActiveWindow.Login.IsEnabled = true; 
            this.ClearLoginFields(); 

            // UserPage page
            ActiveWindow.UserPage.Visibility = Visibility.Collapsed; 
            ActiveWindow.UserPage.IsEnabled = false; 
        }

        public void GoToUserPage()
        {
            // Welcome page
            ActiveWindow.Welcome.Visibility = Visibility.Collapsed; 
            ActiveWindow.Welcome.IsEnabled = false; 

            // Registration page
            ActiveWindow.Registration.Visibility = Visibility.Collapsed; 
            ActiveWindow.Registration.IsEnabled = false; 
            this.ClearRegistrationFields(); 

            // Login page
            ActiveWindow.Login.Visibility = Visibility.Collapsed; 
            ActiveWindow.Login.IsEnabled = false; 
            this.ClearLoginFields(); 

            // UserPage page
            ActiveWindow.UserPage.Visibility = Visibility.Visible; 
            ActiveWindow.UserPage.IsEnabled = true; 

            // Timer for getting messages from the server. 
            GetMsgTimer.Tick += GetMsgFromServer;
            GetMsgTimer.Interval = System.TimeSpan.FromSeconds(10);
            GetMsgTimer.Start();
        }

        public void CloseApp()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure to exit the application?", "Exit the application", MessageBoxButton.YesNo); 
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (this.NetworkClient != null)
                    {
                        this.NetworkClient.SendMessage($"User {this.ActiveUser.Name} disconnected"); 
                        this.NetworkClient.CloseConnection(); 
                    }
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show($"Exception:\n{e}", "Exception"); 
                }
                finally
                {
                    this.GetMsgTimer.Stop(); 
                    this.ActiveUser = null; 
                    Application.Current.Shutdown();
                }
            }
        }
        #endregion  // Methods for going to an other page

        #region Submit methods
        public void SubmitLogin()
        {
            if (string.IsNullOrWhiteSpace(ActiveWindow.UsernameLogin.Text) ||
                string.IsNullOrWhiteSpace(ActiveWindow.PasswordLogin.Password))
            {
                ActiveWindow.MessageLogin.Text = "Fill in all fields, please!";
            }
            else
            {
                this.CheckUserInDbOnLogin();  
            }
        }

        public void SubmitRegistration()
        {
            if (string.IsNullOrWhiteSpace(ActiveWindow.UsernameReg.Text) ||
                string.IsNullOrWhiteSpace(ActiveWindow.EmailReg.Text) ||
                string.IsNullOrWhiteSpace(ActiveWindow.PasswordBoxReg.Password) ||
                string.IsNullOrWhiteSpace(ActiveWindow.ConfirmPasswordBoxReg.Password))
            {
                ActiveWindow.MessageReg.Text = "Fill in all fields, please!";
            }
            else
            {
                if (ActiveWindow.PasswordBoxReg.Password == ActiveWindow.ConfirmPasswordBoxReg.Password)
                {
                    this.RegisterUserInDb();    // Insert new user into DB 
                }
                else
                {
                    ActiveWindow.MessageReg.Text = "Passwords do not match!";
                }
            }
        }

        private void CheckUserInDbOnLogin()
        {
            using ( UserModel user = new UserModel(ActiveWindow.UsernameLogin.Text, null, ActiveWindow.PasswordLogin.Password) )
            {
                try
                {
                    if (SqliteDbHelper.Instance.IsAuthenticated(user))
                    {
                        System.Windows.MessageBox.Show("Successfully submitted!\nNow you can join the Chat.", "Welcome to the Chat!");
                        this.ActiveUser = user; 
                        this.NetworkClient = new ChatTcpClient("127.0.0.0", "localhost", 13000, this.ActiveUser.Name); 
                        this.ClearLoginFields(); 
                        this.GoToUserPage(); 
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No such user in the database.\nRegister first!", "Authentication error");
                        this.ClearLoginFields(); 
                        this.GoToRegisterPage(); 
                    }
                }
                catch (System.Exception e)
                {
                    System.Windows.MessageBox.Show($"Exception while getting user from database:\n{e}", "Exception"); 
                }
            }
        }

        private void RegisterUserInDb()
        {
            try
            {
                using ( UserModel user = new UserModel(ActiveWindow.UsernameReg.Text, ActiveWindow.EmailReg.Text, ActiveWindow.PasswordBoxReg.Password) )
                {
                    if (SqliteDbHelper.Instance.IsAuthenticated(user))
                    {
                        System.Windows.MessageBox.Show($"User {user.Name} already exists in DB.\nGo to the Login Page.", "Authentication error", MessageBoxButton.OK); 
                        this.ClearRegistrationFields(); 
                        this.GoToLoginPage();
                    }
                    else
                    {
                        SqliteDbHelper.Instance.InsertDataIntoUserTable(user); 
                        if (SqliteDbHelper.Instance.IsAuthenticated(user))
                        {
                            ActiveWindow.MessageReg.Text = "Successfully submitted!"; 
                            this.ClearRegistrationFields(); 
                            this.GoToLoginPage();
                        }
                        else
                        {
                            ActiveWindow.MessageReg.Text = "Unable to insert user into database";
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception while getting user from database:\n{e}", "Database exception"); 
            }
        }
        #endregion  // Submit methods

        #region Clearing field
        private void ClearLoginFields()
        {
            ActiveWindow.UsernameLogin.Text = System.String.Empty; 
            ActiveWindow.PasswordLogin.Password = System.String.Empty; 
            ActiveWindow.MessageLogin.Text = System.String.Empty; 
        }

        private void ClearRegistrationFields()
        {
            ActiveWindow.UsernameReg.Text = System.String.Empty; 
            ActiveWindow.EmailReg.Text = System.String.Empty; 
            ActiveWindow.PasswordBoxReg.Password = System.String.Empty; 
            ActiveWindow.ConfirmPasswordBoxReg.Password = System.String.Empty; 
            ActiveWindow.MessageReg.Text = System.String.Empty; 
        }
        #endregion  // Clearing field

        #region Communication methods 
        public void SendMessage()
        {
            try
            {
                string time = System.DateTime.Now.ToString(@"HH:mm"); 
                string msg = $"{time} {this.ActiveUser.Name}: {this.DispMsgVM.MessageToSend}"; 
                this.NetworkClient.SendMessage(msg, true); 
                this.DispMsgVM.MessagesInChat += $"{msg}\n"; 
                this.DispMsgVM.MessageToSend = System.String.Empty; 
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception:\n{e}", "Exception"); 
            }
        }

        /// <summary>
        /// Sets string to display number of available chars while typing the message 
        /// </summary>
        /// <param name="charsInMessage">Number of characters in the current message</param>
        public void SetNumAvailableCharsInMsg(int charsInMessage=0)
        {
            int maxLength = this.ActiveWindow.MessageToSendTextBox.MaxLength; 
            this.DispMsgVM.CharsAvailable = $" ({maxLength - charsInMessage}/{maxLength}) "; 
        }

        public void GetMsgFromServer(object sender, System.EventArgs e)
        {
            string msg = this.NetworkClient.GetMessages(); 
            if (msg != string.Empty)
            {
                this.DispMsgVM.MessagesInChat += $"{msg}\n"; 
            }
        }
        #endregion  // Communication methods 
    }
}