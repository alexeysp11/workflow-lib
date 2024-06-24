using MeetPlanning.WpfVersion.ViewModels; 

namespace MeetPlanning.WpfVersion.Commands 
{
    public class RedirectCommand : System.Windows.Input.ICommand 
    {
        private MainVM MainVM; 

        public RedirectCommand(MainVM mainVm)
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
            if (parameterString == "MyAccount")
            {
                this.MainVM.RedirectToMyAccountPage(); 
            }
            else if (parameterString == "Partners")
            {
                this.MainVM.RedirectToPartnersPage(); 
            }
            else if (parameterString == "Meetings")
            {
                this.MainVM.RedirectToMeetingsPage(); 
            }
            else if (parameterString == "UpcomingEvents")
            {
                this.MainVM.RedirectToUpcomingEventsPage(); 
            }
            else if (parameterString == "History")
            {
                this.MainVM.RedirectToHistoryPage(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString} inside RedirectCommand", "Exception");
            }
        }
    }
}