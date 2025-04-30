using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Auth;

public class frmLogin : frmTerminalBase
{
    internal class DatabaseInfo
    {
        internal string? Name { get; set; }
        internal string? Description { get; set; }
        internal string? ConnectionString { get; set; }
    }

    private TextControl? lblHeader;
    private TextControl? lblOperationName;
    private TextControl? lblDatabase;
    private ComboEditControl? cmbDatabase;
    private TextControl? lblUsername;
    private TextEditControl? txtUsername;
    private TextControl? lblPassword;
    private TextEditControl? txtPassword;

    private Dictionary<int, DatabaseInfo> _databaseInfoDictionary;

    public frmLogin() : base()
    {
        _databaseInfoDictionary = new Dictionary<int, DatabaseInfo>();
        _databaseInfoDictionary.Add(0, new DatabaseInfo { Name = "IN MEMORY DB" });
        _databaseInfoDictionary.Add(1, new DatabaseInfo { Name = "POSTGRESQL" });
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

        cmbDatabase = new ComboEditControl();
        cmbDatabase.Name = nameof(cmbDatabase);
        cmbDatabase.Top = 4;
        cmbDatabase.Left = 0;
        cmbDatabase.EntireLine = true;
        cmbDatabase.Hint = "SELECT DATABASE";
        cmbDatabase.NextNavigateForm = this;
        cmbDatabase.NextNavigateControl = txtUsername;
        cmbDatabase.PreviousNavigateForm = ParentForm;
        cmbDatabase.ShowOnlyFormInput = true;
        cmbDatabase.MaxDisplayedOptions = 12;
        cmbDatabase.ComboOptions = GetDatabaseComboOptions();
        Controls.Add(cmbDatabase);

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

        // Navigation settings.
        cmbDatabase.NextNavigateForm = this;
        cmbDatabase.NextNavigateControl = txtUsername;
        cmbDatabase.PreviousNavigateForm = ParentForm;
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
                    FocusedEditControl = cmbDatabase;
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
                    ShowMainMenu();
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

    /// <summary>
    /// Get database options available for selection.
    /// </summary>
    /// <returns></returns>
    private Dictionary<int, string> GetDatabaseComboOptions()
    {
        var result = new Dictionary<int, string>();
        foreach (var infoKvp in _databaseInfoDictionary)
        {
            if (!string.IsNullOrEmpty(infoKvp.Value.Name))
            {
                result.Add(infoKvp.Key, infoKvp.Value.Name);
            }
        }
        return result;
    }
}