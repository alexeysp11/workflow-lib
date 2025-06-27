using WorkflowLib.PixelTerminalUI.ConsoleAdapter.Helpers;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Dto;

/// <summary>
/// Information required to process the user session (DTO).
/// </summary>
public class SessionInfoDto
{
    public string SessionUid { get; set; }
    public int FormHeight { get; set; }
    public int FormWidth { get; set; }
    public string? MenuCode { get; set; }
    public string DisplayedInfo { get; set; }
    public string? SavedDisplayedInfo { get; set; }
    public string? UserLogin { get; set; }
    public string? UserInput { get; set; }
    public int UserInputWdith { get; set; }
    public bool FinishUserSession { get; set; }
    public bool IsPasswordInputNeeded { get; set; }
    public bool WaitScreenDisplayed { get; set; }

    public SessionInfoDto()
    {
        SessionUid = string.Empty;
        UserLogin = string.Empty;
        DisplayedInfo = string.Empty;
    }

    public SessionInfoDto(SessionInfo sessionInfo)
    {
        if (sessionInfo == null)
        {
            throw new ArgumentNullException(nameof(sessionInfo));
        }

        bool displayBorders = sessionInfo.DisplayBorders;
        
        SessionUid = sessionInfo.SessionUid;
        FormHeight = sessionInfo.FormHeight;
        FormWidth = sessionInfo.FormWidth;
        MenuCode = sessionInfo.MenuCode;
        DisplayedInfo = ConsoleHelper.GetDisplayedInfoString(sessionInfo.DisplayedInfo, displayBorders);
        if (sessionInfo.SavedDisplayedInfo != null)
        {
            SavedDisplayedInfo = ConsoleHelper.GetDisplayedInfoString(sessionInfo.SavedDisplayedInfo, displayBorders);
        }
        UserLogin = sessionInfo.UserLogin;
        UserInput = sessionInfo.UserInput;
        UserInputWdith = sessionInfo.CurrentForm?.FocusedEditControl?.Width ?? sessionInfo.FormWidth;
        FinishUserSession = sessionInfo.FinishUserSession;
        IsPasswordInputNeeded = sessionInfo.IsPasswordInputNeeded;
        WaitScreenDisplayed = sessionInfo.WaitScreenDisplayed;
    }
}