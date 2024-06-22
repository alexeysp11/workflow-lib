namespace Chat.Network.Messages
{
    public struct Message
    {
        public byte ClientId { get; private set; } 
        public byte MsgId { get; private set; } 

        public byte[] TextBytes { get; private set; } 
        public string TextString 
        {
            get { return System.Text.Encoding.ASCII.GetString(TextBytes); }
        }
        public string MessageString
        {
            get { return $"{TextString}"; }
        }

        public Message(byte clientId, byte msgId, byte[] textBytes)
        {
            ClientId = clientId; 
            MsgId = msgId;
            TextBytes = textBytes; 
        }
    }
}