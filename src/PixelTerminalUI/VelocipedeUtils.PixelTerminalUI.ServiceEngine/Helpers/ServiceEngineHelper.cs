using System.Net.Sockets;
using System.Text;
using VelocipedeUtils.PixelTerminalUI.ConsoleAdapter.Helpers;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Models;

namespace VelocipedeUtils.PixelTerminalUI.ServiceEngine.Helpers;

public static class ServiceEngineHelper
{
    public static async Task<string> ReadMessageTcpAsync(NetworkStream stream, int inputByteArraySize = 256)
    {
        byte[] messageData = new byte[inputByteArraySize];
        int bytesRead = await stream.ReadAsync(messageData, 0, messageData.Length);
        return Encoding.UTF8.GetString(messageData, 0, bytesRead);
    }

    public static async Task SendMessageTcpAsync(NetworkStream stream, string message)
    {
        byte[] resultBytes = Encoding.UTF8.GetBytes(message);
        await stream.WriteAsync(resultBytes, 0, resultBytes.Length);
    }

    public static void LogForm(SessionInfo sessionInfo, bool displayBorders = false)
    {
        if (sessionInfo == null)
        {
            throw new ArgumentNullException($"Parameter '{nameof(sessionInfo)}' could not be null");
        }

        ConsoleHelper.PrintDisplayedInfo(sessionInfo.DisplayedInfo, displayBorders);
    }

    public static async Task SendFormTcpAsync(NetworkStream stream, SessionInfo sessionInfo, bool displayBorders = false)
    {
        if (stream == null)
        {
            throw new ArgumentNullException($"Parameter '{nameof(stream)}' could not be null");
        }
        if (sessionInfo == null)
        {
            throw new ArgumentNullException($"Parameter '{nameof(sessionInfo)}' could not be null");
        }
        if (sessionInfo.DisplayedInfo == null)
        {
            throw new ArgumentNullException($"Parameter '{nameof(sessionInfo.DisplayedInfo)}' could not be null");
        }

        string message = ConsoleHelper.GetDisplayedInfoString(sessionInfo.DisplayedInfo, displayBorders);
        await SendMessageTcpAsync(stream, message);
    }

    public static void SaveForm(SessionInfo sessionInfo)
    {
        // 
    }

    public static void RestoreForm(SessionInfo sessionInfo)
    {
        // 
    }
}