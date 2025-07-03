using WorkflowLib.PixelTerminalUI.ServiceEngine.Exceptions;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

/// <summary>
/// A control that allows you to process the user's password.
/// </summary>
public class PasswordEditControl : TextEditControl
{
    /// <summary>
    /// The next control of type <see cref="TextEditControl"/>,
    /// which will be displayed after successful validation of this control.
    /// </summary>
    public TextEditControl? NextNavigateControl { get; set; }

    /// <summary>
    /// The previous control of type <see cref="TextEditControl"/>,
    /// which will be displayed after the user navigates back from this control.
    /// </summary>
    public TextEditControl? PreviousNavigateControl { get; set; }

    /// <summary>
    /// The next form which will be displayed after successful validation of this control.
    /// </summary>
    public BaseForm? NextNavigateForm { get; set; }

    /// <summary>
    /// The previous form which will be displayed after successful validation of this control.
    /// </summary>
    public BaseForm? PreviousNavigateForm { get; set; }

    /// <summary>
    /// A control that contains username (for easier access to data that is necessary for credentials validation).
    /// </summary>
    public TextEditControl? UsernameEditControl { get; set; }

    /// <summary>
    /// Validate entered password.
    /// </summary>
    public Func<string, string, bool>? ValidatePassword { get; set; }

    /// <summary>
    /// Validated username.
    /// </summary>
    public string? Username { get; private set; }

    /// <summary>
    /// Validated password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Determines whether to show main menu if password is successfully validated.
    /// </summary>
    public bool ShowMainMenuOnSuccess { get; set; }

    /// <summary>
    /// Message that is displayed when password validation failed.
    /// </summary>
    public string? ValidationFailedMessage { get; set; }

    public PasswordEditControl()
    {
        EnterValidation = OnPasswordEntered;
    }

    /// <summary>
    /// Show current control.
    /// </summary>
    public override void Show()
    {
        if (SessionInfo?.CurrentForm == Form && Form?.FocusedEditControl == this)
        {
            // Reset password each time the control is focused.
            Value = "";
            SessionInfo.IsPasswordInputNeeded = true;
        }
        base.Show();
    }

    /// <summary>
    /// Processing entered password.
    /// </summary>
    /// <returns>true if password was successfully validated; otherwise, false</returns>
    private bool OnPasswordEntered()
    {
        try
        {
            // Reassign the input value, if the wait screen is displayed.
            if (SessionInfo?.WaitScreenDisplayed == true)
            {
                Value = SessionInfo?.SavedUserInput ?? "";
            }

            // Process input value.
            switch (Value)
            {
                case "":
                case "-n":
                    Form.FocusedEditControl = this;
                    Value = "";
                    return false;

                case "-b":
                    OnGoBackSelected();
                    Value = "";
                    return false;

                default:
                    using (var waitScreen = new WaitScreen(this))
                    {
                        if (ValidatePassword != null)
                        {
                            if (UsernameEditControl == null)
                            {
                                throw new Exception($"Could not validate password: '{nameof(UsernameEditControl)}' is not set");
                            }
                            if (!ValidatePassword(UsernameEditControl.Value, Value))
                            {
                                throw new Exception(ValidationFailedMessage ?? "Password validation failed");
                            }
                        }
                        else
                        {
                            throw new Exception($"Could not validate password: '{nameof(ValidatePassword)}' is not set");
                        }
                        SaveValidatedData();
                        if (ShowMainMenuOnSuccess)
                        {
                            if (Form?.ShowMainMenu != null)
                            {
                                Form?.ShowMainMenu();
                            }
                        }
                        else
                        {
                            OnGoNextSelected();
                        }
                    }
                    return true;
            }
        }
        catch (WaitScreenDisplayedException)
        {
            return true;
        }
        catch (Exception ex)
        {
            Form?.ShowError(ex.Message);
            Form.FocusedEditControl = this;
            return false;
        }
        return false;
    }

    /// <summary>
    /// Save validated data.
    /// </summary>
    private void SaveValidatedData()
    {
        Username = UsernameEditControl?.Value;
        Password = Value;
        Value = new string('*', Value.Length);

        SessionInfo.UserLogin = Username;
        SessionInfo.UserPassword = Password;
    }

    /// <summary>
    /// Navigate next.
    /// </summary>
    private void OnGoNextSelected()
    {
        if (NextNavigateForm != null)
        {
            SessionInfo.CurrentForm = NextNavigateForm;
            if (NextNavigateControl != null)
            {
                NextNavigateForm.FocusedEditControl = NextNavigateControl;
            }
        }
    }

    /// <summary>
    /// Navigate back.
    /// </summary>
    private void OnGoBackSelected()
    {
        if (PreviousNavigateForm != null)
        {
            SessionInfo.CurrentForm = PreviousNavigateForm;
            if (PreviousNavigateControl != null)
            {
                PreviousNavigateForm.FocusedEditControl = PreviousNavigateControl;
            }
        }
        Value = "";
    }
}
