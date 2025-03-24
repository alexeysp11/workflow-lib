using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Menu;

public class frmMenuApplications : frmMenu
{
    public frmMenuApplications() : base()
    {
    }
    
    protected override void InitializeComponent()
    {
        Name = nameof(frmMenuApplications);

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
        lblOperationName.Value = "MENU: APPLICATIONS";
        Controls.Add(lblOperationName);
        
        lblMenu01 = new TextControl();
        lblMenu01.Name = nameof(lblMenu01);
        lblMenu01.Top = 3;
        lblMenu01.Left = 0;
        lblMenu01.EntireLine = true;
        lblMenu01.Value = "1. SEARCH";
        Controls.Add(lblMenu01);
        
        lblMenu02 = new TextControl();
        lblMenu02.Name = nameof(lblMenu02);
        lblMenu02.Top = 4;
        lblMenu02.Left = 0;
        lblMenu02.EntireLine = true;
        lblMenu02.Value = "2. ACCESS RIGHTS";
        Controls.Add(lblMenu02);
        
        lblMenu03 = new TextControl();
        lblMenu03.Name = nameof(lblMenu03);
        lblMenu03.Top = 5;
        lblMenu03.Left = 0;
        lblMenu03.EntireLine = true;
        lblMenu03.Value = "3. MENU";
        Controls.Add(lblMenu03);
        
        lblMenu04 = new TextControl();
        lblMenu04.Name = nameof(lblMenu04);
        lblMenu04.Top = 6;
        lblMenu04.Left = 0;
        lblMenu04.EntireLine = true;
        lblMenu04.Value = "4. DEPLOY";
        Controls.Add(lblMenu04);
        
        lblMenu05 = new TextControl();
        lblMenu05.Name = nameof(lblMenu05);
        lblMenu05.Top = 7;
        lblMenu05.Left = 0;
        lblMenu05.EntireLine = true;
        lblMenu05.Value = "5. LOCAL DB COPY";
        Controls.Add(lblMenu05);
        
        lblMenu06 = new TextControl();
        lblMenu06.Name = nameof(lblMenu06);
        lblMenu06.Top = 8;
        lblMenu06.Left = 0;
        lblMenu06.EntireLine = true;
        lblMenu06.Value = "6. RELEASE";
        Controls.Add(lblMenu06);
        
        lblMenu07 = new TextControl();
        lblMenu07.Name = nameof(lblMenu07);
        lblMenu07.Top = 9;
        lblMenu07.Left = 0;
        lblMenu07.EntireLine = true;
        lblMenu07.Value = "7. SERVICES";
        Controls.Add(lblMenu07);
        
        txtUserInput = new TextEditControl();
        txtUserInput.Name = nameof(txtUserInput);
        txtUserInput.Top = 14;
        txtUserInput.Left = 0;
        txtUserInput.EntireLine = true;
        txtUserInput.Hint = "ENTER MENU";
        txtUserInput.EnterValidation = txtUserInput_EnterValidation;
        Controls.Add(txtUserInput);
    }

    protected override void GoBack()
    {
        SessionInfo.CurrentForm = ParentForm;
    }
}