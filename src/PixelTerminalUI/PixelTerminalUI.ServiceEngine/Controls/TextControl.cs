using PixelTerminalUI.ServiceEngine.Forms;
using PixelTerminalUI.ServiceEngine.Models;

namespace PixelTerminalUI.ServiceEngine.Controls;

public class TextControl
{
    public string Name { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool EntireLine { get; set; }
    public string Value { get; set; }
    public bool Visible { get; set; }
    public bool Inverted { get; set; }
    public bool Editable { get; set; }

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public Func<bool>? ShowValidation { get; set; }

    public BaseForm? Form { get; set; }
    
    public SessionInfo? SessionInfo => Form?.SessionInfo;

    public TextControl? PreviousControl { get; set; }
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

    public virtual void Show()
    {
        if (!OnShowValidation())
        {
            return;
        }

        AddControlToForm();
    }

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