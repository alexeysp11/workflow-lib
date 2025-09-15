using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Controls;

namespace VelocipedeUtils.PixelTerminalUI.BusinessVisuals.Menu;

public class frmMenuConfigVariables : frmMenu
{
    public frmMenuConfigVariables() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmMenuConfigVariables);

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
        lblOperationName.Value = "MENU: CONFIGURATION VARIABLES";
        Controls.Add(lblOperationName);
        
        lblMenu01 = new TextControl();
        lblMenu01.Name = nameof(lblMenu01);
        lblMenu01.Top = 3;
        lblMenu01.Left = 0;
        lblMenu01.EntireLine = true;
        lblMenu01.Value = "1. COMMON";
        Controls.Add(lblMenu01);
        
        lblMenu02 = new TextControl();
        lblMenu02.Name = nameof(lblMenu02);
        lblMenu02.Top = 4;
        lblMenu02.Left = 0;
        lblMenu02.EntireLine = true;
        lblMenu02.Value = "2. APPLICATIONS";
        Controls.Add(lblMenu02);
        
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

    protected override void GoBack()
    {
        SessionInfo.CurrentForm = ParentForm;
    }
}