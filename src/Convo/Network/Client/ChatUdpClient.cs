namespace Chat.Network.Client 
{
    /// <summary>
    /// UDP client for this application 
    /// </summary>
    public class ChatUdpClient : IProtocolClient
    {
        /// <summary>
        /// Allows to send data to the server 
        /// </summary>
        /// <param name="message">Message to send</param>
        public void SendMessage(string message, bool isConfig=true)
        {
            
        }

        public string GetMessages()
        {
            return string.Empty; 
        }

        public void CloseConnection()
        {
            
        }
    }
}