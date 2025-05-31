using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;
using WorkflowLib.PixelTerminalUI.Dal.Auth;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Auth;

public class frmLogin : frmTerminalBase
{
    private TextControl? lblHeader;
    private TextControl? lblOperationName;
    private TextControl? lblDatabase;
    private ComboEditControl? cmbDatabase;
    private TextControl? lblUsername;
    private TextEditControl? txtUsername;
    private TextControl? lblPassword;
    private PasswordEditControl? txtPassword;

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

        txtPassword = new PasswordEditControl();
        txtPassword.Name = nameof(txtPassword);
        txtPassword.Top = 10;
        txtPassword.Left = 0;
        txtPassword.EntireLine = true;
        txtPassword.Hint = "ENTER PASSWORD";
        txtPassword.PreviousNavigateForm = this;
        txtPassword.PreviousNavigateControl = txtUsername;
        txtPassword.ValidationFailedMessage = "Incorrect username or password";
        txtPassword.UsernameEditControl = txtUsername;
        txtPassword.ShowMainMenuOnSuccess = true;
        txtPassword.ValidatePassword = OnValidatePassword;
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

    /// <summary>
    /// Validate username and password.
    /// </summary>
    /// <param name="username">Entered username</param>
    /// <param name="password">Entered password</param>
    /// <returns>true if username and password are validated; otherwise, false</returns>
    private bool OnValidatePassword(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new Exception("Username and password should be specified");
        }

        // Get database info.
        int? selectedIndex = cmbDatabase?.SelectedIndexes?.FirstOrDefault()
            ?? throw new Exception("Could not validate username and password: selected database index is not specified");
        List<DatabaseInfo>? databaseInfoList = SessionInfo?.AppSettings?.DatabaseInfoList
            ?? throw new Exception("Database info is not initialized");
        DatabaseInfo? databaseInfo = databaseInfoList.FirstOrDefault(x => x.Index == selectedIndex)
            ?? throw new Exception("Database info is not found");

        if (databaseInfo.NeedConnection != false)
        {
            // Check credentials.
            string connectionString = databaseInfo?.ConnectionString
                ?? throw new Exception($"Connection string is not specified for the selected database: '{databaseInfo?.Index} - {databaseInfo?.Name}'");
            var userAccount = AuthDao.GetUserAccount(connectionString, username, password);
            if (userAccount == null)
            {
                return false;
            }

            // Save validated info.
            SessionInfo.UserAccount = userAccount;
            SessionInfo.DatabaseInfo = databaseInfo;
        }

        return true;
    }

    /// <summary>
    /// Get database options available for selection.
    /// </summary>
    /// <returns></returns>
    private Dictionary<int, string> GetDatabaseComboOptions()
    {
        List<DatabaseInfo>? databaseInfoList = SessionInfo?.AppSettings?.DatabaseInfoList
            ?? throw new Exception("Database info is not initialized");

        var result = new Dictionary<int, string>();
        foreach (var databaseInfo in databaseInfoList)
        {
            if (!string.IsNullOrEmpty(databaseInfo.Name))
            {
                result.Add(databaseInfo.Index, databaseInfo.Name);
            }
        }
        return result;
    }
}