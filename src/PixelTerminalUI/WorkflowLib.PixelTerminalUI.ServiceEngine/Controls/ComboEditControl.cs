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
    /// The maximum number of options displayed on the selection form.
    /// </summary>
    public int MaxDisplayedOptions { get; set; }

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
        if (SessionInfo?.CurrentForm == Form && Form?.FocusedEditControl == this)
        {
            if (_comboEditForm == null)
            {
                CreateComboEditForm();
            }
            if (ShowOnlyFormInput)
            {
                Form?.ShowForm(_comboEditForm);
            }
        }
    }

    /// <summary>
    /// Validation performed during user input processing.
    /// </summary>
    /// <returns>true if the validation was performed correctly; otherwise false</returns>
    private bool OnComboEnterValidation()
    {
        try
        {
            if (ComboOptions == null || !ComboOptions.Any())
            {
                throw new Exception("No combo options were configured for the control.");
            }

            switch (Value)
            {
                case "":
                case "-n":
                    if (_comboEditForm == null)
                    {
                        CreateComboEditForm();
                    }
                    Form?.ShowForm(_comboEditForm);
                    Value = "";
                    break;

                case "-b":
                    OnGoBackSelected(this);
                    return false;

                default:
                    OnOptionSelected(this);
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

    /// <summary>
    /// Create combo edit form.
    /// </summary>
    private void CreateComboEditForm()
    {
        _comboEditForm = new ComboEditForm
        {
            Header = string.IsNullOrEmpty(Header) ? Hint : Header,
            ComboOptions = ComboOptions,
            MaxDisplayedOptions = MaxDisplayedOptions,
            OptionSelected = OnOptionSelected,
            GoBackSelected = OnGoBackSelected
        };
    }

    /// <summary>
    /// Processing user input.
    /// </summary>
    /// <param name="textEditControl">A control that contains user input</param>
    private void OnOptionSelected(TextEditControl textEditControl)
    {
        if (!int.TryParse(textEditControl.Value, out int selectedIndex) || !ComboOptions.ContainsKey(selectedIndex))
        {
            throw new Exception("Incorrect index: " + textEditControl.Value);
        }

        // Display user input on the control.
        textEditControl.Value = $"{selectedIndex} - {ComboOptions[selectedIndex]}";
        Value = textEditControl.Value;
        
        // Go to the next control.
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
    private void OnGoBackSelected(TextEditControl textEditControl)
    {
        if (PreviousNavigateForm != null)
        {
            SessionInfo.CurrentForm = PreviousNavigateForm;
            if (PreviousNavigateControl != null)
            {
                PreviousNavigateForm.FocusedEditControl = PreviousNavigateControl;
            }
        }
        textEditControl.Value = "";
        Value = "";
    }
}
