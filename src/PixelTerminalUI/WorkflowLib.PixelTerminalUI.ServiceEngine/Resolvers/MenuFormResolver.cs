using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

public class MenuFormResolver
{
    public SessionInfo SessionInfo { get; set; }
    
    private AppSettings _appSettings;

    public MenuFormResolver(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public SessionInfo InitSession()
    {
        int formHeight = 18;
        int formWidth = 36;

        SessionInfo = new SessionInfo();
        SessionInfo.SessionId = 1;
        SessionInfo.SessionUid = Guid.NewGuid().ToString();
        SessionInfo.FormHeight = formHeight;
        SessionInfo.FormWidth = formWidth;
        SessionInfo.DisplayBorders = true;
        SessionInfo.AssignEmptyDisplayedInfo();
        return SessionInfo;
    }

    public void ProcessUserInput(string userInput)
    {
        SessionInfo.UserInput = userInput;
        SessionInfo.UserInputProcessed = false;
        if (SessionInfo.FinishUserSession)
        {
            SessionInfo.CurrentForm = SessionInfo.CurrentForm.ParentForm;
        }
        SessionInfo.FinishUserSession = false;
        SessionInfo.CurrentForm.Show();
    }

    public void Start()
    {
        try
        {
            BaseForm form = CreateForm();

            form.SessionInfo = SessionInfo;
            form.SessionInfo.UserInputProcessed = true;

            form.FillFormAttributes(_appSettings?.MenuCode);
            form.Init();
            form.Show();

            SessionInfo.CurrentForm = form;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private BaseForm CreateForm()
    {
        string typeName = _appSettings?.InitialFormTypeName;

        if (string.IsNullOrEmpty(typeName))
        {
            throw new Exception($"Could not create the form of type '{typeName}': type name is not specified in the appsettings");
        }

        Type type = Type.GetType(typeName, true);
        object instance = Activator.CreateInstance(type);
        if (instance == null)
        {
            throw new Exception($"Could not create the form of type '{typeName}': type name is not found for the selected menu");
        }
        if (instance is not BaseForm)
        {
            throw new Exception($"Could not create the form of type '{typeName}': not derived from {nameof(BaseForm)}");
        }

        return (BaseForm)instance;
    }
}