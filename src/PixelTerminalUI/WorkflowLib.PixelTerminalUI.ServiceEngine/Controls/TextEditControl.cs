namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

public class TextEditControl : TextControl
{
    public bool Required { get; set; }
    public string EmptyEnterSymbol { get; set; }
    public string? Hint { get; set; }
    public Func<bool>? EnterValidation { get; set; }

    public TextEditControl? NextEditControl { get; set; }
    public TextEditControl? PreviousEditControl { get; set; }

    public TextEditControl() : base()
    {
        Editable = true;
        Required = true;
        EmptyEnterSymbol = ".";
    }

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

    public override bool OnShowValidation()
    {
        if (!base.OnShowValidation())
        {
            return false;
        }
        return Required;
    }

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
        CheckSpecialChars();
        if (EnterValidation != null)
        {
            return EnterValidation();
        }
        return true;
    }

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

    private void CheckSpecialChars()
    {
        switch (Value)
        {
            case "-q":
                // Exit the application.
                Form?.ShowExitAppForm();
                break;
            
            case "-m":
                // Go to the main menu.
                if (Form?.ShowMainMenu != null)
                {
                    Form?.ShowMainMenu();
                }
                break;
            
            case "-c":
                // Settings.
                if (Form?.ShowSettings != null)
                {
                    Form?.ShowSettings();
                }
                break;
        }
    }
}