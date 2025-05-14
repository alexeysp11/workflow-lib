using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

/// <summary>
/// Form for displaying a long message.
/// </summary>
public class ScrollMessageForm : SimpleMessageForm
{
    /// <summary>
    /// The maximum number of lines displayed on the form.
    /// </summary>
    public int MaxDisplayedLines { get; set; }

    /// <summary>
    /// Index of the current page of the message.
    /// </summary>
    private int _currentPageIndex;

    /// <summary>
    /// Maximum index of the current page of the message.
    /// </summary>
    private int _maxPageIndex;

    /// <summary>
    /// Minimum index of the current page of the message.
    /// </summary>
    private int _minPageIndex;

    /// <summary>
    /// Collection of lines that need to be displayed.
    /// </summary>
    private List<string> _displayedMessageLines;

    private TextControl? lblNavigation;

    public ScrollMessageForm() : base()
    {
        Name = nameof(ScrollMessageForm);

        _displayedMessageLines = new List<string>();
        _minPageIndex = 1;
        _currentPageIndex = _minPageIndex;
    }

    protected override void InitializeComponent()
    {
        Refresh();
    }

    protected override bool txtConfirmation_EnterValidation()
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
                Refresh();
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
                Refresh();
                break;

            case "-x":
                txtConfirmation.Value = "";
                SessionInfo.CurrentForm = ParentForm;
                return true;
        }
        txtConfirmation.Value = "";
        return false;
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
        Controls.Add(lblNavigation);
        top += 1;

        // Display the message.
        if (string.IsNullOrEmpty(Message))
        {
            throw new Exception($"Failed to show form '{Name}': parameter {nameof(Message)} should be assigned");
        }
        if (!_displayedMessageLines.Any())
        {
            GetLinesFromMessage(Message, ref _displayedMessageLines);
        }
        _maxPageIndex = (_displayedMessageLines.Count / MaxDisplayedLines) + (_displayedMessageLines.Count % MaxDisplayedLines == 0 ? 0 : 1);
        int skipQty = (_currentPageIndex - 1) * MaxDisplayedLines;
        List<string> lines = _displayedMessageLines.Skip(skipQty).Take(MaxDisplayedLines).ToList();
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
        txtConfirmation.Hint = "PRESS ENTER TO CONTINUE";
        txtConfirmation.EnterValidation = txtConfirmation_EnterValidation;
        Controls.Add(txtConfirmation);

        // Info about navigation.
        lblNavigation.Value = $"{_currentPageIndex} of {_maxPageIndex}";
    }
}
