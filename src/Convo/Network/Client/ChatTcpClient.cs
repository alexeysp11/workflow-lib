using System.Net.Sockets; 
using Chat.Network.Messages; 

namespace Chat.Network.Client 
{
    public class ChatTcpClient : IProtocolClient
    {
        #region Configuration properties
        private TcpClient Client { get; set; } = null; 
        private NetworkStream _NetworkStream { get; set; } = null; 

        public string Ip { get; }
        public string ServerName { get; private set; }
        private int Port { get; }
        #endregion  // Configuration properties

        #region Messaging properties
        private string Username { get; set; } 
        private byte ClientId { get; set; }
        
        private byte MessageHeader { get; set; }
        private byte[] MessageBytes; 

        private string ResponseString; 
        private byte[] ResponseBytes; 

        private byte LastMsgId; 
        #endregion  // Messaging properties

        #region Constructors
        /// <summary>
        /// Default constructor for ChatTcpClient class
        /// </summary>
        /// <param name="username">Name of a user</param>
        public ChatTcpClient(string username)
        {
            this.Ip = "127.0.0.0"; 
            this.ServerName = "localhost"; 
            this.Port = 13000;
            this.Username = username; 
            this.CreateClient(); 
        }

        /// <summary>
        /// Alternative constructor of ChatTcpClient class 
        /// </summary>
        /// <param name="ip">Port of a TCP client</param>
        /// <param name="serverName">Name of a TCP server</param>
        /// <param name="port">Port of a TCP client</param>
        /// <param name="username">Name of a user</param>
        public ChatTcpClient(string ip, string serverName, int port, string username)
        {
            this.Ip = ip;
            this.ServerName = serverName; 
            this.Port = port;
            this.Username = username;
            this.CreateClient(); 
        }
        #endregion  // Constructors
        
        #region Authentication
        private void CreateClient()
        {
            this.ClientId = 0; 
            this.MessageHeader = (byte)(Header.PURPOSE_AUTH | Header.ERROR_NO); 
            try
            {
                this.SendMessage($"User {this.Username} connected"); 
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        #endregion  // Authentication

        #region Sending messages 
        /// <summary>
        /// Allows to send data to the server 
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="isClientToClient">
        /// Boolean variable for getting if a message should be sent to other clients (false by default)
        /// </param>
        public void SendMessage(string message, bool isClientToClient=false)
        {
            if (isClientToClient)
            {
                this.MessageHeader = (byte)(Header.PURPOSE_CTC | Header.ERROR_NO); 
            }
            this.CreateMsgBytes(message); 

            try
            {
                if (this.Client == null)
                {
                    this.Client = new TcpClient(this.ServerName, this.Port);
                }
                this._NetworkStream = this.Client.GetStream();
                this._NetworkStream.Write(this.MessageBytes, 0, this.MessageBytes.Length);
                
                this.ResponseBytes = new byte[1024]; 
                int msgLength = 0; 
                msgLength = this._NetworkStream.Read(this.ResponseBytes, 0, this.ResponseBytes.Length);
                if (msgLength > 0)
                {
                    this.DecodeResponse(msgLength);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                this.MessageBytes = new byte[1];
                this.ResponseBytes = new byte[1];
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Creates bytes that need to be sent to the server 
        /// </summary>
        /// <param name="message">String representation of a message that needs to be sent</param>
        private void CreateMsgBytes(string message)
        {
            if (this.MessageHeader == (byte)(Header.PURPOSE_CTC | Header.ERROR_NO))
            {
                byte[] text = System.Text.Encoding.ASCII.GetBytes(message); 
                MessageBytes = new byte[text.Length + 2]; 
                MessageBytes[0] = this.ClientId; 
                MessageBytes[1] = this.MessageHeader; 
                for (int i = 0; i < text.Length; i++)
                {
                    MessageBytes[i+2] = text[i]; 
                }
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_AUTH | Header.ERROR_NO))
            {
                MessageBytes = new byte[2] { ClientId, MessageHeader }; 
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_EXIT | Header.ERROR_NO))
            {
                
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_NO))
            {
                MessageBytes = new byte[3] { ClientId, MessageHeader, LastMsgId }; 
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_ERRMSG | Header.ERROR_NO))
            {
                
            }
            else
            {
                // Something went wrong, it's necessary to send error report. 
            }
        }
        #endregion  // Sending messages 

        #region Getting messages
        public string GetMessages()
        {
            this.MessageHeader = (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_NO); 
            this.SendMessage(string.Empty); 
            string response = this.ResponseString; 
            return response; 
        }

        private void DecodeResponse(int msgLength)
        {
            if (msgLength == 0)
            {
                throw new System.Exception("Server did not send response"); 
            }

            if (this.MessageHeader == (byte)(Header.PURPOSE_CTC | Header.ERROR_NO))
            {
                LastMsgId = ResponseBytes[2]; 
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_AUTH | Header.ERROR_NO))
            {
                ClientId = ResponseBytes[0]; 
                LastMsgId = ResponseBytes[2]; 
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_EXIT | Header.ERROR_NO))
            {
                
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_NO))
            {
                if ( (byte)(Header.ERROR_NO) == (this.ResponseBytes[1] & (byte)Header.ERROR_NO) )
                {
                    int indexTextStarts = 3;
                    LastMsgId = this.ResponseBytes[2]; 
                    this.ResponseString = System.Text.Encoding.ASCII.GetString(this.ResponseBytes, indexTextStarts, msgLength - indexTextStarts); 
                }
                else if ( (byte)(Header.ERROR_YES) == (this.ResponseBytes[1] & (byte)Header.ERROR_YES) )
                {
                    this.ResponseString = string.Empty; 
                }
                else
                {
                    // Something went wrong, figure out what's the error. 
                }
            }
            else if (this.MessageHeader == (byte)(Header.PURPOSE_ERRMSG | Header.ERROR_NO))
            {

            }
            else
            {
                // Something went wrong, it's necessary to send error report. 
            }
        }
        #endregion  // Getting messages

        #region Closing connection 
        /// <summary>
        /// Allows to close everything (including network stream and client)
        /// </summary>
        public void CloseConnection()
        {
            if (this.Client != null)
            {
                try
                {
                    if (this._NetworkStream != null)
                        this._NetworkStream.Close();
                    this.Client.Close();
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
                finally
                {
                    this.Client = null; 
                }
            }
        }
        #endregion  // Closing connection 
    }
}