using AutoBuildTool.Managers;

namespace AutoBuildTool;

/// <summary>
/// Class for standardized launch of an application instance.
/// </summary>
public class StartupInstance : IStartupInstance
{
    private ProjectManager _projectManager;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public StartupInstance(
        ProjectManager projectManager)
    {
        _projectManager = projectManager;
    }

    /// <summary>
    /// Method for standardized launch of an application instance.
    /// </summary>
    public void Start()
    {
        _projectManager.StartBuildProject();
    }
}