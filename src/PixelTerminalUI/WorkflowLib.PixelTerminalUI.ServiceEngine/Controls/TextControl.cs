using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Forms;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Models;

namespace VelocipedeUtils.PixelTerminalUI.ServiceEngine.Controls;

/// <summary>
/// Text field to display.
/// </summary>
public class TextControl
{
    /// <summary>
    /// Name of the control.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The control position from the left edge of the form.
    /// </summary>
    public int Left { get; set; }

    /// <summary>
    /// The control position from the top edge of the form.
    /// </summary>
    public int Top { get; set; }

    /// <summary>
    /// Width of the control measured in number of characters.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Height of the control.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Determines whether the control takes up the entire line.
    /// </summary>
    public bool EntireLine { get; set; }

    /// <summary>
    /// Displayed value of the control.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Determines whether the control is visible.
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Determines whether the control will be inverted.
    /// For example, if the main background of the form is white and the font color is black,
    /// then the control background will be black and its font color will be white.
    /// </summary>
    public bool Inverted { get; set; }

    /// <summary>
    /// Determines whether the control could be edited.
    /// </summary>
    public bool Editable { get; set; }

    /// <summary>
    /// The horizontal alignment applied to the control (for example, <see cref="HorizontalAlignment.Left"/>,
    /// <see cref="HorizontalAlignment.Center"/>, or <see cref="HorizontalAlignment.Right"/>).
    /// </summary>
    public HorizontalAlignment HorizontalAlignment { get; set; }

    /// <summary>
    /// Delegate for validation performed when the control is shown.
    /// </summary>
    public Func<bool>? ShowValidation { get; set; }

    /// <summary>
    /// The form to which this control belongs.
    /// </summary>
    public BaseForm? Form { get; set; }

    /// <summary>
    /// Information required to process the user session.
    /// </summary>
    public SessionInfo? SessionInfo => Form?.SessionInfo;

    /// <summary>
    /// The next control on the form.
    /// </summary>
    public TextControl? PreviousControl { get; set; }

    /// <summary>
    /// The previous control on the form.
    /// </summary>
    public TextControl? NextControl { get; set; }

    public TextControl()
    {
        Name = "";
        Left = 0;
        Top = 0;
        Width = 0;
        Height = 1;
        EntireLine = false;
        Value = "";
        Visible = true;
        Inverted = false;
        Editable = false;
        HorizontalAlignment = HorizontalAlignment.Left;
    }

    /// <summary>
    /// Show current control.
    /// </summary>
    public virtual void Show()
    {
        if (!OnShowValidation())
        {
            return;
        }

        AddControlToForm();
    }

    /// <summary>
    /// Validation performed during control display.
    /// </summary>
    /// <returns>true if the validation was performed correctly; otherwise, false</returns>
    public virtual bool OnShowValidation()
    {
        if (ShowValidation != null)
        {
            return ShowValidation();
        }

        if (string.IsNullOrEmpty(Name))
        {
            throw new Exception($"Failed to show control: parameter {nameof(Name)} should be assigned");
        }
        if (Form == null)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Form)} should be assigned");
        }
        if (SessionInfo == null)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(SessionInfo)} should be assigned");
        }
        if (Left < 0)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Left)} should not be negative");
        }
        if (Top < 0)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Top)} should not be negative");
        }
        if (Width < 0)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Width)} should not be negative");
        }
        if (Height < 0)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Height)} should not be negative");
        }
        if (Width > Form.Width)
        {
            throw new Exception($"Failed to show control '{Name}': parameter {nameof(Width)} could not be greater than {nameof(Form.Width)}");
        }
        if (!Visible)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Method for adding control to form.
    /// </summary>
    public virtual void AddControlToForm()
    {
        int width = 0;
        int left = Left;
        int top = Top;

        if (EntireLine)
        {
            Width = SessionInfo.FormWidth;
            if (HorizontalAlignment == HorizontalAlignment.Center)
            {
                int start = (Width - Value.Length) / 2;
                if (start < 0)
                {
                    start = 0;
                }
                left = start;
            }
            else if (HorizontalAlignment == HorizontalAlignment.Right)
            {
                int start = Width - Value.Length;
                if (start < 0)
                {
                    start = 0;
                }
                left = start;
            }
        }

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
    }
}