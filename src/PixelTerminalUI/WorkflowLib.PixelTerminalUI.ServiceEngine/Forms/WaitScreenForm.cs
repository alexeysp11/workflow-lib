namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// Wait screen form.
/// </summary>
public class WaitScreenForm : SimpleMessageForm
{
    protected override bool txtConfirmation_EnterValidation()
    {
        switch (txtConfirmation.Value)
        {
            case "":
            case "-n":
            case "-b":
                txtConfirmation.Value = "";
                SessionInfo.CurrentForm = ParentForm;
                SessionInfo.WaitScreenSkipped = true;
                return true;
        }
        txtConfirmation.Value = "";
        return false;
    }
}