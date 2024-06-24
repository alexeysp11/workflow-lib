using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.Commands
{
    public class InputCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM; 

        public InputCommand(MainVM mainVm)
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
            if (parameterString == "AddService")
            {
                this.MainVM.AddService(); 
            }
            else if (parameterString == "EditService")
            {
                this.MainVM.EditService(); 
            }
            else if (parameterString == "DeleteService")
            {
                this.MainVM.DeleteService(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString}", "Exception"); 
            }
        }
    }
}