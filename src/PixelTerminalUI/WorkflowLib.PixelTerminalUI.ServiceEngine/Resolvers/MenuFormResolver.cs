using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

public class MenuFormResolver
{
    public SessionInfo? SessionInfo { get; set; }
    
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
        SessionInfo.IsPasswordInputNeeded = false;
        if (SessionInfo.FinishUserSession)
        {
            SessionInfo.CurrentForm = SessionInfo.CurrentForm.ParentForm;
        }
        SessionInfo.FinishUserSession = false;
        SessionInfo.CurrentForm.Show();
    }

    /// <summary>
    /// Start a new user session.
    /// </summary>
    public void Start()
    {
        try
        {
            BaseForm form = CreateForm();

            form.SessionInfo = SessionInfo;
            form.SessionInfo.UserInputProcessed = true;

            if (form.FormParameters == null)
            {
                form.FormParameters = new FormParameters();
            }

            form.FillFormAttributes(_appSettings?.MenuCode ?? "");
            form.Init();
            form.Show();

            SessionInfo.CurrentForm = form;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Create the form dynamically using the type name specified in appsettings file.
    /// </summary>
    /// <returns>Created form of type <see cref="BaseForm"/></returns>
    private BaseForm CreateForm()
    {
        string? typeName = _appSettings?.InitialFormTypeName;

        if (string.IsNullOrEmpty(typeName))
        {
            throw new Exception($"Could not create the form of type '{typeName}': type name is not specified in the appsettings");
        }

        Type? type = Type.GetType(typeName, true);
        if (type == null)
        {
            throw new Exception($"Could not create the form of type '{typeName}': type is not acquired");
        }
        object? instance = Activator.CreateInstance(type);
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