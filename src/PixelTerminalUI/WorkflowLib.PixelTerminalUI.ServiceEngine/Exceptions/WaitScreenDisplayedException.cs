namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Exceptions;

public class WaitScreenDisplayedException : Exception
{
    public WaitScreenDisplayedException()
    {
    }

    public WaitScreenDisplayedException(string message)
        : base(message)
    {
    }

    public WaitScreenDisplayedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}