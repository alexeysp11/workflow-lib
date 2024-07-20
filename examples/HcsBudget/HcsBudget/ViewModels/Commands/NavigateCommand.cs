using WorkflowLib.Examples.HcsBudget.ViewModels;

namespace WorkflowLib.Examples.HcsBudget.Commands
{
    public class NavigateCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM;

        public NavigateCommand(MainVM mainVm)
        {
            this.MainVM = mainVm;
        }

        public event System.EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string parameterString = parameter as string;
            if (parameterString == "Settings")
            {
                this.MainVM.OpenSettingsWindow();
            }
            else if (parameterString == "Find")
            {
                this.MainVM.OpenFindWindow();
            }
            else if (parameterString == "Service")
            {
                this.MainVM.OpenServiceWindow();
            }
            else if (parameterString == "GitHubAccount")
            {
                this.MainVM.OpenGitHubAcount();
            }
            else if (parameterString == "UserDocsAbout")
            {
                this.MainVM.OpenUserDocs("About");
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString}", "Exception");
            }
        }
    }
}