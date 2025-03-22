using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using WorkflowLib.PixelTerminalUI.ConsoleAdapter.Helpers;
using WorkflowLib.PixelTerminalUI.ConsoleClient.Models;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Dto;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("PIXEL TERMINAL UI");
            Console.WriteLine();

            string serverIp = ConsoleHelper.EnterLine(hint: "Enter server IP (e.g. 127.0.0.1):", beforeInputString: ">>>");
            int port = GetPort("Enter port (e.g. 5000):");

            var communicationType = TerminalCommunicationType.Http;
            switch (communicationType)
            {
                case TerminalCommunicationType.Tcp:
                    await RunTcpAsync(serverIp, port);
                    break;
                
                case TerminalCommunicationType.Http:
                    await RunHttpAsync(serverIp, port);
                    break;
                
                case TerminalCommunicationType.Grpc:
                    //await RunGrpcAsync(serverIp, port);
                    break;
                
                default:
                    throw new Exception("Communication type is not implemented");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int GetPort(string hint, ConsoleColor? hintForegroundColor = null)
    {
        while (true)
        {
            string portString = ConsoleHelper.EnterLine(hint: hint, hintForegroundColor: hintForegroundColor, beforeInputString: ">>>");
            if (int.TryParse(portString, out int port))
            {
                return port;
            }
        }
    }

    static async Task RunTcpAsync(string serverIp, int port)
    {
        using (TcpClient client = new TcpClient(serverIp, port))
        {
            NetworkStream stream = client.GetStream();

            while (true)
            {
                // Response.
                byte[] responseData = new byte[1024];
                int bytesRead = await stream.ReadAsync(responseData, 0, responseData.Length);
                string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytesRead);
                ConsoleHelper.WriteStringInColor(responseMessage);

                // Request.
                string requestMessage = ConsoleHelper.EnterLine(hint: "Enter data:", emptyStringReplacement: "-n", beforeInputString: ">>>");
                byte[] requestData = Encoding.UTF8.GetBytes(requestMessage);
                await stream.WriteAsync(requestData, 0, requestData.Length);
            }
        }
    }

    static async Task RunHttpAsync(string serverIp, int port)
    {
        // Enter session UID to be able to restore previous session.
        string sessionUid = ConsoleHelper.EnterLine(hint: "Enter session UID:", beforeInputString: ">>>", allowEmptyString: true);

        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };
        using (var httpClient = new HttpClient(handler))
        {
            httpClient.Timeout = TimeSpan.FromMinutes(25);

            SessionInfoDto? sessionInfoDto = null;
            if (!string.IsNullOrEmpty(sessionUid))
            {
                sessionInfoDto = new SessionInfoDto
                {
                    SessionUid = sessionUid
                };
            }

            // Start position of the console.
            Console.WriteLine();
            int startCursorLeft = Console.CursorLeft;
            int startCursorTop = Console.CursorTop;

            while (true)
            {
                // Request.
                if (sessionInfoDto != null)
                {
                    string userInput = ConsoleHelper.EnterLine(
                        hint: "Enter data:",
                        emptyStringReplacement: "-n",
                        beforeInputString: ">>>",
                        maxInputCharNumber: sessionInfoDto?.UserInputWdith);
                    sessionInfoDto.UserInput = userInput;
                    sessionInfoDto.DisplayedInfo = string.Empty;
                    sessionInfoDto.SavedDisplayedInfo = string.Empty;
                }
                using HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://{serverIp}:{port}/pixelterminalui/go", sessionInfoDto);

                // // Response.
                response.EnsureSuccessStatusCode();
                sessionInfoDto = await response.Content.ReadFromJsonAsync<SessionInfoDto>();
                Console.CursorLeft = startCursorLeft;
                Console.CursorTop = startCursorTop;
                Console.WriteLine("Session UID: " + sessionInfoDto?.SessionUid);
                ConsoleHelper.WriteStringInColor(sessionInfoDto?.DisplayedInfo);
            }
        }
    }
}
