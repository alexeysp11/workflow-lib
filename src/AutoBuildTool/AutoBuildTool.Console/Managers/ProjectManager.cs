using AutoBuildTool.Common.Models;
using AutoBuildTool.Console.Logging;
using Microsoft.Extensions.Logging;

namespace AutoBuildTool.Console.Managers
{
    /// <summary>
    /// .
    /// </summary>
    public class ProjectManager
    {
        private AutoBuildToolSettings _settings;
        private Logger _logger;
        private CommandLineManager _commandLineManager;
        private GitManager _gitManager;

        public ProjectManager(
            AutoBuildToolSettings settings,
            Logger logger,
            CommandLineManager commandLineManager,
            GitManager gitManager)
        {
            if (settings == null)
                throw new System.ArgumentNullException(nameof(settings), "AutoBuildToolSettings could not be null");
            
            _settings = settings;

            _logger = logger;
            _commandLineManager = commandLineManager;
            _gitManager = gitManager;
        }
        
        /// <summary>
        /// Method for standardized launch of an application instance.
        /// </summary>
        public void StartBuildProject()
        {
            while (true)
            {
                try
                {
                    PrintAllProjects();
                    var index = GetProjectIndex();
                    BuildProject(_settings.Projects[index]);
                }
                catch (System.Exception ex)
                {
                    _logger.LogMessage(ex.Message, LogLevel.Error);
                }
            }
        }

        /// <summary>
        /// Displays the names of all projects that can be collected.
        /// </summary>
        private void PrintAllProjects()
        {
            _logger.LogMessage("PROJECT BUILDING STARTED", LogLevel.Information, true);
            _logger.LogMessage("Projects", LogLevel.Warning, true);
            for (int i = 0; i < _settings.Projects.Count; i++)
            {
                _logger.LogMessage((i + 1) + ". " + _settings.Projects[i].Name);
            }
        }

        /// <summary>
        /// Getting the index of the project that the user would like to start building.
        /// </summary>
        private int GetProjectIndex()
        {
            _logger.LogMessage("Enter index of the project...");
            var input = System.Console.ReadLine();
            int index = 0;
            if (!int.TryParse(input, out index))
            {
                throw new System.Exception("Input could not be converted to integer");
            }
            index = index - 1;
            if (index >= _settings.Projects.Count)
            {
                throw new System.Exception("Incorrect index");
            }
            return index;
        }
        
        /// <summary>
        /// Start building the selected project.
        /// </summary>
        private void BuildProject(ProjectSettings project)
        {
            PrintSettings(project);
            ValidatePaths(project);
            _gitManager.RunGitCommand(project);
            RunBuildCommand(project);

            _logger.LogMessage("Build finished", LogLevel.Warning, true);
        }

        /// <summary>
        /// Display configuration settings associated with the selected project.
        /// </summary>
        private void PrintSettings(ProjectSettings project)
        {
            _logger.LogMessage($"Configurations", LogLevel.Warning, true);

            _logger.LogMessage($"IsConnectedToGit: '{project.IsConnectedToGit}'");
            _logger.LogMessage($"RemoteRepositoryUrl: '{project.RemoteRepositoryUrl}'");
            _logger.LogMessage($"LocalRepositoryPath: '{project.LocalRepositoryPath}'");
            _logger.LogMessage($"Branch: '{project.Branch}'");
            _logger.LogMessage($"TargetRelativePath: '{project.TargetRelativePath}'");
            _logger.LogMessage($"BuildTool: '{project.BuildTool}'");
            _logger.LogMessage($"MSBuildPath: '{_settings.MSBuildPath}'");
        }
        
        /// <summary>
        /// Validate the paths specified for the selected project.
        /// </summary>
        private void ValidatePaths(ProjectSettings project)
        {
            _logger.LogMessage($"Path validation", LogLevel.Warning, true);

            if (project.IsConnectedToGit)
            {
                if (string.IsNullOrEmpty(project.RemoteRepositoryUrl))
                    throw new System.Exception($"RemoteRepositoryUrl is incorrect: '{project.RemoteRepositoryUrl}'");
            }
            if (string.IsNullOrEmpty(project.LocalRepositoryPath) || !System.IO.Directory.Exists(project.LocalRepositoryPath))
                throw new System.Exception($"LocalRepositoryPath is incorrect: '{project.LocalRepositoryPath}'");
        }
        
        /// <summary>
        /// Execute the build command for the selected project.
        /// </summary>
        private void RunBuildCommand(ProjectSettings project)
        {
            _logger.LogMessage($"Build project", LogLevel.Warning, true);

            var targetPath = System.IO.Path.Combine(project.LocalRepositoryPath, project.TargetRelativePath);
            if (string.IsNullOrEmpty(project.TargetRelativePath) || !System.IO.File.Exists(targetPath))
                throw new System.Exception($"TargetRelativePath is incorrect: '{project.TargetRelativePath}'");
            
            var commandBuild = string.Empty;
            switch (project.BuildTool)
            {
                case "dotnet":
                    commandBuild = $"dotnet build \"{targetPath}\"";
                    break;

                case "MSBuild":
                    if (string.IsNullOrEmpty(_settings.MSBuildPath) || !System.IO.File.Exists(_settings.MSBuildPath))
                        throw new System.Exception("MSBuildPath is incorrect");
                    
                    commandBuild = $"\"{_settings.MSBuildPath}\" \"{targetPath}\"";
                    _logger.LogMessage($"command: '{commandBuild}'");
                    _logger.LogMessage("The specified project cannot be built using MSBuild automatically, try running the script directly from the command line.", LogLevel.Information, true);
                    return;

                default:
                    throw new System.Exception($"Incorrect value of BuildTool: '{project.BuildTool}'");
            }
            _logger.LogMessage($"command: '{commandBuild}'");
            _commandLineManager.RunCommandPrompt(commandBuild);
        }
    }
}