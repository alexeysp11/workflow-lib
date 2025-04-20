using WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Info
{
    public class frmHelpForEntireApp : frmTerminalBase
    {
        public string? Header { get; set; }

        private TextControl? lblHeader;
        private TextEditControl? txtConfirmation;

        public frmHelpForEntireApp()
        {
            Name = nameof(frmHelpForEntireApp);
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

        private bool txtConfirmation_EnterValidation()
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
    }
}
