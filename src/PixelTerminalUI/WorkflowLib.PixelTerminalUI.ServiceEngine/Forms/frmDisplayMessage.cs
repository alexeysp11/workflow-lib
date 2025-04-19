using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Forms
{
    public class frmDisplayMessage : BaseForm
    {
        public string? Header { get; set; }
        public string? Message { get; set; }

        protected TextControl? lblHeader;
        protected TextEditControl? txtConfirmation;

        public frmDisplayMessage() : base()
        {
            Name = nameof(frmDisplayMessage);
        }

        protected override void InitializeComponent()
        {
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
            txtConfirmation.Hint = "PRESS ENTER TO CONTINUE";
            txtConfirmation.EnterValidation = txtConfirmation_EnterValidation;
            Controls.Add(txtConfirmation);
        }

        protected virtual bool txtConfirmation_EnterValidation()
        {
            switch (txtConfirmation.Value)
            {
                case "-n":
                case "-b":
                    txtConfirmation.Value = "";
                    SessionInfo.CurrentForm = ParentForm;
                    return true;
            }
            txtConfirmation.Value = "";
            return false;
        }

        private void GetLinesFromMessage(string message, ref List<string> result)
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
    }
}
