using WorkflowLib.PixelTerminalUI.ServiceEngine.Forms;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

/// <summary>
/// Information required to process the user session.
/// </summary>
public class SessionInfo
{
    public long SessionId { get; set; }
    public string SessionUid { get; set; }
    public int FormHeight { get; set; }
    public int FormWidth { get; set; }
    public long? MenuId { get; set; }
    public string? MenuCode { get; set; }
    public bool DisplayBorders { get; set; }
    public string[,] DisplayedInfo { get; set; }
    public string[,] SavedDisplayedInfo { get; set; }
    public long UserId { get; set; }
    public string? UserLogin { get; set; }
    public string? UserPassword { get; set; }
    public string? UserInput { get; set; }
    public bool UserInputProcessed { get; set; }
    public bool FinishUserSession { get; set; }
    public bool IsPasswordInputNeeded { get; set; }
    public DateTime? DateTimeLastUpdated { get; set; }

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