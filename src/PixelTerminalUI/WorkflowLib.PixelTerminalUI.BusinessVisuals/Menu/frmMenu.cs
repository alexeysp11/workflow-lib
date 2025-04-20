using WorkflowLib.PixelTerminalUI.BusinessVisuals.Applications;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.ConfigVariables;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.TestForms;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Tasks;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Users;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.BusinessVisuals.Info;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;

public class frmMenu : frmTerminalBase
{
    protected string CurrentMenuPath;

    protected TextControl? lblHeader;
    protected TextControl? lblOperationName;
    protected TextControl? lblMenu01;
    protected TextControl? lblMenu02;
    protected TextControl? lblMenu03;
    protected TextControl? lblMenu04;
    protected TextControl? lblMenu05;
    protected TextControl? lblMenu06;
    protected TextControl? lblMenu07;
    protected TextControl? lblMenu08;
    protected TextControl? lblMenu09;
    protected TextControl? lblMenu00;
    protected TextEditControl? txtUserInput;

    public frmMenu() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmMenu);

        CurrentMenuPath = "/";

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
        lblOperationName.Value = "MAIN MENU";
        Controls.Add(lblOperationName);
        
        lblMenu01 = new TextControl();
        lblMenu01.Name = nameof(lblMenu01);
        lblMenu01.Top = 3;
        lblMenu01.Left = 0;
        lblMenu01.EntireLine = true;
        lblMenu01.Value = "1. TEST FORM";
        Controls.Add(lblMenu01);
        
        lblMenu02 = new TextControl();
        lblMenu02.Name = nameof(lblMenu02);
        lblMenu02.Top = 4;
        lblMenu02.Left = 0;
        lblMenu02.EntireLine = true;
        lblMenu02.Value = "2. USERS";
        Controls.Add(lblMenu02);
        
        lblMenu03 = new TextControl();
        lblMenu03.Name = nameof(lblMenu03);
        lblMenu03.Top = 5;
        lblMenu03.Left = 0;
        lblMenu03.EntireLine = true;
        lblMenu03.Value = "3. APPLICATIONS";
        Controls.Add(lblMenu03);
        
        lblMenu04 = new TextControl();
        lblMenu04.Name = nameof(lblMenu04);
        lblMenu04.Top = 6;
        lblMenu04.Left = 0;
        lblMenu04.EntireLine = true;
        lblMenu04.Value = "4. CONFIGURATION VARIABLES";
        Controls.Add(lblMenu04);
        
        lblMenu05 = new TextControl();
        lblMenu05.Name = nameof(lblMenu05);
        lblMenu05.Top = 7;
        lblMenu05.Left = 0;
        lblMenu05.EntireLine = true;
        lblMenu05.Value = "5. TASKS";
        Controls.Add(lblMenu05);
        
        txtUserInput = new TextEditControl();
        txtUserInput.Name = nameof(txtUserInput);
        txtUserInput.Top = 14;
        txtUserInput.Left = 0;
        txtUserInput.EntireLine = true;
        txtUserInput.Hint = "ENTER MENU";
        txtUserInput.EnterValidation = txtUserInput_EnterValidation;
        txtUserInput.ShowInfoAboutControl = txtUserInput_ShowInfoAboutControl;
        Controls.Add(txtUserInput);
    }

    protected bool txtUserInput_EnterValidation()
    {
        try
        {
            switch (txtUserInput.Value)
            {
                case "":
                case "-n":
                    return false;

                case "-b":
                    GoBack();
                    break;

                default:
                    string menuFullPath = GetMenuFullPath(txtUserInput.Value);
                    return GetFormByFullPath(menuFullPath) || GetMenuByFullPath(menuFullPath);
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            return false;
        }
        finally
        {
            FocusedEditControl = txtUserInput;
            txtUserInput.Value = "";
        }
        return true;
    }

    protected void txtUserInput_ShowInfoAboutControl()
    {
        ShowForm(new frmInfoAboutControl { Header = "INFO ABOUT CONTROL" });
    }

    private bool GetFormByFullPath(string fullPath)
    {
        switch (fullPath)
        {
            case "/1":
            case "/1/":
                // Test form.
                ShowForm(new frmTestForm());
                return true;
            
            case "/2/1":
            case "/2/1/":
                // Users. Search
                ShowForm(new frmUsersSearch());
                return true;
            
            case "/2/2":
            case "/2/2/":
                // Users. Access rights
                ShowForm(new frmUsersAccessRights());
                return true;
            
            case "/2/3":
            case "/2/3/":
                // Users. Edit
                ShowForm(new frmUsersEdit());
                return true;
            
            case "/3/1":
            case "/3/1/":
                // Applications. Search
                ShowForm(new frmAppsSearch());
                return true;
            
            case "/3/2":
            case "/3/2/":
                // Applications. Access rights
                ShowForm(new frmAppsAccessRights());
                return true;
            
            case "/3/3":
            case "/3/3/":
                // Applications. Menu
                ShowForm(new frmAppsMenu());
                return true;
            
            case "/3/4":
            case "/3/4/":
                // Applications. Deploy
                ShowForm(new frmAppsDeploy());
                return true;
            
            case "/3/5":
            case "/3/5/":
                // Applications. Local DB copy
                ShowForm(new frmAppsLocalDbCopy());
                return true;
            
            case "/3/6":
            case "/3/6/":
                // Applications. Release
                ShowForm(new frmAppsRelease());
                return true;
            
            case "/3/7":
            case "/3/7/":
                // Applications. Services
                ShowForm(new frmAppsServices());
                return true;
            
            case "/4/1":
            case "/4/1/":
                // Configuration variables. Common
                ShowForm(new frmConfigVariablesCommon());
                return true;
            
            case "/4/2":
            case "/4/2/":
                // Configuration variables. Applications
                ShowForm(new frmConfigVariablesApps());
                return true;
            
            case "/5/1":
            case "/5/1/":
                // Tasks. Search/Edit
                ShowForm(new frmTasksSearchEdit());
                return true;
            
            case "/5/2":
            case "/5/2/":
                // Tasks. Set responsible employee
                ShowForm(new frmTasksSetResponsibleEmployee());
                return true;
            
            case "/5/3":
            case "/5/3/":
                // Tasks. Cancel
                ShowForm(new frmTasksCancel());
                return true;
        }
        return false;
    }

    private bool GetMenuByFullPath(string fullPath)
    {
        switch (fullPath)
        {
            case "/":
                // Main menu.
                ShowForm(CurrentMenuPath == "/" ? this : new frmMenu());
                return true;
            
            case "/2":
            case "/2/":
                // Users.
                ShowForm(new frmMenuUsers { CurrentMenuPath = "/2/" });
                return true;
            
            case "/3":
            case "/3/":
                // Applications.
                ShowForm(new frmMenuApplications { CurrentMenuPath = "/3/" });
                return true;
            
            case "/4":
            case "/4/":
                // Configuration variables.
                ShowForm(new frmMenuConfigVariables { CurrentMenuPath = "/4/" });
                return true;
            
            case "/5":
            case "/5/":
                // Tasks.
                ShowForm(new frmMenuTasks { CurrentMenuPath = "/5/" });
                return true;
        }
        return false;
    }

    private string GetMenuFullPath(string path)
    {
        if (path.StartsWith('/'))
        {
            return path;
        }
        if (path.StartsWith("./"))
        {
            return CurrentMenuPath + path.Substring(2);
        }
        else
        {
            return !path.Contains('/') ? CurrentMenuPath + path : throw new Exception("Relative path should start with '.'");
        }
    }

    protected virtual void GoBack()
    {
        ShowExitAppForm();
    }
}
