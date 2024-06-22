using Chat.Network.Server; 

namespace Chat.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("WELCOME TO THE CHAT SERVER");

            while (true)
            {
                try
                {
                    IProtocolListener listener = new ChatTcpListener(); 
                    listener.Listen(); 
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Exception:\n{ex}");
                }
            }
        }
    }
}
