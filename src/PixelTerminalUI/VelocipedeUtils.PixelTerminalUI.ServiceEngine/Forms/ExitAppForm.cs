namespace VelocipedeUtils.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// The form displayed before exiting the application.
/// </summary>
public class ExitAppForm : SimpleMessageForm
{
    protected override bool txtConfirmation_EnterValidation()
    {
        switch (txtConfirmation.Value.ToLower())
        {
            case "":
            case "-n":
            case "-b":
            case "n":
            case "no":
                txtConfirmation.Value = "";
                SessionInfo.CurrentForm = ParentForm;
                return true;

            case "y":
            case "yes":
                // Finish user session.
                txtConfirmation.Value = "";
                SessionInfo.FinishUserSession = true;
                ShowInformation("The user session has been terminated!");
                return true;
        }
        txtConfirmation.Value = "";
        return false;
    }
}
