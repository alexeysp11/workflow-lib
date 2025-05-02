using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// Base implementation of the form.
/// </summary>
public abstract class BaseForm
{
    /// <summary>
    /// Name of the form.
    /// </summary>
    public string Name { get; set; }

    public string MenuCode { get; set; }

    /// <summary>
    /// Height of the form.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Width of the form.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Information required to process the user session.
    /// </summary>
    public SessionInfo? SessionInfo { get; set; }

    /// <summary>
    /// The parent form from which this form was created.
    /// </summary>
    public BaseForm? ParentForm { get; set; }

    /// <summary>
    /// Collection of controls on the current form.
    /// </summary>
    public List<TextControl> Controls { get; set; }

    /// <summary>
    /// The control of type <see cref="TextEditControl"/> that currently has input focus.
    /// </summary>
    public TextEditControl? FocusedEditControl { get; set; }

    /// <summary>
    /// Validation of form controls and properties performed before the form is displayed.
    /// </summary>
    public Func<bool>? ShowValidation { get; set; }

    /// <summary>
    /// Validation of the form that is performed before exiting the form.
    /// </summary>
    public Func<bool>? FormValidation { get; set; }

    /// <summary>
    /// Go to the main menu.
    /// </summary>
    public Action? ShowMainMenu { get; set; }

    /// <summary>
    /// Show settings page.
    /// </summary>
    public Action? ShowSettings { get; set; }

    /// <summary>
    /// Show help/information page (for the entire app).
    /// </summary>
    public Action? ShowHelpForEntireApp { get; set; }

    /// <summary>
    /// Parameters and variables stored on the form at runtime.
    /// </summary>
    public FormParameters? FormParameters { get; set; }

    public BaseForm()
    {
        Name = "";
        MenuCode = "";
        Height = 0;
        Width = 0;
        Controls = new List<TextControl>();
    }

    /// <summary>
    /// Initialize this form.
    /// </summary>
    public virtual void Init()
    {
        Height = SessionInfo?.FormHeight ?? 0;
        Width = SessionInfo?.FormWidth ?? 0;

        SessionInfo?.AssignEmptyDisplayedInfo();

        InitializeComponent();
    }

