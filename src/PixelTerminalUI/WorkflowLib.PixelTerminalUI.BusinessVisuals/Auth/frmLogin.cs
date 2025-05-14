using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Auth;

public class frmLogin : frmTerminalBase
{
    /// <summary>
    /// Information about databases.
    /// </summary>
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
    private PasswordEditControl? txtPassword;

    private Dictionary<int, DatabaseInfo> _databaseInfoDictionary;

    public frmLogin() : base()
    {
        _databaseInfoDictionary = new Dictionary<int, DatabaseInfo>();
        _databaseInfoDictionary.Add(0, new DatabaseInfo { Name = "IN MEMORY DB" });
        _databaseInfoDictionary.Add(1, new DatabaseInfo { Name = "PG-01" });
        _databaseInfoDictionary.Add(2, new DatabaseInfo { Name = "PG-02" });
        _databaseInfoDictionary.Add(3, new DatabaseInfo { Name = "PG-03" });
        _databaseInfoDictionary.Add(4, new DatabaseInfo { Name = "SQLITE-01" });
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