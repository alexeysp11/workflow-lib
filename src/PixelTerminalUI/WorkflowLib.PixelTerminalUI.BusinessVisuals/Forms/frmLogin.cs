using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

public class frmLogin : BaseForm
{
    private TextControl? lblHeader;
    public frmLogin() : base()
    {
        Name = nameof(frmLogin);
    }
    
    protected override void InitializeComponent()
    {
        lblHeader = new TextControl();
        lblHeader.Name = nameof(lblHeader);
        lblHeader.Top = 0;
        lblHeader.Left = 0;
        lblHeader.EntireLine = true;
        lblHeader.HorizontalAlignment = HorizontalAlignment.Center;
        lblHeader.Value = "PIXEL TERMINAL UI";
        lblHeader.Inverted = true;
        Controls.Add(lblHeader);
    }
}