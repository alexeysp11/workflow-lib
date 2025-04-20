using WorkflowLib.PixelTerminalUI.BusinessVisuals.Info;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Settings;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

public abstract class frmTerminalBase : BaseForm
{
    public frmTerminalBase() : base()
    {
        ShowMainMenu = OnShowMainMenu;
        ShowSettings = OnShowSettings;
        ShowHelpForEntireApp = OnShowHelpForEntireApp;
    }

    private void OnShowMainMenu()
    {
        ShowForm(new frmMenu());
    }

    private void OnShowSettings()
    {
        ShowForm(new frmSettings { Header = "SETTINGS" });
    }

    private void OnShowHelpForEntireApp()
    {
        ShowForm(new frmHelpForEntireApp { Header = "INFO ABOUT THE APP" });
    }
}