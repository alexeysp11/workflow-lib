using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Controls;
using VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Forms;

namespace VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Applications;

public class frmAppsRelease : frmTerminalBase
{
    private TextControl? lblHeader;
    private TextControl? lblOperationName;
    private TextEditControl? txtUserInput;
    
    public frmAppsRelease() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmAppsRelease);
        
        lblHeader = new TextControl();
        lblHeader.Name = nameof(lblHeader);
        lblHeader.Top = 0;
        lblHeader.Left = 0;
        lblHeader.EntireLine = true;
        lblHeader.HorizontalAlignment = HorizontalAlignment.Center;
        lblHeader.Value = "PIXEL TERMINAL UI";
        lblHeader.Inverted = true;
        Controls.Add(lblHeader);

        lblOperationName = new TextControl();
        lblOperationName.Name = nameof(lblOperationName);
        lblOperationName.Top = 1;
        lblOperationName.Left = 0;
        lblOperationName.EntireLine = true;
        lblOperationName.Value = "APPLICATIONS. RELEASE";
        Controls.Add(lblOperationName);

        txtUserInput = new TextEditControl();
        txtUserInput.Name = nameof(txtUserInput);
        txtUserInput.Top = 6;
        txtUserInput.Left = 0;
        txtUserInput.EntireLine = true;
        txtUserInput.Hint = "PRESS ENTER TO CONTINUE";
        txtUserInput.EnterValidation = txtUserInput_EnterValidation;
        Controls.Add(txtUserInput);
    }

    private bool txtUserInput_EnterValidation()
    {
        try
        {
            switch (txtUserInput.Value)
            {
                case "":
                case "-n":
                case "-b":
                    SessionInfo.CurrentForm = ParentForm;
                    return true;
                
                default:
                    FocusedEditControl = txtUserInput;
                    return false;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            return false;
        }
        finally
        {
            txtUserInput.Value = "";
        }
    }
}