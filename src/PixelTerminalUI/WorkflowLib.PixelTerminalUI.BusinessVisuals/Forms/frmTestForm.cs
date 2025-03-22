using WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;

namespace WorkflowLib.PixelTerminalUI.BusinessVisuals.Forms;

public class frmTestForm : BaseForm
{
    private TextControl? lblHeader;
    private TextControl? lblOperationName;
    private TextControl? lblRequestNumber;
    private TextControl? lblRequestNumberCount;
    private TextControl? lblValue1;
    private TextControl? lblValue2;
    private TextControl? lblValue3;
    private TextEditControl? txtValue1;
    private TextEditControl? txtValue2;
    private TextEditControl? txtValue3;

    public frmTestForm() : base()
    {
    }

    protected override void InitializeComponent()
    {
        Name = nameof(frmTestForm);
        
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
        lblOperationName.Value = "TEST FORM";
        Controls.Add(lblOperationName);

        lblRequestNumber = new TextControl();
        lblRequestNumber.Name = nameof(lblRequestNumber);
        lblRequestNumber.Top = 3;
        lblRequestNumber.Left = 0;
        lblRequestNumber.Width = 18;
        lblRequestNumber.Value = "COUNTER:";
        Controls.Add(lblRequestNumber);

        lblRequestNumberCount = new TextControl();
        lblRequestNumberCount.Name = nameof(lblRequestNumberCount);
        lblRequestNumberCount.Top = 3;
        lblRequestNumberCount.Left = 18;
        lblRequestNumberCount.Width = 4;
        lblRequestNumberCount.Value = "0";
        Controls.Add(lblRequestNumberCount);

        lblValue1 = new TextControl();
        lblValue1.Name = nameof(lblValue1);
        lblValue1.Top = 5;
        lblValue1.Left = 0;
        lblValue1.EntireLine = true;
        lblValue1.Value = "VALUE 1:";
        Controls.Add(lblValue1);

        txtValue1 = new TextEditControl();
        txtValue1.Name = nameof(txtValue1);
        txtValue1.Top = 6;
        txtValue1.Left = 0;
        txtValue1.EntireLine = true;
        txtValue1.Hint = "ENTER VALUE 1";
        txtValue1.EnterValidation = txtValue1_EnterValidation;
        Controls.Add(txtValue1);

        lblValue2 = new TextControl();
        lblValue2.Name = nameof(lblValue2);
        lblValue2.Top = 8;
        lblValue2.Left = 0;
        lblValue2.EntireLine = true;
        lblValue2.Value = "VALUE 2:";
        Controls.Add(lblValue2);

        txtValue2 = new TextEditControl();
        txtValue2.Name = nameof(txtValue2);
        txtValue2.Top = 9;
        txtValue2.Left = 0;
        txtValue2.EntireLine = true;
        txtValue2.Hint = "ENTER VALUE 2";
        txtValue2.EnterValidation = txtValue2_EnterValidation;
        Controls.Add(txtValue2);

        lblValue3 = new TextControl();
        lblValue3.Name = nameof(lblValue3);
        lblValue3.Top = 11;
        lblValue3.Left = 0;
        lblValue3.EntireLine = true;
        lblValue3.Value = "VALUE 3:";
        Controls.Add(lblValue3);

        txtValue3 = new TextEditControl();
        txtValue3.Name = nameof(txtValue3);
        txtValue3.Top = 12;
        txtValue3.Left = 0;
        txtValue3.EntireLine = true;
        txtValue3.Hint = "ENTER VALUE 3";
        txtValue3.EnterValidation = txtValue3_EnterValidation;
        Controls.Add(txtValue3);
    }

    private bool txtValue1_EnterValidation()
    {
        try
        {
            switch (txtValue1.Value)
            {
                case "-n":
                    txtValue1.Value = "";
                    return false;
                case "-b":
                    SessionInfo.CurrentForm = ParentForm;
                    return true;
            }
            FocusedEditControl = txtValue2;
            return true;
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            txtValue1.Value = "";
            return false;
        }
    }

    private bool txtValue2_EnterValidation()
    {
        try
        {
            switch (txtValue2.Value)
            {
                case "-n":
                    txtValue2.Value = "";
                    return false;
                case "-b":
                    txtValue2.Value = "";
                    FocusedEditControl = txtValue1;
                    return true;
            }
            FocusedEditControl = txtValue3;
            return true;
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            txtValue2.Value = "";
            return false;
        }
    }

    private bool txtValue3_EnterValidation()
    {
        try
        {
            switch (txtValue3.Value)
            {
                case "-n":
                    txtValue3.Value = "";
                    return false;
                case "-b":
                    txtValue3.Value = "";
                    FocusedEditControl = txtValue2;
                    return true;
            }
            SessionInfo.CurrentForm = ParentForm;
            return true;
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            txtValue3.Value = "";
            return false;
        }
    }
}