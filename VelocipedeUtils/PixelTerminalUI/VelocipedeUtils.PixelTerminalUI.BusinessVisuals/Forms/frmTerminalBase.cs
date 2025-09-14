using VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Info;
using VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Menu;
using VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Settings;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Forms;

namespace VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Forms;

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
        ShowForm(new frmInfoAboutEntireApp { Header = "INFO ABOUT THE APP" });
    }
}