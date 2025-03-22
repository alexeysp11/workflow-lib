using WorkflowLib.PixelTerminalUI.BusinessVisuals.TestForms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;

public class frmMenu : BaseForm
{
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

    protected string _currentMenuPath;

    public frmMenu() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmMenu);

        _currentMenuPath = "/";

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
        lblOperationName.Value = "MENU";
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

                case "-q":
                case "-b":
                    ShowInformation("Are you sure to exit the application?");
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

    private bool GetFormByFullPath(string fullPath)
    {
        switch (fullPath)
        {
            case "/1":
                // Test form.
                ShowForm(new frmTestForm());
                return true;
            
            case "/2/1":
                // Users. Search
                return true;
            
            case "/2/2":
                // Users. Access rights
                return true;
            
            case "/2/3":
                // Users. Edit
                return true;
            
            case "/3/1":
                // Applications. Search
                return true;
            
            case "/3/2":
                // Applications. Access rights
                return true;
            
            case "/3/3":
                // Applications. Menu
                return true;
            
            case "/3/4":
                // Applications. Deploy
                return true;
            
            case "/3/5":
                // Applications. Local DB copy
                return true;
            
            case "/3/6":
                // Applications. Release
                return true;
            
            case "/3/7":
                // Applications. Services
                return true;
            
            case "/4/1":
                // Configuration variables. Common
                return true;
            
            case "/4/2":
                // Configuration variables. Applications
                return true;
            
            case "/5/1":
                // Tasks. Search/Edit
                return true;
            
            case "/5/2":
                // Tasks. Set responsible employee
                return true;
            
            case "/5/3":
                // Tasks. Cancel
                return true;
        }
        return false;
    }

    private bool GetMenuByFullPath(string fullPath)
    {
        switch (fullPath)
        {
            case "/2":
                // Users.
                return true;
            
            case "/3":
                // Applications.
                return true;
            
            case "/4":
                // Configuration variables.
                return true;
            
            case "/5":
                // Tasks.
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
            return _currentMenuPath + path.Substring(2);
        }
        else
        {
            return !path.Contains('/') ? _currentMenuPath + path : throw new Exception("Relative path should start with '.'");
        }
    }
}
