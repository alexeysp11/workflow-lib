﻿using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Exceptions;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// Class for configuring wait screen form.
/// </summary>
public class WaitScreen : IDisposable
{
    private bool _disposed;

    public WaitScreen(TextEditControl control)
    {
        if (control.ShowWaitScreen())
        {
            throw new WaitScreenDisplayedException();
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }
            _disposed = true;
        }
    }
}