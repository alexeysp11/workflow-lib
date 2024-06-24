using MeetPlanning.WpfVersion.Controllers; 
using MeetPlanning.WpfVersion.ViewModels; 

namespace MeetPlanning.WpfVersion.Commands 
{
    public class HelpCommand : System.Windows.Input.ICommand 
    {
        private MainVM MainVM; 

        public HelpCommand(MainVM mainVm)
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
            System.Windows.MessageBox.Show("Information about the application", "Help"); 
        }
    }
}