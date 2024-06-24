using MeetPlanning.WpfVersion.Controllers; 
using MeetPlanning.WpfVersion.ViewModels; 

namespace MeetPlanning.WpfVersion.Commands 
{
    public class ExitCommand : System.Windows.Input.ICommand 
    {
        private MainVM MainVM; 

        public ExitCommand(MainVM mainVm)
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
            if (this.MainVM.UserRepository.IsAuthenticated)
            {
                this.MainVM.UserRepository.IsAuthenticated = false; 
                this.MainVM.RedirectToWelcomePage(); 
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}