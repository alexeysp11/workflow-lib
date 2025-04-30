using System.Text;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// The form that opens when <see cref="Controls.ComboEditControl"/> is used.
/// </summary>
public class ComboEditForm : DisplayMessageForm
{
    /// <summary>
    /// Possible options that the user can choose from.
    /// </summary>
    public Dictionary<int, string>? ComboOptions { get; set; }

    /// <summary>
    /// Determines whether two or more items can be selected from the provided list.
    /// </summary>
    public bool MultiSelectEnabled { get; set; }

    /// <summary>
    /// The maximum number of options displayed on the selection form.
    /// </summary>
    public int MaxDisplayedOptions { get; set; }

    /// <summary>
    /// Processing user input.
    /// </summary>
    public Action<TextEditControl> OptionSelected { get; set; }

    /// <summary>
    /// Navigate back.
    /// </summary>
    public Action<TextEditControl> GoBackSelected { get; set; }

    public ComboEditForm() : base()
    {
        Name = nameof(ComboEditForm);
    }

    protected override void InitializeComponent()
    {
        PrintComboOptions();
    }

    protected override bool txtConfirmation_EnterValidation()
    {
        switch (txtConfirmation.Value)
        {
            case "":
            case "-n":
                // Scroll forward through the selection options.
                break;

            case "-b":
                // Scroll back through the selection options.
                break;

            case "-x":
                // Cancel selection and go back to the previous control.
                if (GoBackSelected != null)
                {
                    GoBackSelected(txtConfirmation);
                }
                return true;

            default:
                // Try parse and process user input.
                if (OptionSelected != null)
                {
                    OptionSelected(txtConfirmation);
                }
                break;
        }
        txtConfirmation.Value = "";
        return false;
    }

    /// <summary>
    /// Print combo options as a message and refresh the form.
    /// </summary>
    /// <remarks>The maximum number of options displayed on the selection form is set by <see cref="MaxDisplayedOptions"/></remarks>
    private void PrintComboOptions()
    {
        if (ComboOptions == null || !ComboOptions.Any())
        {
            throw new Exception("Combo options could not be null or empty");
        }

        // Set new value of the displayed message.
        var sb = new StringBuilder();
        foreach (var item in ComboOptions)
        {
            sb.AppendLine($"{item.Key}. {item.Value}");
        }
        Message = sb.ToString();

        // Refresh the form.
        Refresh();
    }

    /// <summary>
    /// Refresh the form.
    /// </summary>
    private void Refresh()
    {
        // Reset the form.
        Controls.Clear();
        FocusedEditControl = null;

        int top = 0;

        // Display the header.
        if (!string.IsNullOrEmpty(Header))
        {
            lblHeader = new TextControl();
            lblHeader.Name = nameof(lblHeader);
            lblHeader.Top = top;
            lblHeader.Left = 0;
            lblHeader.EntireLine = true;
            lblHeader.HorizontalAlignment = HorizontalAlignment.Center;
            lblHeader.Value = Header;
            lblHeader.Inverted = true;
            Controls.Add(lblHeader);
            top += 1;
        }

        // Display the message.
        if (string.IsNullOrEmpty(Message))
        {
            throw new Exception($"Failed to show form '{Name}': parameter {nameof(Message)} should be assigned");
        }
        List<string> lines = new List<string>();
        GetLinesFromMessage(Message, ref lines);
        foreach (var line in lines)
        {
            var lblLine = new TextControl();
            lblLine.Name = "lblLine" + top;
            lblLine.Top = top;
            lblLine.Left = 0;
            lblLine.EntireLine = true;
            lblLine.Value = line;
            Controls.Add(lblLine);
            top += 1;
        }

        // Confirmation control.
        txtConfirmation = new TextEditControl();
        txtConfirmation.Name = nameof(txtConfirmation);
        txtConfirmation.Top = Height - 3;
        txtConfirmation.Left = 0;
        txtConfirmation.EntireLine = false;
        txtConfirmation.Width = 10;
        txtConfirmation.Hint = MultiSelectEnabled ? "SELECT ONE OR MORE OPTIONS" : "SELECT ONLY ONE OPTION";
        txtConfirmation.EnterValidation = txtConfirmation_EnterValidation;
        Controls.Add(txtConfirmation);
    }
}
