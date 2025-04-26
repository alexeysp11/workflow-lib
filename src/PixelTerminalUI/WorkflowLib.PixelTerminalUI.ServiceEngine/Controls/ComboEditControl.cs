using System.Text;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

/// <summary>
/// Field for selecting from a list.
/// </summary>
public class ComboEditControl : TextEditControl
{
    /// <summary>
    /// The displayed title on the selection form.
    /// </summary>
    public string? Header { get; set; }

    /// <summary>
    /// Determines whether to open a separate form for selection.
    /// </summary>
    public bool ShowOnlyFormInput { get; set; }

    /// <summary>
    /// Show additional information about options to select.
    /// </summary>
    public bool ShowItemsAdditionalInfo { get; set; }

    /// <summary>
    /// Determines whether two or more items can be selected from the provided list.
    /// </summary>
    public bool MultiSelectEnabled { get; set; }

    /// <summary>
    /// Possible options that the user can choose from.
    /// </summary>
    public Dictionary<int, string>? ComboOptions { get; set; }

    /// <summary>
    /// A collection of indexes that have been selected by the user.
    /// </summary>
    public List<int>? SelectedIndexes { get; set; }

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
    public BaseForm? NextNavigateForm {  get; set; }

    /// <summary>
    /// The previous form which will be displayed after successful validation of this control.
    /// </summary>
    public BaseForm? PreviousNavigateForm {  get; set; }

    /// <summary>
    /// A form displayed to select a possible option.
    /// </summary>
    private ComboEditForm? _comboEditForm;

    public ComboEditControl() : base()
    {
        ShowOnlyFormInput = false;
        ShowItemsAdditionalInfo = false;
        MultiSelectEnabled = false;
        EnterValidation = OnComboEnterValidation;
    }

    /// <summary>
    /// Show current control.
    /// </summary>
    public override void Show()
    {
        base.Show();
        if (SessionInfo.CurrentForm == Form && _comboEditForm == null)
        {
            _comboEditForm = new ComboEditForm
            {
                Header = string.IsNullOrEmpty(Header) ? Hint : Header
            };
        }
        if (ShowOnlyFormInput)
        {
            Form?.ShowInformation("SELECT DATABASE");
            //Form?.ShowForm(_comboEditForm);
        }
    }

    private bool OnComboEnterValidation()
    {
        try
        {
            switch (Value)
            {
                case "":
                case "-n":
                    var sb = new StringBuilder();
                    foreach (var item in ComboOptions)
                    {
                        sb.AppendLine($"{item.Key}. {item.Value}");
                    }
                    Form?.ShowInformation(sb.ToString());
                    Value = "";
                    break;

                case "-b":
                    if (PreviousNavigateForm != null)
                    {
                        SessionInfo.CurrentForm = PreviousNavigateForm;
                        if (PreviousNavigateControl != null)
                        {
                            PreviousNavigateForm.FocusedEditControl = PreviousNavigateControl;
                        }
                    }
                    Value = "";
                    return false;

                default:
                    if (!int.TryParse(Value, out int selectedIndex) || !ComboOptions.ContainsKey(selectedIndex))
                    {
                        throw new Exception("Incorrect index: " + Value);
                    }
                    Value = $"{selectedIndex} - {ComboOptions[selectedIndex]}";
                    if (NextNavigateForm != null)
                    {
                        SessionInfo.CurrentForm = NextNavigateForm;
                        if (NextNavigateControl != null)
                        {
                            NextNavigateForm.FocusedEditControl = NextNavigateControl;
                        }
                    }
                    return true;
            }
        }
        catch (Exception ex)
        {
            Value = "";
            Form?.ShowError(ex.Message);
            Form.FocusedEditControl = this;
            return false;
        }
        return true;
    }
}
