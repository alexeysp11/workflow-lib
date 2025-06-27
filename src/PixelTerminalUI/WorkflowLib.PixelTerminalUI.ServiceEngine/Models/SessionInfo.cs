using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

/// <summary>
/// Information required to process the user session.
/// </summary>
public class SessionInfo
{
    /// <summary>
    /// Session ID.
    /// </summary>
    public long SessionId { get; set; }

    /// <summary>
    /// Session UID.
    /// </summary>
    public string SessionUid { get; set; }

    /// <summary>
    /// Form height.
    /// </summary>
    public int FormHeight { get; set; }

    /// <summary>
    /// Form width.
    /// </summary>
    public int FormWidth { get; set; }

    /// <summary>
    /// Menu ID.
    /// </summary>
    public long? MenuId { get; set; }

    /// <summary>
    /// Menu code.
    /// </summary>
    public string? MenuCode { get; set; }

    /// <summary>
    /// Determines whether to display borders for the form.
    /// </summary>
    public bool DisplayBorders { get; set; }

    /// <summary>
    /// Displayed information on the screen.
    /// </summary>
    public string[,] DisplayedInfo { get; set; }

    /// <summary>
    /// Saved displayed information on the screen.
    /// </summary>
    public string[,] SavedDisplayedInfo { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// User login.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary>
    /// User password.
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// User input.
    /// </summary>
    public string? UserInput { get; set; }

    /// <summary>
    /// Saved user password.
    /// </summary>
    public string? SavedUserInput { get; set; }

    /// <summary>
    /// Determines whether the user input is processed.
    /// </summary>
    public bool UserInputProcessed { get; set; }

    /// <summary>
    /// Determines whether to finish the user session.
    /// </summary>
    public bool FinishUserSession { get; set; }

    /// <summary>
    /// Determines whether password input needed, to display * instead of letters.
    /// </summary>
    public bool IsPasswordInputNeeded { get; set; }

    /// <summary>
    /// Last updated datetime.
    /// </summary>
    public DateTime? DateTimeLastUpdated { get; set; }

    /// <summary>
    /// Determines whether the wait screen is displayed.
    /// </summary>
    public bool WaitScreenDisplayed { get; set; }

    /// <summary>
    /// Determines whether the wait screen skipped.
    /// </summary>
    public bool WaitScreenSkipped { get; set; }

    /// <summary>
    /// The currently displayed form.
    /// </summary>
    public BaseForm? CurrentForm { get; set; }

    /// <summary>
    /// Application settings.
    /// </summary>
    public AppSettings? AppSettings { get; set; }
    
    /// <summary>
    /// Info about the database that was selected during authentication.
    /// </summary>
    public DatabaseInfo? DatabaseInfo { get; set; }

    /// <summary>
    /// User account that was validated during authentication.
    /// </summary>
    public UserAccount? UserAccount { get; set; }

    /// <summary>
    /// Form which called the wait screen.
    /// </summary>
    public BaseForm? WaitScreenParentForm { get; set; }

    public void AssignEmptyDisplayedInfo(DisplayedInfoType displayedInfoType = DisplayedInfoType.Current)
    {
        var displayedInfo = new string[FormHeight, FormWidth];

        for (int i = 0; i < displayedInfo.GetLength(0); i++)
        {
            for (int j = 0; j < displayedInfo.GetLength(1); j++)
            {
                displayedInfo[i, j] = " ";
            }
        }

        if (displayedInfoType == DisplayedInfoType.Saved)
        {
            SavedDisplayedInfo = displayedInfo;
        }
        else
        {
            DisplayedInfo = displayedInfo;
        }
    }
}