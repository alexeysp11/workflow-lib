using Chat.Client.ViewModel; 

namespace Chat.Client.Commands
{
    public class RedirectCommand : System.Windows.Input.ICommand
    {
        private MainVM _MainVM;
        
        public RedirectCommand(MainVM mainVM)
        {
            this._MainVM = mainVM; 
        }

        public event System.EventHandler CanExecuteChanged; 

        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            string parameterString = parameter as string; 
            if (parameterString == "Register")
            {
                this._MainVM.GoToRegisterPage(); 
            }
            else if (parameterString == "Login")
            {
                this._MainVM.GoToLoginPage(); 
            }
            else if (parameterString == "WelcomePage")
            {
                this._MainVM.GoToWelcomePage(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString} inside RedirectCommand", "Exception"); 
            }
        }
    }
}