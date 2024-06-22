using System.ComponentModel;

namespace Chat.Client.ViewModel
{
    public class DispMsgVM : INotifyPropertyChanged
    {
        private MainVM _MainVM { get; set; }
        
        #region Properties
        private string messagesInChat;
        public string MessagesInChat
        {
            get { return messagesInChat; }
            set 
            {
                messagesInChat = value;
                OnPropertyChanged("MessagesInChat");
            }
        }
        
        private string messageToSend; 
        public string MessageToSend 
        {
            get { return messageToSend; } 
            set
            {
                messageToSend = value; 

                // Notify about length of a string. 
                this._MainVM.SetNumAvailableCharsInMsg(messageToSend.Length); 

                OnPropertyChanged("MessageToSend");
            }
        }

        private string charsAvailable;
        public string CharsAvailable
        {
            get { return charsAvailable; }
            set 
            { 
                charsAvailable = value; 
                OnPropertyChanged("CharsAvailable");
            }
        }
        #endregion  // Properties

        public DispMsgVM(MainVM mainVM)
        {
            this._MainVM = mainVM;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(PropertyName);
                handler(this, e);
            }
        }
    }
}