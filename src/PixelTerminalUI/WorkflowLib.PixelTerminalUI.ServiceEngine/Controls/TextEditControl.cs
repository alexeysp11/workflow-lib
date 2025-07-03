namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

/// <summary>
/// Text input field.
/// </summary>
public class TextEditControl : TextControl
{
    /// <summary>
    /// Determines whether user input is required for the control.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// The character displayed in place of the empty input (for example, if the empty symbol is ".",
    /// then "VALUE...." may be displayed for the control).
    /// </summary>
    public string EmptyEnterSymbol { get; set; }

    /// <summary>
    /// A hint displayed at the bottom of a form to indicate which control is expecting user input.
    /// </summary>
    public string? Hint { get; set; }

    /// <summary>
    /// Default value of the control.
    /// </summary>
    public string? DefaultValue {  get; set; }

    /// <summary>
    /// Validating user input.
    /// </summary>
    public Func<bool>? EnterValidation { get; set; }

    /// <summary>
    /// Display the control information.
    /// </summary>
    public Action? ShowInfoAboutControl { get; set; }

    /// <summary>
    /// The next text input field which is used for displaying controls.
    /// </summary>
    public TextEditControl? NextEditControl { get; set; }

    /// <summary>
    /// The previous text input field which is used for displaying controls.
    /// </summary>
    public TextEditControl? PreviousEditControl { get; set; }

    public TextEditControl() : base()
    {
        Editable = true;
        Required = true;
        EmptyEnterSymbol = ".";
    }

    /// <summary>
    /// Show current control.
    /// </summary>
    public override void Show()
    {
        if (!OnShowValidation())
        {
            return;
        }

        if (PreviousEditControl != null)
        {
            PreviousEditControl.Show();
        }

        AddControlToForm();
    }

    /// <summary>
    /// Validation performed during control display.
    /// </summary>
    /// <returns>true if the validation was performed correctly; otherwise, false</returns>
    public override bool OnShowValidation()
    {
        if (!base.OnShowValidation())
        {
            return false;
        }
        return Required;
    }

    /// <summary>
    /// Validation performed during user input processing.
    /// </summary>
    /// <returns>true if the validation was performed correctly; otherwise, false</returns>
    public virtual bool OnEnterValidation()
    {
        if (Value == null)
        {
            Value = "";
        }
        if (Value.Length > Width)
        {
            if (Form != null)
            {
                Form.ShowWarning($"Entered string is too long.\nAcceptable string:\n\n{Value.Substring(0, Width)}");
            }
            Value = "";
            return true;
        }
        if (ValidateSpecialChars())
        {
            return true;
        }
        if (EnterValidation != null)
        {
            return EnterValidation();
        }
        return true;
    }

    /// <summary>
    /// Getting and processing user input.
    /// </summary>
    public void GetUserInput()
    {
        if (SessionInfo?.UserInputProcessed == false)
        {
            string userInput = SessionInfo?.UserInput ?? "";
            Value = userInput;
            if (SessionInfo != null)
            {
                SessionInfo.UserInput = null;
                SessionInfo.UserInputProcessed = true;
            }
            OnEnterValidation();
        }
    }

    /// <summary>
    /// Method for adding control to form.
    /// </summary>
    public override void AddControlToForm()
    {
        int width = 0;
        int left = Left;
        int top = Top;

        if (EntireLine)
        {
            Width = SessionInfo.FormWidth;
        }

        // Display empty enter symbol.
        for (int i = left; i < Width; i++)
        {
            if (top >= SessionInfo.DisplayedInfo.GetLength(0))
            {
                break;
            }
            SessionInfo.DisplayedInfo[top, i] = EmptyEnterSymbol;
        }

        // Display value.
        foreach (char ch in Value)
        {
            if (width >= Width)
            {
                break;
            }
            if (top >= SessionInfo.DisplayedInfo.GetLength(0) || left >= SessionInfo.DisplayedInfo.GetLength(1))
            {
                break;
            }

            string charToInsert = (Inverted ? "[" : "") + ch + (Inverted ? "]" : "");
            SessionInfo.DisplayedInfo[top, left] = charToInsert;

            left += 1;
            width += 1;
        }

        // Display hint.
        int lastRowIndex = SessionInfo.DisplayedInfo.GetLength(0) - 1;
        for (int i = 0; i < Width; i++)
        {
            SessionInfo.DisplayedInfo[lastRowIndex, i] = " ";
        }
        string? hint = SessionInfo.CurrentForm?.FocusedEditControl?.Hint;
        if (!string.IsNullOrEmpty(hint))
        {
            int i = 0;
            foreach (var ch in hint)
            {
                if (i >= (Form?.Width ?? Width))
                {
                    break;
                }
                SessionInfo.DisplayedInfo[lastRowIndex, i] = $"{ch}";
                i += 1;
            }
        }
    }

    /// <summary>
    /// Validation of special characters.
    /// </summary>
    /// <returns>true if special characters validation was performed; otherwise, false</returns>
    private bool ValidateSpecialChars()
    {
        switch (Value)
        {
            case "-q":
                // Exit the application.
                Form?.ShowExitAppForm();
                Value = "";
                break;
            
            case "-m":
                // Go to the main menu.
                if (Form?.ShowMainMenu != null)
                {
                    Form?.ShowMainMenu();
                }
                Value = "";
                break;
            
            case "-c":
                // Settings.
                if (Form?.ShowSettings != null)
                {
                    Form?.ShowSettings();
                }
                Value = "";
                break;

            case "-h":
                // Help/information (for the entire app).
                if (Form?.ShowHelpForEntireApp != null)
                {
                    Form?.ShowHelpForEntireApp();
                }
                Value = "";
                break;

            case "-i":
                // Help/information about the current control.
                if (ShowInfoAboutControl != null)
                {
                    ShowInfoAboutControl();
                }
                Value = "";
                break;

            case "-r":
                // Reload the current control with the default value.
                Value = DefaultValue ?? "";
                break;

            default:
                return false;
        }
        return true;
    }

    /// <summary>
    /// Show the wait screen.
    /// </summary>
    /// <returns>true if the wait screen is configured and displayed; otherwise, false</returns>
    public bool ShowWaitScreen()
    {
        // Show wait screen.
        if (SessionInfo?.WaitScreenDisplayed == false)
        {
            if (Form != null)
            {
                Form?.ShowWaitScreenForm();
                Form?.SetWaitScreen(Form, Value);
                return true;
            }
        }

        // Reset the properties for wait screen.
        if (SessionInfo?.WaitScreenDisplayed == true && SessionInfo?.WaitScreenSkipped == true)
        {
            Form?.ResetWaitScreen();
            return false;
        }

        return false;
    }
}