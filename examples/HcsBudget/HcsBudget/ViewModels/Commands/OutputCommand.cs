using WorkflowLib.Examples.HcsBudget.ViewModels; 

namespace WorkflowLib.Examples.HcsBudget.Commands
{
    public class OutputCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM; 

        public OutputCommand(MainVM mainVm)
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
            if (parameterString == "ReloadData")
            {
                this.MainVM.ReloadData(); 
            }
            else if (parameterString == "Calculate")
            {
                this.MainVM.CalculateReport(); 
            }
            else if (parameterString == "Export")
            {
                this.MainVM.ExportReport(); 
            }
            else if (parameterString == "Clear")
            {
                this.MainVM.ClearReport(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString}", "Exception"); 
            }
        }
    }
}