    /// <summary>
    /// Display the form on the user's screen.
    /// </summary>
    public virtual void Show()
    {
        try
        {
            if (!OnShowValidation())
            {
                return;
            }

            SessionInfo.CurrentForm = this;

            SessionInfo.AssignEmptyDisplayedInfo();

            List<TextControl> sortedControls = Controls
                .OrderBy(x => x.Top)
                .ThenBy(x => x.Left)
                .ToList();
            List<TextEditControl> sortedEditControls = sortedControls
                .Where(x => x is TextEditControl && x.Editable)
                .Cast<TextEditControl>()
                .ToList();

            ConfigureControls(sortedControls);
            ConfigureEditControls(sortedEditControls);

            ShowTextControls();

            if (FocusedEditControl == null)
            {
                FocusedEditControl = sortedControls
                    .Where(x => x is TextEditControl && x.Editable)
                    .Cast<TextEditControl>()
                    .FirstOrDefault();
            }

            TextEditControl? currentEditControl = null;
            while (true)
            {
                if (currentEditControl == FocusedEditControl)
                {
                    break;
                }
                currentEditControl = FocusedEditControl;
                if (currentEditControl != null)
                {
                    ShowTextEditControl(FocusedEditControl);
                }
                else
                {
                    if (FormValidation != null)
                    {
                        if (FormValidation())
                        {
                            SessionInfo.CurrentForm = ParentForm;
                            return;
                        }
                    }
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Validation of form controls and properties performed before the form is displayed.
    /// </summary>
    /// <returns>true if the validation was performed correctly; otherwise, false</returns>
    /// <exception cref="Exception">Occurs when a control or form property was initialized incorrectly</exception>
    public virtual bool OnShowValidation()
    {
        if (ShowValidation != null)
        {
            return ShowValidation();
        }
        
        if (string.IsNullOrEmpty(Name))
        {
            throw new Exception($"Failed to show form: parameter {nameof(Name)} should be assigned");
        }
        if (SessionInfo == null)
        {
            throw new Exception($"Failed to show form '{Name}': parameter '{nameof(SessionInfo)}' should be assigned");
        }
        if (Controls == null || !Controls.Any())
        {
            throw new Exception($"Failed to show form '{Name}': parameter {nameof(Controls)} should be assigned and contain elements");
        }
        if (Height <= 0)
        {
            throw new Exception($"Failed to show form '{Name}': parameter {nameof(Height)} should be greater than zero");
        }
        if (Width <= 0)
        {
            throw new Exception($"Failed to show form '{Name}': parameter {nameof(Width)} should be greater than zero");
        }
        return true;
    }

    public void FillFormAttributes(string menuCode)
    {
        MenuCode = menuCode;
    }

    /// <summary>
    /// Initialize the components on the form.
    /// </summary>
    protected abstract void InitializeComponent();

    /// <summary>
    /// Show a form to display information messages.
    /// </summary>
    /// <param name="message">Message to display</param>
    public void ShowInformation(string message)
    {
        ShowMessageForm("INFORMATION", message);
    }

    /// <summary>
    /// Show a form to display errors.
    /// </summary>
    /// <param name="message">Message to display</param>
    public void ShowError(string message)
    {
        ShowMessageForm("ERROR", message);
    }

    /// <summary>
    /// Show a form to display warnings.
    /// </summary>
    /// <param name="message">Message to display</param>
    public void ShowWarning(string message)
    {
        ShowMessageForm("WARNING", message);
    }

    /// <summary>
    /// Show <see cref="SimpleMessageForm"/> to display messages.
    /// </summary>
    /// <param name="header">Header of the form</param>
    /// <param name="message">Message to display</param>
    public void ShowMessageForm(string header, string message)
    {
        try
        {
            var frmDisplayMessage = new SimpleMessageForm();
            frmDisplayMessage.Header = header;
            frmDisplayMessage.Message = message;
            frmDisplayMessage.SessionInfo = SessionInfo;
            frmDisplayMessage.ParentForm = this;
            frmDisplayMessage.Init();
            frmDisplayMessage.Show();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Show <see cref="ScrollMessageForm"/> to display long messages.
    /// </summary>
    /// <param name="header">Header of the form</param>
    /// <param name="message">Message to display</param>
    /// <param name="maxDisplayedLines">Maximum number of message lines to display on screen</param>
    public void ShowScrollMessageForm(string header, string message, int maxDisplayedLines = 12)
    {
        try
        {
            var frmDisplayMessage = new ScrollMessageForm();
            frmDisplayMessage.Header = header;
            frmDisplayMessage.Message = message;
            frmDisplayMessage.SessionInfo = SessionInfo;
            frmDisplayMessage.ParentForm = this;
            frmDisplayMessage.MaxDisplayedLines = maxDisplayedLines;
            frmDisplayMessage.Init();
            frmDisplayMessage.Show();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Display the page before exiting the application.
    /// </summary>
    public void ShowExitAppForm()
    {
        try
        {
            var frmDisplayMessage = new ExitAppForm();
            frmDisplayMessage.Header = "EXIT APPLICATION";
            frmDisplayMessage.Message = "Are you sure to exit the application?";
            frmDisplayMessage.SessionInfo = SessionInfo;
            frmDisplayMessage.ParentForm = this;
            frmDisplayMessage.Init();
            frmDisplayMessage.Show();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private void ConfigureControls(List<TextControl> sortedControls)
    {
        if (sortedControls == null)
            throw new Exception("Sorted list of controls was not assigned");
        
        TextControl? previousControl = null;
        foreach (TextControl control in sortedControls)
        {
            if (previousControl != null)
            {
                previousControl.NextControl = control;
            }
            control.PreviousControl = previousControl;
            control.Form = this;
            previousControl = control;
        }
        previousControl = null;
    }

    private void ConfigureEditControls(List<TextEditControl> sortedControls)
    {
        if (sortedControls == null)
            throw new Exception("Sorted list of controls was not assigned");
        
        TextEditControl? previousControl = null;
        foreach (TextEditControl control in sortedControls)
        {
            if (previousControl != null)
            {
                previousControl.NextEditControl = control;
            }
            control.PreviousEditControl = previousControl;
            control.Form = this;
            previousControl = control;
        }
        previousControl = null;
    }

    private void ShowTextControls()
    {
        List<TextControl> textControls = Controls
            .Where(x => !x.Editable)
            .ToList();
        
        foreach (TextControl control in textControls)
        {
            control.Show();
        }
    }

    private void ShowTextEditControl(TextEditControl control)
    {
        if (control == null)
        {
            throw new Exception("Control is not found");
        }

        control.GetUserInput();
        control = FocusedEditControl;
        if (SessionInfo?.CurrentForm == this && control != null)
        {
            control.Show();
        }
        else
        {
            SessionInfo?.CurrentForm?.Show();
        }
    }

    protected void GetLinesFromMessage(string message, ref List<string> result)
    {
        var lines = message.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
        foreach (var line in lines)
        {
            if (line.Length <= Width)
            {
                result.Add(line);
            }
            else
            {
                string restLine = line;
                while (true)
                {
                    if (string.IsNullOrEmpty(restLine))
                    {
                        break;
                    }
                    int lineLength = 0;
                    var words = restLine.Split(' ').ToList();
                    foreach (string word in words)
                    {
                        if (lineLength + word.Length + 1 <= Width)
                        {
                            lineLength += word.Length + 1;
                            continue;
                        }
                        if (lineLength == 0)
                        {
                            lineLength = Width;
                        }
                        break;
                    }
                    int endIndex = lineLength > restLine.Length ? restLine.Length : lineLength;
                    result.Add(restLine.Substring(0, endIndex));
                    restLine = restLine.Substring(endIndex);
                }
            }
        }
    }

    /// <summary>
    /// Configures and displays the form..
    /// </summary>
    /// <param name="form">An instance of the created form that needs to be displayed</param>
    public void ShowForm(BaseForm form)
    {
        try
        {
            SessionInfo.CurrentForm = form;
            form.FormParameters = FormParameters ?? new FormParameters();
            form.SessionInfo = SessionInfo;
            form.ParentForm = this;
            form.Init();
            form.Show();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }
}