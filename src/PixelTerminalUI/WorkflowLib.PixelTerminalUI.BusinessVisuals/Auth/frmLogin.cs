using WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Auth;

public class frmLogin : BaseForm
{
    private TextControl? lblHeader;
    private TextControl? lblOperationName;
    private TextControl? lblDatabase;
    private TextEditControl? txtDatabase;
    private TextControl? lblUsername;
    private TextEditControl? txtUsername;
    private TextControl? lblPassword;
    private TextEditControl? txtPassword;

    public frmLogin() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmLogin);

        lblHeader = new TextControl();
        lblHeader.Name = nameof(lblHeader);
        lblHeader.Top = 0;
        lblHeader.Left = 0;
        lblHeader.EntireLine = true;
        lblHeader.HorizontalAlignment = HorizontalAlignment.Center;
        lblHeader.Value = "PIXEL TERMINAL UI";
        lblHeader.Inverted = true;
        Controls.Add(lblHeader);

        lblOperationName = new TextControl();
        lblOperationName.Name = nameof(lblOperationName);
        lblOperationName.Top = 1;
        lblOperationName.Left = 0;
        lblOperationName.EntireLine = true;
        lblOperationName.Value = "LOGIN";
        Controls.Add(lblOperationName);

        lblDatabase = new TextControl();
        lblDatabase.Name = nameof(lblDatabase);
        lblDatabase.Top = 3;
        lblDatabase.Left = 0;
        lblDatabase.EntireLine = true;
        lblDatabase.Value = "DATABASE:";
        Controls.Add(lblDatabase);

        txtDatabase = new TextEditControl();
        txtDatabase.Name = nameof(txtDatabase);
        txtDatabase.Top = 4;
        txtDatabase.Left = 0;
        txtDatabase.EntireLine = true;
        txtDatabase.Hint = "SELECT DATABASE";
        txtDatabase.EnterValidation = txtDatabase_EnterValidation;
        Controls.Add(txtDatabase);

        lblUsername = new TextControl();
        lblUsername.Name = nameof(lblUsername);
        lblUsername.Top = 6;
        lblUsername.Left = 0;
        lblUsername.EntireLine = true;
        lblUsername.Value = "USERNAME:";
        Controls.Add(lblUsername);

        txtUsername = new TextEditControl();
        txtUsername.Name = nameof(txtUsername);
        txtUsername.Top = 7;
        txtUsername.Left = 0;
        txtUsername.EntireLine = true;
        txtUsername.Hint = "ENTER USERNAME";
        txtUsername.EnterValidation = txtUsername_EnterValidation;
        Controls.Add(txtUsername);

        lblPassword = new TextControl();
        lblPassword.Name = nameof(lblPassword);
        lblPassword.Top = 9;
        lblPassword.Left = 0;
        lblPassword.EntireLine = true;
        lblPassword.Value = "PASSWORD:";
        Controls.Add(lblPassword);

        txtPassword = new TextEditControl();
        txtPassword.Name = nameof(txtPassword);
        txtPassword.Top = 10;
        txtPassword.Left = 0;
        txtPassword.EntireLine = true;
        txtPassword.Hint = "ENTER PASSWORD";
        txtPassword.EnterValidation = txtPassword_EnterValidation;
        Controls.Add(txtPassword);
    }

    private bool txtDatabase_EnterValidation()
    {
        try
        {
            switch (txtDatabase.Value)
            {
                case "":
                case "-n":
                    ShowInformation("0. IN MEMORY DB\n1. POSTGRESQL");
                    txtDatabase.Value = "";
                    break;

                case "-b":
                    SessionInfo.CurrentForm = ParentForm;
                    txtDatabase.Value = "";
                    return false;

                case "0":
                case "1":
                    FocusedEditControl = txtUsername;
                    return true;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            FocusedEditControl = txtDatabase;
            return false;
        }
        return true;
    }

    private bool txtUsername_EnterValidation()
    {
        try
        {
            switch (txtUsername.Value)
            {
                case "":
                case "-n":
                    FocusedEditControl = txtUsername;
                    txtUsername.Value = "";
                    return false;

                case "-b":
                    FocusedEditControl = txtDatabase;
                    txtUsername.Value = "";
                    return false;

                default:
                    FocusedEditControl = txtPassword;
                    return true;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            FocusedEditControl = txtUsername;
            return false;
        }
        return true;
    }

    private bool txtPassword_EnterValidation()
    {
        try
        {
            switch (txtPassword.Value)
            {
                case "":
                case "-n":
                    FocusedEditControl = txtPassword;
                    txtPassword.Value = "";
                    return false;

                case "-b":
                    FocusedEditControl = txtUsername;
                    txtPassword.Value = "";
                    return false;

                default:
                    ShowForm(new frmMenu());
                    return true;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            FocusedEditControl = txtPassword;
            return false;
        }
        return true;
    }
}