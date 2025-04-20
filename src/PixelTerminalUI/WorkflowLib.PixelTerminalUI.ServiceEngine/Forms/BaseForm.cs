using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

public abstract class BaseForm
{
    public string Name { get; set; }
    public string MenuCode { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public SessionInfo? SessionInfo { get; set; }

    public BaseForm? ParentForm { get; set; }

    public List<TextControl> Controls { get; set; }
    public TextEditControl FocusedEditControl { get; set; }

    public Func<bool>? ShowValidation { get; set; }
    public Func<bool>? FormValidation { get; set; }

    public Action? ShowMainMenu { get; set; }
    public Action? ShowSettings { get; set; }

    public BaseForm()
    {
        Name = "";
        MenuCode = "";
        Height = 0;
        Width = 0;
        Controls = new List<TextControl>();
    }

    public virtual void Init()
    {
        Height = SessionInfo?.FormHeight ?? 0;
        Width = SessionInfo?.FormWidth ?? 0;

        SessionInfo?.AssignEmptyDisplayedInfo();

        InitializeComponent();
    }

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

            TextEditControl currentEditControl = null;
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

    protected abstract void InitializeComponent();

    public void ShowInformation(string message)
    {
        ShowMessageForm("INFORMATION", message);
    }

    public void ShowError(string message)
    {
        ShowMessageForm("ERROR", message);
    }

    public void ShowWarning(string message)
    {
        ShowMessageForm("WARNING", message);
    }

    public void ShowMessageForm(string header, string message)
    {
        try
        {
            var frmDisplayMessage = new frmDisplayMessage();
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

    public void ShowExitAppForm()
    {
        try
        {
            var frmDisplayMessage = new frmExitApp();
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
        if (SessionInfo.CurrentForm == this && control != null)
        {
            control.Show();
        }
        else
        {
            SessionInfo.CurrentForm.Show();
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

    public void ShowForm(BaseForm form)
    {
        SessionInfo.CurrentForm = form;
        form.SessionInfo = SessionInfo;
        form.ParentForm = this;
        form.Init();
        form.Show();
    }
}