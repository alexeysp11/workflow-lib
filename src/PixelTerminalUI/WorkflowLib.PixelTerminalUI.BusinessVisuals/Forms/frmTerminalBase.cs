using WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

public abstract class frmTerminalBase : BaseForm
{
    public frmTerminalBase() : base()
    {
        ShowMainMenu = ShowMainMenu_Clicked;
    }

    private void ShowMainMenu_Clicked()
    {
        ShowForm(new frmMenu());
    }
}