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
    /// Navigate next.
    /// </summary>
    /// <remarks>This delegate is available only if <see cref="MultiSelectEnabled"/> is set</remarks>
    public Action GoNextSelected { get; set; }

    /// <summary>
    /// Navigate back.
    /// </summary>
    public Action<TextEditControl> GoBackSelected { get; set; }

    /// <summary>
    /// Index of the current page of elements.
    /// </summary>
    private int _currentPageIndex;

    /// <summary>
    /// Maximum index of the current page of elements.
    /// </summary>
    private int _maxPageIndex;

    /// <summary>
    /// Minimum index of the current page of elements.
    /// </summary>
    private int _minPageIndex;

    private TextControl? lblNavigation;

    public ComboEditForm() : base()
    {
        Name = nameof(ComboEditForm);

        _minPageIndex = 1;
        _currentPageIndex = _minPageIndex;
    }

    protected override void InitializeComponent()
    {
        PrintComboOptions();
    }

    protected override bool txtConfirmation_EnterValidation()
    {
        try
        {
            switch (txtConfirmation.Value)
            {
                case "":
                case "-n":
                    // Scroll forward through the selection options.
                    if (_maxPageIndex == _minPageIndex)
                    {
                        break;
                    }
                    if (_currentPageIndex >= _maxPageIndex)
                    {
                        _currentPageIndex = _minPageIndex;
                    }
                    else
                    {
                        _currentPageIndex += 1;
                    }
                    PrintComboOptions();
                    break;

                case "-b":
                    // Scroll back through the selection options.
                    if (_maxPageIndex == _minPageIndex)
                    {
                        break;
                    }
                    if (_currentPageIndex <= _minPageIndex)
                    {
                        _currentPageIndex = _minPageIndex;
                    }
                    else
                    {
                        _currentPageIndex -= 1;
                    }
                    PrintComboOptions();
                    break;

                case "-s":
                    // Save selected options and go next.
                    if (MultiSelectEnabled)
                    {
                        if (GoNextSelected != null)
                        {
                            GoNextSelected();
                        }
                    }
                    else
                    {
                        throw new Exception("You can save selected options only if MultiSelectEnabled is set for the control");
                    }
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
                    return true;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            return false;
        }
        finally
        {
            txtConfirmation.Value = "";
        }
        return false;
    }

    /// <summary>
    /// Print combo options as a message and refresh the form.
    /// </summary>
    /// <remarks>The maximum number of options displayed on the selection form is set by <see cref="MaxDisplayedOptions"/></remarks>
    private void PrintComboOptions()
    {
        // Validations.
        if (ComboOptions == null || !ComboOptions.Any())
        {
            throw new Exception("Combo options could not be null or empty");
        }
        if (_currentPageIndex <= 0)
        {
            throw new Exception("Current page index should be greater than zero");
        }

        // Calculations.
        _maxPageIndex = (ComboOptions.Count / MaxDisplayedOptions) + (ComboOptions.Count % MaxDisplayedOptions == 0 ? 0 : 1);
        int skipQty = (_currentPageIndex - 1) * MaxDisplayedOptions;

        // Set new value of the displayed message.
        var sb = new StringBuilder();
        var displayedComboOptions = ComboOptions.Skip(skipQty).Take(MaxDisplayedOptions).ToList();
        foreach (var item in displayedComboOptions)
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

        // Display navigation label.
        lblNavigation = new TextControl();
        lblNavigation.Name = nameof(lblNavigation);
        lblNavigation.Top = top;
        lblNavigation.Left = 0;
        lblNavigation.EntireLine = true;
        lblNavigation.HorizontalAlignment = HorizontalAlignment.Right;
        lblNavigation.Value = $"{_currentPageIndex} of {_maxPageIndex}";
        Controls.Add(lblNavigation);
        top += 1;

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
