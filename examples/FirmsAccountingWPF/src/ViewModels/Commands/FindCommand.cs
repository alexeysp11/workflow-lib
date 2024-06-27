using WorkflowLib.Examples.FirmsAccounting.ViewModels; 

namespace WorkflowLib.Examples.FirmsAccounting.Commands
{
    public class FindCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM; 

        public FindCommand(MainVM mainVm)
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
            if (this.MainVM.MainWindow.Title == this.MainVM.MainWindow.FirmWindowTitle)
            {
                this.MainVM.FindFirm(); 
            }
            else if (this.MainVM.MainWindow.Title == this.MainVM.MainWindow.DocWindowTitle)
            {
                this.MainVM.FindDoc(); 
            }
            else
            {
                System.Windows.MessageBox.Show("Wrong title, unable to execute FindCommand.", "Exception"); 
            }
        }
    }
}