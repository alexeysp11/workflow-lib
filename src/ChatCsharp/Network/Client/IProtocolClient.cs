namespace Chat.Network.Client 
{
    /// <summary>
    /// Common interface for all protocols using in this application 
    /// </summary>
    public interface IProtocolClient
    {
        void SendMessage(string message, bool isConfig=true);
        string GetMessages();
        void CloseConnection(); 
    }
}