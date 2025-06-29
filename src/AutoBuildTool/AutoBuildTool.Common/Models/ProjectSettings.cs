namespace AutoBuildTool.Common.Models
{
    /// <summary>
    /// Project to build
    /// </summary>
    public class ProjectSettings
    {
        /// <summary>
        /// Name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether the local repository is connected to remote repository.
        /// </summary>
        public bool IsConnectedToGit { get; set; }

        /// <summary>
        /// Remote repository URL.
        /// </summary>
        public string RemoteRepositoryUrl { get; set; }

        /// <summary>
        /// Indicates whether the remote repository should be cloned, otherwise git pull command will be executed.
        /// </summary>
        public bool GitClone { get; set; }

        /// <summary>
        /// Branch to build.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Local repository path.
        /// </summary>
        public string LocalRepositoryPath { get; set; }

        /// <summary>
        /// Relative path of the target solution or csproj.
        /// </summary>
        public string TargetRelativePath { get; set; }

        /// <summary>
        /// Build tool.
        /// </summary>
        public string BuildTool { get; set; }
    }
}
