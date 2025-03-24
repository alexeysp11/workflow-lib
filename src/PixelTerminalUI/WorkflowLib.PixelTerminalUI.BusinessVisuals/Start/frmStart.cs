using WorkflowLib.PixelTerminalUI.BusinessVisuals.Auth;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Start;

public class frmStart : BaseForm
{
    private TextControl? lblWelcome;
    private TextControl? lblAppName;

    private TextEditControl? txtUserInput;

    public frmStart() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmStart);
        
        lblWelcome = new TextControl();
        lblWelcome.Name = nameof(lblWelcome);
        lblWelcome.Top = 4;
        lblWelcome.Left = 0;
        lblWelcome.EntireLine = true;
        lblWelcome.HorizontalAlignment = HorizontalAlignment.Center;
        lblWelcome.Value = "WELCOME TO";
        Controls.Add(lblWelcome);

        lblAppName = new TextControl();
        lblAppName.Name = nameof(lblAppName);
        lblAppName.Top = 5;
        lblAppName.Left = 0;
        lblAppName.EntireLine = true;
        lblAppName.HorizontalAlignment = HorizontalAlignment.Center;
        lblAppName.Value = "PIXEL TERMINAL UI";
        Controls.Add(lblAppName);

        txtUserInput = new TextEditControl();
        txtUserInput.Name = nameof(txtUserInput);
        txtUserInput.Top = 14;
        txtUserInput.Left = 0;
        txtUserInput.EntireLine = true;
        txtUserInput.Hint = "PRESS ENTER TO CONTINUE";
        txtUserInput.EnterValidation = txtUserInput_EnterValidation;
        Controls.Add(txtUserInput);
    }

    private bool txtUserInput_EnterValidation()
    {
        try
        {
            switch (txtUserInput.Value)
            {
                case "":
                case "-n":
                    ShowForm(new frmLogin());
                    break;

                case "-q":
                case "-b":
                    ShowInformation("Are you sure to exit the application?");
                    break;
            }
        }
        finally
        {
            txtUserInput.Value = "";
        }
        return true;
    }
}