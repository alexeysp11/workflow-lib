using Chat.Client.ViewModel; 

namespace Chat.Client.Commands
{
    public class SendMsgCommand : System.Windows.Input.ICommand
    {
        private MainVM _MainVM { get; set; }

        public SendMsgCommand(MainVM mainVM)
        {
            _MainVM = mainVM; 
        }

        public event System.EventHandler CanExecuteChanged; 

        public bool CanExecute(object parameter)
        {
            bool result = true; 
            try
            {
                if (this._MainVM.ActiveWindow.UserPage.IsEnabled && 
                    this._MainVM.ActiveWindow.UserPage.Visibility == System.Windows.Visibility.Visible)
                {
                    result = true; 
                }
                else
                {
                    result = false; 
                }
            }
            catch (System.Exception e)
            {
                System.Windows.MessageBox.Show($"Exception inside CommandParameter:\n{e}", "Exception"); 
            }
            return result; 
        }

        public void Execute(object parameter)
        {
            string parameterString = parameter as string; 
            if (parameterString == "Send")
            {
                this._MainVM.SendMessage(); 
            }
            else
            {
                System.Windows.MessageBox.Show($"Incorrect CommandParameter: {parameterString} inside SendMsgCommand", "Exception"); 
            }
        }
    }
}