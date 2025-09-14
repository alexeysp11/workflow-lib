using VelocipedeUtils.Examples.FirmsAccounting.ViewModels;

namespace VelocipedeUtils.Examples.FirmsAccounting.Commands
{
    public class ClearCommand : System.Windows.Input.ICommand
    {
        private MainVM MainVM;

        public ClearCommand(MainVM mainVm)
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
                this.MainVM.ClearFirm();
            }
            else if (this.MainVM.MainWindow.Title == this.MainVM.MainWindow.DocWindowTitle)
            {
                this.MainVM.ClearDoc();
            }
            else
            {
                System.Windows.MessageBox.Show("Wrong title, unable to execute ClearCommand.", "Exception");
            }
        }
    }
}