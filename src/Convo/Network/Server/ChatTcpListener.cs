using System; 
using System.Collections.Generic; 
using System.Net; 
using System.Net.Sockets; 
using Chat.Network.Messages; 

namespace Chat.Network.Server
{
    public class ChatTcpListener : IProtocolListener
    {
        #region Configurational properties 
        private TcpListener Listener { get; } 
        private TcpClient Client { get; set; } 
        
        public IPAddress Ip { get; }
        public string ServerName { get; private set; }
        private int Port { get; }
        
        private byte[] ReceivedBytes;
        private byte[] ResponseBytes; 

        private Message[] MsgBuf = new Message[10];

        private bool IsNeedToPrintStatus = true; 

        private byte clientId = 0; 
        private byte ClientId 
        {
            get { return clientId; } 
            set
            {
                if (value > 255)
                {
                    value = 0; 
                }
                clientId = value; 
            }
        } 
        
        private byte msgId = 0; 
        public byte MsgId 
        {
            get { return msgId; }
            set 
            {
                if (value > msgId)
                { 
                    msgId = value; 
                }
                else if (value > 255)
                {
                    msgId = 0; 
                }
            }
        }
        #endregion  // Configurational properties 

        #region Constructors
        public ChatTcpListener()
        {
            this.Ip = IPAddress.Parse("127.0.0.1"); 
            this.ServerName = "localhost"; 
            this.Port = 13000; 
            this.Listener = new TcpListener(this.Ip, this.Port);
        }

        public ChatTcpListener(string ip, string serverName, int port)
        {
            this.Ip = IPAddress.Parse(ip);
            this.ServerName = serverName; 
            this.Port = port;
            this.Listener = new TcpListener(this.Ip, this.Port);
        }
        #endregion  // Constructors

        #region Listen methods
        public void Listen()
        {
            try
            {
                this.Listener.Start();
                while(true)
                {
                    if (IsNeedToPrintStatus)
                    {
                        System.Console.Write("[OK] ");
                    }
                    else
                    {
                        IsNeedToPrintStatus = true; 
                    }
                    GetMessage();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                this.Client.Close();        // Shutdown and end connection. 
                this.Listener.Stop();       // Stop listening for new clients.
            }
        }

        private void GetMessage()
        {
            ReceivedBytes = new byte[256]; 
            try
            {
                this.Client = this.Listener.AcceptTcpClient();
                NetworkStream stream = this.Client.GetStream();
                
                int msgLength = stream.Read(ReceivedBytes, 0, ReceivedBytes.Length); 
                
                this.ProcessReceivedBytes(msgLength);
                stream.Write(ResponseBytes, 0, ResponseBytes.Length); 
            }
            catch (System.Exception e)
            {
                throw e;
            }
            ReceivedBytes = new byte[1]; 
            ResponseBytes = new byte[1]; 
        }
        #endregion  // Listen methods

        #region Bytes processing
        private void ProcessReceivedBytes(int msgLength)
        {
            if (ReceivedBytes[1] == (byte)(Header.PURPOSE_CTC | Header.ERROR_NO))
            {
                this.InsertMessageIntoBuffer(msgLength); 
            }
            else if (ReceivedBytes[1] == (byte)(Header.PURPOSE_AUTH | Header.ERROR_NO))
            {
                this.AuthenticateClient(); 
            }
            else if (ReceivedBytes[1] == (byte)(Header.PURPOSE_EXIT | Header.ERROR_NO))
            {
                
            }
            else if (ReceivedBytes[1] == (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_NO))
            {
                this.GetMessages(); 
            }
            else if (ReceivedBytes[1] == (byte)(Header.PURPOSE_ERRMSG | Header.ERROR_NO))
            {
                
            }
            else
            {
                this.GetErrorResponse(); 
            }
        }
        #endregion  // Bytes processing

        #region Authentication
        private void AuthenticateClient()
        {
            IsNeedToPrintStatus = false; 
            this.ClientId += 1; 
            byte header = (byte)(Header.PURPOSE_AUTH | Header.ERROR_NO); 
            ResponseBytes = new byte[3] { this.ClientId, header, this.MsgId }; 
        }
        #endregion  // Authentication

        #region Inserting messages
        private void InsertMessageIntoBuffer(int msgLength)
        {
            // Get bytes of a text from the received bytes. 
            int numConfigBytes = 2; 
            byte[] textBytes = new byte[msgLength - numConfigBytes]; 
            for (int i = 0; i < textBytes.Length; i++)
            {
                textBytes[i] = ReceivedBytes[i + numConfigBytes]; 
            }

            // Add new message to the buffer. 
            this.MsgId++; 
            this.ShiftMsgBuffer();
            this.MsgBuf[0] = new Message(ReceivedBytes[0], this.MsgId, textBytes);

            // Create response array. 
            byte header = (byte)(Header.PURPOSE_CTC | Header.ERROR_NO); 
            this.ResponseBytes = new byte[3] { ReceivedBytes[0], header, MsgBuf[0].MsgId }; 
            
            System.Console.WriteLine($"{this.MsgBuf[0].MessageString}");
        }

        private void ShiftMsgBuffer()
        {
            for (int i = MsgBuf.Length - 1; i >= 0 ; i--)
            {
                MsgBuf[i] = (i == 0) ? MsgBuf[0] : MsgBuf[i-1]; 
            }
        }
        #endregion  // Inserting messages

        #region Getting messages
        private void GetMessages()
        {
            // Is the client sending correct index inside the request for messages? 
            // Check if there was no messages in the chat (ID of a current message is 
            // equal to zero) and create a response for client that the chat is empty.
            int index = GetIndexInMsgBuf(ReceivedBytes[2]); 
            if ((index < 0) || (index > MsgBuf.Length - 1))
            {
                this.GetErrorResponse(); 
            }
            else
            {
                int numConfigBytes = 3; 
                byte[] textBytes = GetMsgBytes(index); 
                this.ResponseBytes = new byte[textBytes.Length + numConfigBytes]; 
                ResponseBytes[0] = ReceivedBytes[0]; 
                ResponseBytes[1] = (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_NO);
                ResponseBytes[2] = MsgId; 
                for (int i = 0; i < textBytes.Length; i++)
                {
                    ResponseBytes[i + numConfigBytes] = textBytes[i]; 
                }
                IsNeedToPrintStatus = false; 
            }
        }

        private int GetIndexInMsgBuf(byte msgId)
        {
            if (MsgId == 0)
            {
                return -2;
            }
            else if (MsgId == msgId)
            {
                return -3;
            }
            else if (MsgId < msgId)
            {
                return -4; 
            }

            for (int i = 0; i < MsgBuf.Length; i++)
            {
                if (MsgBuf[i].MsgId == msgId) 
                {
                    return i; 
                }
            }
            return -1; 
        }

        private byte[] GetMsgBytes(int index)
        {
            string msg = string.Empty; 
            for (int i = index - 1; i >= 0; i--)
            {
                msg += MsgBuf[i].MessageString;
            }
            return System.Text.Encoding.ASCII.GetBytes(msg); 
        }
        #endregion  // Getting messages

        #region Error handling 
        private void GetErrorResponse()
        {
            IsNeedToPrintStatus = false; 
            byte header = (byte)(Header.PURPOSE_MSGRQST | Header.ERROR_YES); 
            this.ResponseBytes = new byte[3] { ReceivedBytes[0], header, MsgId }; 
        }
        #endregion  // Error handling 
    }
}