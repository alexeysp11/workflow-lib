namespace Banking.CoreServer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Start core server"); 

            string fullpath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\coreserver\\config.json"); 
            (new BankingHttpServer(fullpath)).CreateWebServer();
            System.Console.ReadLine();
        }
    }
}
