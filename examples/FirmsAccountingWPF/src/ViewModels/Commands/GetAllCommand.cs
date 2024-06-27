using WorkflowLib.Examples.FirmsAccounting.ViewModels; 

namespace WorkflowLib.Examples.FirmsAccounting.Commands
{
    public class GetAllCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM; 

        public GetAllCommand(MainVM mainVm)
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
                this.MainVM.GetAllFirms(); 
            }
            else if (this.MainVM.MainWindow.Title == this.MainVM.MainWindow.DocWindowTitle)
            {
                this.MainVM.GetAllDocs();
            }
            else
            {
                System.Windows.MessageBox.Show("Wrong title, unable to execute GetAllCommand.", "Exception"); 
            }
        }
    }
}