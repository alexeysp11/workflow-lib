using System.Net;
using System.Net.Sockets;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Helpers;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

namespace TcpHostedService;

public class TcpServerService : IHostedService
{
    private TcpListener _listener;
    private readonly int _port = 5000;
    private CancellationTokenSource _cts;
    private AppSettings _appSettings;

    public TcpServerService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    /// <summary>
    /// Start the service.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _listener = new TcpListener(IPAddress.Any, _port);
        _listener.Start();

        _ = Task.Run(() => AcceptClientsAsync(_cts.Token));

        return Task.CompletedTask;
    }

    /// <summary>
    /// Accept clients.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    private async Task AcceptClientsAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var client = await _listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client, cancellationToken);
        }
    }

    /// <summary>
    /// Handle client.
    /// </summary>
    /// <param name="client">Instance of <see cref="TcpClient"/></param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        using (client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                System.Console.WriteLine("Client connected");
                
                var menuFormResolver = new MenuFormResolver(_appSettings);
                SessionInfo sessionInfo = menuFormResolver.InitSession();
                menuFormResolver.Start();

                while (true)
                {
                    await ServiceEngineHelper.SendFormTcpAsync(stream, sessionInfo, displayBorders: true);

                    string userInput = await ServiceEngineHelper.ReadMessageTcpAsync(stream);
                    menuFormResolver.ProcessUserInput(userInput);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    /// <summary>
    /// Stop the service.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _listener.Stop();
        _cts.Cancel();
        return Task.CompletedTask;
    }
}
