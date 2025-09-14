using BuildAutomationTool.Models;
using BuildAutomationTool.Logging;
using Microsoft.Extensions.Logging;

namespace BuildAutomationTool.Managers
{
    /// <summary>
    /// .
    /// </summary>
    public class GitManager
    {
        private Logger _logger;
        private CommandLineManager _commandLineManager;

        public GitManager(
            Logger logger,
            CommandLineManager commandLineManager)
        {
            _logger = logger;
            _commandLineManager = commandLineManager;
        }

        /// <summary>
        /// Run commands to work with git.
        /// </summary>
        public void RunGitCommand(ProjectSettings project)
        {
            _logger.LogMessage($"Git command", LogLevel.Warning, true);

            if (!project.IsConnectedToGit)
            {
                _logger.LogMessage("According to configurations, local repository is not connected to remote repository. Command will not be executed.", LogLevel.Information, true);
                return;
            }

            var commandGit = string.Empty;
            if (project.GitClone)
            {
                commandGit = $"cd \"{project.LocalRepositoryPath}\" && git clone {project.RemoteRepositoryUrl.Replace(".git", "")}.git";
            }
            else
            {
                // TODO: Check if Branch is available in the repository.
                if (string.IsNullOrEmpty(project.Branch))
                {
                    project.Branch = GetGitBranchName();
                }

                commandGit = $"cd \"{project.LocalRepositoryPath}\" && git checkout {project.Branch} && git pull origin {project.Branch}";
            }
            _logger.LogMessage($"command: '{commandGit}'");
            _commandLineManager.RunCommandPrompt(commandGit);
        }

        /// <summary>
        /// Get the name of the branch in git that the user would like to work on.
        /// </summary>
        private string GetGitBranchName()
        {
            var branchName = string.Empty;
            while (true)
            {
                _logger.LogMessage("According to configurations, git branch is not specified. Please, enter the name of git branch...");
                branchName = System.Console.ReadLine();
                if (!string.IsNullOrEmpty(branchName))
                    break;
            }
            return branchName;
        }
    }
}