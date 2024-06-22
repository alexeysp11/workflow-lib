using Chat.Client.ViewModel; 

namespace Chat.Client.Commands
{
    public class ExitCommand : System.Windows.Input.ICommand
    {
        private MainVM _MainVM; 
        
        public ExitCommand(MainVM mainVM)
        {
            _MainVM = mainVM; 
        }

        public event System.EventHandler CanExecuteChanged; 

        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            this._MainVM.CloseApp(); 
        }
    }
}